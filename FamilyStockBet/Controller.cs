﻿using FamilyStockBet.Client;
using FamilyStockBet.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyStockBet
{
    public class Controller
    {
        public Shareholders Shareholders { get; set; }
        public IFinanceServiceClient FinanceServiceClient { get; set; }

        public Controller(IFinanceServiceClient financeServiceClient)
        {
            FinanceServiceClient = financeServiceClient;
            Shareholders = new Shareholders();
        }

        public void PrintShortStanding()
        {
            Console.WriteLine($"Aktueller Stand im Aktienspiel vom {DateTime.Today}." + Environment.NewLine);
            foreach (var portfolio in Shareholders.ListOfShareholders)
            {
                Console.WriteLine($"Portfolio von {portfolio.NameOfOwner}");
                double portfolioPerformance = 0;
                foreach (var stock in portfolio.Stocks)
                {
                    var output = $"-> Aktie: {stock.StockName} | Symbol: {stock.Symbol} | Wert am 30.12.2020: {stock.StockPriceStart} " +
                        $"| Wert am {stock.StockValues.Last().Key}: {stock.StockValues.Last().Value} | Prozentuale Veränderung: {stock.StockRelativeValues.Last().Value}%";
                    Console.WriteLine(output);
                    portfolioPerformance += stock.StockRelativeValues.Last().Value;
                }
                Console.WriteLine($"Performance des gesamten Portfolios: {portfolioPerformance}%" + Environment.NewLine);
            }
        }

        public async Task<bool> InitializePortfolios()
        {
            foreach (var portfolio in Shareholders.ListOfShareholders)
            {
                foreach (var stock in portfolio.Stocks)
                {
                    stock.StockValues = await FinanceServiceClient.GetPerformanceThisYear(stock.Symbol);
                    stock.StockPriceStart = stock.StockValues[DateTime.Parse("30.12.2020")];
                    stock.StockRelativeValues = CalculateRelativeValues(stock.StockPriceStart, stock.StockValues);
                }
            }
            return true;
        }

        private IDictionary<DateTime, double> CalculateRelativeValues(double stockPriceStart, IDictionary<DateTime, double> absolutValues)
        {
            return absolutValues.ToDictionary(dict => dict.Key, dict => 100 - stockPriceStart / dict.Value * 100);
        }
    }
}
