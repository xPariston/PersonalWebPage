using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WebPage.Server.Base;
using WebPage.Server.FinanceService.Clients;
using WebPage.Server.FinanceService.DataAccess.AlphaVantageApi;
using WebPage.Server.FinanceService.DataAccess.Converter;
using WebPage.Server.FinanceService.DataAccess.ServiceRepository;

namespace WebPage.Server.FinanceService
{
    public class FinanceRetrivalService : IFinanceRetrivalService
    {
        private readonly IStockInfoRepository _stockRepository;
        private readonly IAlphaVantageClient _alphaVantageClient;

        public FinanceRetrivalService(IStockInfoRepository stockRepository, IAlphaVantageClient alphaVantageClient)
        {
            _stockRepository = stockRepository;
            _alphaVantageClient = alphaVantageClient;
        }

        async Task<Result<IDictionary<string, double>>> IFinanceRetrivalService.GetPerformanceThisYear(string symbol)
        {
            var performedDatabaseAction = await CheckSymbolForValueUpdates(symbol);

            if (performedDatabaseAction == PerformedDatabaseAction.Error)
            {
                return Result<IDictionary<string, double>>.CreateBadRequestResult();
            }

            return RetrievePerformance(symbol);
        }

        private async Task<PerformedDatabaseAction> CheckSymbolForValueUpdates(string symbol)
        {
            var symbolId = GetSymbolId(symbol);
            if (!symbolId.HasValue)
            {
                return await InitializeSymbol(symbol);
            }
            else if (GetLatestPerformanceDate(symbol) < DateTime.Today)
            {
                return await UpdateSymbol(symbol, symbolId.Value);
            }
            else
            {
                return PerformedDatabaseAction.Nothing;
            }
        }

        private Result<IDictionary<string, double>> RetrievePerformance(string symbol)
        {
            var stock = _stockRepository.GetSymbol(symbol);

            if (stock == null)
            {
                return Result<IDictionary<string, double>>.CreateNotFoundResult();
            }

            var performance = stock.Performance
                .OrderBy(stock => stock.valueDate)
                .ToDictionary(performance => performance.valueDate.ToShortDateString(), performance => performance.close);

            return Result<IDictionary<string, double>>.CreateSuccessResult(performance);
        }

        private int? GetSymbolId(string symbol)
        {
            return _stockRepository.GetSymbol(symbol)?.StockInfoId;
        }

        private async Task<PerformedDatabaseAction> InitializeSymbol(string symbol)
        {
            var response = await _alphaVantageClient.GetPerformanceAllTime(symbol);
            if (response.IsSuccessStatusCode)
            {
                var stockInfo = await DeserializeAlphavantageJson(response);
                stockInfo.LastRefreshed = DateTime.Today;
                var entity = await _stockRepository.Create(stockInfo);
                if (entity != null)
                {
                    return PerformedDatabaseAction.Create;
                }
            }

            return PerformedDatabaseAction.Error;
        }

        private DateTime GetLatestPerformanceDate(string symbol)
        {
            return _stockRepository.GetSymbol(symbol).LastRefreshed;
        }

        private async Task<PerformedDatabaseAction> UpdateSymbol(string symbol, int symbolId)
        {
            var existingStockInfo = _stockRepository.GetSymbol(symbol);

            var response = await _alphaVantageClient.GetPerformanceLast100Days(symbol);
            if (response.IsSuccessStatusCode)
            {
                var stockInfo = await DeserializeAlphavantageJson(response);

                var missingDates = stockInfo.Performance
                    .Select(performance => performance.valueDate)
                    .Except(existingStockInfo.Performance.Select(performance => performance.valueDate));

                if (missingDates.Any())
                {
                    var missingValueSets = stockInfo.Performance
                    .Where(performance => missingDates.Contains(performance.valueDate));

                    existingStockInfo.Performance = existingStockInfo.Performance
                        .Concat(missingValueSets)
                        .ToList();
                }

                existingStockInfo.LastRefreshed = DateTime.Today;

                _stockRepository.Update(existingStockInfo);
                return PerformedDatabaseAction.Update;
            }
            else
            {
                return PerformedDatabaseAction.Error;
            }
        }

        private async Task<StockInfo> DeserializeAlphavantageJson(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var alphvantageStock = JsonSerializer.Deserialize<StockInfoDaily>(responseString);
            var stockInfo = alphvantageStock.ConvertToStockInfo();
            stockInfo.Performance = stockInfo.Performance
                .Where(performance => performance.valueDate.Year == DateTime.Today.Year)
                .ToList();
            return stockInfo;
        }
    }
}