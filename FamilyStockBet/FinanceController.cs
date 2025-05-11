using FamilyStockBet.Client;
using FamilyStockBet.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyStockBet
{
    public class FinanceController
    {
        public Shareholders Shareholders { get; set; }
        public IFinanceServiceClient FinanceServiceClient { get; set; }

        public FinanceController(IFinanceServiceClient financeServiceClient)
        {
            FinanceServiceClient = financeServiceClient;
            Shareholders = new Shareholders();
        }

        public void PrintShortStanding()
        {
            Console.WriteLine($"Aktueller Stand im Aktienspiel vom {DateTime.Today}." + Environment.NewLine);
            foreach (var portfolio in Shareholders.ListOfPortfolios)
            {
                Console.WriteLine($"Portfolio von {portfolio.NameOfOwner}");
                double portfolioPerformance = 0;
                foreach (var stock in portfolio.Stocks)
                {
                    var output = $"-> Aktie: {stock.StockName} | Symbol: {stock.Symbol} | Wert am 01.01.: {stock.StockPriceStart} " +
                        $"| Wert am {stock.StockValues.Last().Key}: {stock.StockValues.Last().Value} | Prozentuale Veränderung: {stock.StockRelativeValues.Last().Value}%";
                    Console.WriteLine(output);
                    portfolioPerformance += stock.StockRelativeValues.Last().Value;
                }
                Console.WriteLine($"Performance des gesamten Portfolios: {portfolioPerformance}%" + Environment.NewLine);
            }
        }

        public async Task<bool> InitializePortfolios()
        {
            foreach (var portfolio in Shareholders.ListOfPortfolios)
            {
                foreach (var stock in portfolio.Stocks)
                {
                    try
                    {
                        stock.StockValues = await FinanceServiceClient.GetPerformanceThisYear(stock.Symbol);
                        stock.StockPriceStart = stock.StockValues.Values.First();
                        stock.StockRelativeValues = CalculateRelativeValues(stock.StockPriceStart, stock.StockValues, stock.Symbol);
                        stock.StockLastRelativeValues = stock.StockRelativeValues[stock.StockRelativeValues.Keys.Max()];
                    }
                    catch (Exception)
                    {
                    }
                }

                portfolio.StockRelativeMeans = CalculateRelativeMeans(portfolio, false);
                portfolio.StockLastRelativeMean = portfolio.StockRelativeMeans[portfolio.StockRelativeMeans.Keys.Max()];
                portfolio.StockRelativeMeansWithStreicher = CalculateRelativeMeans(portfolio, true);
                portfolio.StockLastRelativeMeanWithStreicher = portfolio.StockRelativeMeansWithStreicher[portfolio.StockRelativeMeansWithStreicher.Keys.Max()];
            }
            return true;
        }

        private Dictionary<DateTime, double> CalculateRelativeMeans(Portfolio portfolio, bool withStreicher)
        {
            var dataItemList = new List<KeyValuePair<DateTime, double>>();

            var lowestValue = portfolio.Stocks
                .Select(stock => stock.StockRelativeValues.Values.Last())
                .Min();
            var lowestValuedStock = portfolio.Stocks
                .Where(stock => stock.StockRelativeValues.Values.Last() == lowestValue)
                .Single();

            foreach (var stock in portfolio.Stocks)
            {
                if (withStreicher && stock == lowestValuedStock)
                {
                    continue;
                }
                dataItemList = dataItemList.Concat(stock.StockRelativeValues).ToList();
            }

            var dataItemDictMeans = new Dictionary<DateTime, double>();

            foreach (var date in portfolio.Stocks.First().StockRelativeValues.Keys)
            {
                if (dataItemList.Where(x => x.Key == date).Count() == (withStreicher ? 3 : 4))
                {
                    dataItemDictMeans[date] = dataItemList
                        .Where(t => t.Key == date)
                        .Average(t => t.Value);
                }
            }
            return dataItemDictMeans;
        }

        private IDictionary<DateTime, double> CalculateRelativeValues(double stockPriceStart, IDictionary<DateTime, double> absolutValues, string symbol = null)
        {
            if (symbol == "NVDA")
            {
                return absolutValues.ToDictionary(dict => dict.Key, dict => 
                    {
                        if (dict.Value <= 400)
                        {
                            return (dict.Value * 10 / stockPriceStart * 100) - 100;
                        }
                        return (dict.Value / stockPriceStart * 100) - 100; 
                    } 
                );
            }

            return absolutValues.ToDictionary(dict => dict.Key, dict =>  (dict.Value / stockPriceStart * 100) - 100);
        }
    }
}
