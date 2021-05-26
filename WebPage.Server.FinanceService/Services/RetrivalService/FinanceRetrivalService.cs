using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebPage.Server.Base;
using WebPage.Server.FinanceService.Clients;
using WebPage.Server.FinanceService.DataAccess.AlphaVantageApi;
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

        Result<IDictionary<string, double>> IFinanceRetrivalService.GetPerformanceThisYear(string symbol)
        {
            CheckSymbolForDataUpdates(symbol);
            return RetrievePerformance(symbol);
        }

        private void CheckSymbolForDataUpdates(string symbol)
        {
            if (!IsSymbolInDatabase(symbol))
            {
                InitializeSymbol(symbol);
            }
            else if (GetLatestPerformanceDate(symbol) < DateTime.Today)
            {
                UpdateSymbol(symbol);
            }

        }
        private Result<IDictionary<string, double>> RetrievePerformance(string symbol)
        {
            var stock = _stockRepository.GetSymbol(symbol);
            var performance = stock.Performance
                .OrderBy(stock => stock.valueDate)
                .ToDictionary(performance => performance.valueDate.ToShortDateString(), performance => performance.close);
            return Result<IDictionary<string, double>>.CreateSuccessResult(performance);
        }
        private bool IsSymbolInDatabase(string symbol)
        {
            return _stockRepository.GetSymbol(symbol) == null;
        }
        private async void InitializeSymbol(string symbol)
        {
            var response = await _alphaVantageClient.GetPerformanceAllTime(symbol);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var stockDaily = JsonSerializer.Deserialize<StockInfoDaily>(responseString);
                var DailyValues = stockDaily.TimeSeriesDaily.Values;
                List<decimal> CloseValues = new List<decimal>();
                foreach (var value in DailyValues)
                {
                    string close = value.close.Replace(".", ",");
                    CloseValues.Add(decimal.Parse(close));
                }
            }
        }

        private DateTime GetLatestPerformanceDate(string symbol)
        {
            return _stockRepository.GetSymbol(symbol).FirstValueDate;
        }

        private void UpdateSymbol(string symbol)
        {
            throw new NotImplementedException();
        }




    }
}