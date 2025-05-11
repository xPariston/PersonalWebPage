using System.Collections.Generic;

namespace FamilyStockBet.Contracts
{
    public class Shareholders
    {
        public List<Portfolio> ListOfPortfolios;
        public Shareholders()
        {
            ListOfPortfolios = new List<Portfolio>()
            {
                new Portfolio
                {
                    NameOfOwner = "Gunnar",
                    Stocks= new List<Stock>
                    {
                        new Stock
                        {
                            Symbol = "BYDDF",
                            StockName = "Byd Company"
                        },
                        new Stock
                        {
                            Symbol = "LQAG.DEX",
                            StockName = "Laiqon"
                        },
                        new Stock
                        {
                            Symbol = "FYB.DEX",
                            StockName = "Formycon"
                        },
                        new Stock
                        {
                            Symbol = "M12.DEX",
                            StockName = "M1 Kliniken"
                        }
                    }
                },
                new Portfolio
                {
                    NameOfOwner = "Claudia",
                    Stocks= new List<Stock>
                    {
                        new Stock
                        {
                            Symbol = "FSXLF",
                            StockName = "Great Pacific Gold"
                        },
                        new Stock
                        {
                            Symbol = "BIRK",
                            StockName = "Birkenstock"
                        },
                        new Stock
                        {
                            Symbol = "DB1.DEX",
                            StockName = "Deutsche Börse"
                        },
                        new Stock
                        {
                            Symbol = "GIDMF",
                            StockName = "Nexus Uranium"
                        },
                    }
                },
                new Portfolio
                {
                    NameOfOwner = "Paul",
                    Stocks= new List<Stock>
                    {
                        new Stock
                        {
                            Symbol = "NVS",
                            StockName = "Novartis AG"
                        },
                        new Stock
                        {
                            Symbol = "NVDA",
                            StockName = "NVIDIA"
                        },
                        new Stock
                        {
                            Symbol = "META",
                            StockName = "Meta"
                        },
                        new Stock
                        {
                            Symbol = "EADSF",
                            StockName = "Airbus"
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
                            Symbol = "FICO",
                            StockName = "Fair Isaac"
                        },
                        new Stock
                        {
                            Symbol = "AMZN",
                            StockName = "Amazon"
                        },
                        new Stock
                        {
                            Symbol = "ENGQF",
                            StockName = "Engie"
                        },
                        new Stock
                        {
                            Symbol = "INTC",
                            StockName = "Intel"
                        }
                    }
                },
            };
        }
    }
}
