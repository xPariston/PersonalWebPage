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
                            Symbol = "NVD.DE",
                            StockName = "Nvidia"
                        },
                        new Stock
                        {
                            Symbol = "KLIC",
                            StockName = "Kulicke and Soffa Industries"
                        },
                        new Stock
                        {
                            Symbol = "KNBE",
                            StockName = "KnowBe4"
                        },
                        new Stock
                        {
                            Symbol = "PYPL",
                            StockName = "PayPal"
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
                            Symbol = "DAI.DE",
                            StockName = "Daimler AG"
                        },
                        new Stock
                        {
                            Symbol = "APC.DE",
                            StockName = "Apple"
                        },
                        new Stock
                        {
                            Symbol = "NVD.DE",
                            StockName = "Nvidia"
                        },
                        new Stock
                        {
                            Symbol = "DEZ.DE",
                            StockName = "Deutz AG"
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
                            Symbol = "PFE.DE",
                            StockName = "Pfizer"
                        },
                        new Stock
                        {
                            Symbol = "MSF.DE",
                            StockName = "Microsoft"
                        },
                        new Stock
                        {
                            Symbol = "TUIFF",
                            StockName = "TUI"
                        },
                        new Stock
                        {
                            Symbol = "SEMHF",
                            StockName = "Siemens Healthineers"
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
                            Symbol = "ZLPSF",
                            StockName = "Zooplus"
                        },
                        new Stock
                        {
                            Symbol = "ELG.DE",
                            StockName = "Elmos Saniconductor"
                        },
                        new Stock
                        {
                            Symbol = "SRT.DE",
                            StockName = "Sartorious"
                        },
                        new Stock
                        {
                            Symbol = "APC.DE",
                            StockName = "Apple"
                        }
                    }
                }
            };
        }
    }
}
