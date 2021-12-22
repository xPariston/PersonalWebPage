using FamilyStockBet;
using FamilyStockBet.Client;
using System.Linq;

namespace PersonalWebPage.ViewModels
{
    public class FinanceViewModel
    {
        public FinanceController FinanceController { get; }

        public FinanceViewModel(IFinanceServiceClient financeServiceClient)
        {
            FinanceController = new FinanceController(financeServiceClient);
            InitializePortfolios();
        }

        public async void InitializePortfolios()
        {
            await FinanceController.InitializePortfolios();
        }
    }
}
