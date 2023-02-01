using System.Collections.ObjectModel;
using PersonalFinance.GUI.ViewModels.TopPanelOperations;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels
{
    public class MainWindowViewModel : Notifier
    {
        public TopPanel TopPanel { get; set; }

        public ObservableCollection<Wallet> Wallets { get; set; }

        public MainWindowViewModel()
        {
            TopPanel = new();
            Wallets = new ObservableCollection<Wallet> { new Wallet { WalletId = 1, Balance = 1000000, CurrencyName = "USD", Name = "На корм котику" } };
            //используем метод получения кошельков
            //наследоваться от Wallet (добавить путь в картинке и буквенный код валюты)
        }
    }
}
