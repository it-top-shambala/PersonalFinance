using System.Collections.Generic;
using System.Collections.ObjectModel;
using PersonalFinance.GUI.Models;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels
{
    public class AllData
    {
        public ObservableCollection<MyWallet> Wallets { get; set; }

        public List<Category> CategoriesIncome { get; set; }
        public List<Category> CategoriesExpense { get; set; }

        public List<Currency> Currencies { get; set; }

        public AllData()
        {
            //используем метод получения кошельков
            //var list = Financier.GetAllWallets();
            //Wallets = new ObservableCollection<MyWallet>();
            //var backgrounds = WalletBackgroundSaver.Load();
            //foreach(var item in list)
            //{
            //    var myWallet = new MyWallet(item);
            //    myWallet.Background = backgrounds.Find(b => b.Id == myWallet.WalletId).Path;
            //    Wallets.Add(myWallet);
            //}

            //используем методы получения категорий
            //var categories = Financier.GetAllCategories().ToList();
            //CategoriesIncome = categories.Income;
            //CategoriesExpense = categories.Expense;

            //используем метод получения валют
            //Currencies = Financier.GetAllCurrencies().ToList();

            //для теста
            Wallets = new ObservableCollection<MyWallet> { new MyWallet
            {
                WalletId = 1, Balance = 1000000, CurrencyName = "USD", Name = "Кошелёк Барсика", Background = "Assets/Backgrounds/2.jpg"
            } };

            CategoriesIncome = new List<Category>() { new Category { CategoryId = 1, Name = "На пивко", Type = false } };
            CategoriesExpense = new List<Category>() { new Category { CategoryId = 2, Name = "Зарплата", Type = true } };

            Currencies = new List<Currency> { new Currency { CurrencyId = 1, Code = 111, Name = "USD" } };
        }

        public void AddCategory(string name, bool type)
        {
            //var newCategory = Financier.CreateCategory(name, type);
            //if (type)
            //{
            //    CategoriesIncome.Add(newCategory);
            //}
            //else
            //{
            //    CategoriesExpense.Add(newCategory);
            //}
        }

        public void AddWallet(string name, Currency currency, double sum, string background)
        {
            //var newWallet = new MyWallet(Financier.CreateWallet(name, currency, sum));
            //newWallet.Background = background;
            //WalletBackgroundSaver.Save(newWallet.WalletId, background);
            //Wallets.Add(newWallet);
        }
    }
}
