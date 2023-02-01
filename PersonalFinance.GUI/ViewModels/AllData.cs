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
            //для теста
            Wallets = new ObservableCollection<MyWallet> { new MyWallet
            {
                WalletId = 1, Balance = 1000000, CurrencyName = "USD", Name = "Кошелёк Барсика", Background = "Assets/Backgrounds/2.jpg"
            } };

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

            CategoriesIncome = new List<Category>() { new Category { CategoryId = 1, Name = "На пивко", Type = false } };
            CategoriesExpense = new List<Category>() { new Category { CategoryId = 2, Name = "Зарплата", Type = true } };
            //используем методы получения категорий

            Currencies = new List<Currency> { new Currency { CurrencyId = 1, Code = 111, Name = "USD" } };
            //используем метод получения валют
        }

        public void AddCategoryIncome(Category newCategory)
        {
            CategoriesIncome.Add(newCategory);
        }

        public void AddCategoryExpense(Category newCategory)
        {
            CategoriesExpense.Add(newCategory);
        }

        public void AddWallet(MyWallet newWallet)
        {
            Wallets.Add(newWallet);
        }


    }
}
