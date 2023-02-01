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
            Name = wallet.Name;
            CurrencyName = wallet.CurrencyName;
            Balance = wallet.Balance;
        }
    }
}
