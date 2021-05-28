using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
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

        Result<IDictionary<string, double>> IFinanceRetrivalService.GetPerformanceThisYear(string symbol)
        {
            CheckSymbolForDataUpdates(symbol);
            return RetrievePerformance(symbol);
        }

        private void CheckSymbolForDataUpdates(string symbol)
        {
            var symbolId = GetSymbolId(symbol);
            if (!symbolId.HasValue)
            {
                InitializeSymbol(symbol);
            }
            else if (GetLatestPerformanceDate(symbol) < GetLastWeekDay())
            {
                UpdateSymbol(symbol, symbolId.Value);
            }

        }

        private DateTime GetLastWeekDay()
        {
            var returnDay = DateTime.Today;
            if (returnDay.DayOfWeek == DayOfWeek.Saturday)
            {
                returnDay.AddDays(-1);
            }
            else if (returnDay.DayOfWeek == DayOfWeek.Sunday)
            {
                returnDay.AddDays(-2);
            }

            return returnDay;
        }

        private Result<IDictionary<string, double>> RetrievePerformance(string symbol)
        {
            var stock = _stockRepository.GetSymbol(symbol);
            var performance = stock.Performance
                .OrderBy(stock => stock.valueDate)
                .ToDictionary(performance => performance.valueDate.ToShortDateString(), performance => performance.close);
            return Result<IDictionary<string, double>>.CreateSuccessResult(performance);
        }
        private int? GetSymbolId(string symbol)
        {
            return _stockRepository.GetSymbol(symbol)?.StockInfoId;
        }
        private async void InitializeSymbol(string symbol)
        {
            //var response = await _alphaVantageClient.GetPerformanceAllTime(symbol);
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseString = await response.Content.ReadAsStringAsync();

            var responseString = File.ReadAllText(@"D:\Programmierung\Repository\PersonalWebPage\PersonalWebPage\WebPage.Server.Console\TrainingRessources\bmw.json");
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var alphvantageStock = JsonSerializer.Deserialize<StockInfoDaily>(responseString);
            var stockInfo = alphvantageStock.ConvertToStockInfo();
            stockInfo.Performance = stockInfo.Performance
                .Where(performance => performance.valueDate.Year == DateTime.Today.Year)
                .ToList();
            _ = await _stockRepository.Create(stockInfo);


            // }
        }

        private DateTime GetLatestPerformanceDate(string symbol)
        {
            return _stockRepository.GetSymbol(symbol).LastRefreshed;
        }

        private void UpdateSymbol(string symbol, int symbolId)
        {
            var existingStockInfo = _stockRepository.GetSymbol(symbol);

            var responseString = File.ReadAllText(@"D:\Programmierung\Repository\PersonalWebPage\PersonalWebPage\WebPage.Server.Console\TrainingRessources\bmwnew.json");
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var alphvantageStock = JsonSerializer.Deserialize<StockInfoDaily>(responseString);
            var stockInfo = alphvantageStock.ConvertToStockInfo();
            stockInfo.Performance = stockInfo.Performance
               .Where(performance => performance.valueDate.Year == DateTime.Today.Year)
               .ToList();

            var missingDates = stockInfo.Performance
                .Select(performance => performance.valueDate)
                .Except(existingStockInfo.Performance.Select(performance => performance.valueDate));

            if (!missingDates.Any())
            {
                return;
            }

            var missingValueSets = stockInfo.Performance
                .Where(performance => missingDates.Contains(performance.valueDate));

            existingStockInfo.Performance = existingStockInfo.Performance
                .Concat(missingValueSets)
                .ToList();

            existingStockInfo.LastRefreshed = missingDates
                .Max();

            _stockRepository.Update(existingStockInfo);
        }




    }
}