using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.Models
{
    public class MyWallet : Wallet
    {
        public string? Background { get; set; }

        public MyWallet() { }

        public MyWallet(Wallet wallet)
        {
            WalletId = wallet.WalletId;
            WalletName = wallet.WalletName;
            CurrencyName = wallet.CurrencyName;
            Balance = wallet.Balance;
        }

        public bool SumExceedsBalance(double sum)
        {
            return Balance - sum < 0;
        }
    }
}
