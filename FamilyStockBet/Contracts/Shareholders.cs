using System.Collections.Generic;

namespace FamilyStockBet.Contracts
{
    public class Shareholders
    {
        public List<Portfolio> ListOfShareholders;
        public Shareholders()
        {
            ListOfShareholders = new List<Portfolio>()
            {
                new Portfolio
                {
                    NameOfOwner = "Gunnar",
                    Stocks= new List<Stock>
                    {
                        new Stock
                        {
                            Symbol = "BA",
                            StockName = "Boeing"
                        },
                        new Stock
                        {
                            Symbol = "HOT.DE",
                            StockName = "Hochtief"
                        },
                        new Stock
                        {
                            Symbol = "BAYN.DE",
                            StockName = "Bayer"
                        }
                    }
                },
                new Portfolio
                {
                    NameOfOwner = "Paul",
                    Stocks= new List<Stock>
                    {
                        new Stock
                        {
                            Symbol = "EJTTF",
                            StockName = "easyJet"
                        },
                        new Stock
                        {
                            Symbol = "R6C.DE",
                            StockName = "Shell"
                        },
                        new Stock
                        {
                            Symbol = "CCL",
                            StockName = "Carnival"
                        }
                    }
                },
                new Portfolio
                {
                    NameOfOwner = "Patrick",
                    Stocks= new List<Stock>
                    {
                        new Stock
                        {
                            Symbol = "ORCL",
                            StockName = "Oracle"
                        },
                        new Stock
                        {
                            Symbol = "B4B.DE",
                            StockName = "Metro"
                        },
                        new Stock
                        {
                            Symbol = "ASL.DE",
                            StockName = "Akasol"
                        }
                    }
                }
            };
        }
    }
}
