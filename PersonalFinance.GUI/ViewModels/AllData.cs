using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PersonalFinance.GUI.Models;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels
{
    public class AllData
    {
        public ObservableCollection<MyWallet> Wallets { get; set; }

        public ObservableCollection<Category> CategoriesIncome { get; set; }
        public ObservableCollection<Category> CategoriesExpense { get; set; }
        public List<Category>? AllCategories { get; set; }

        public List<Currency> Currencies { get; set; }

        public ObservableCollection<Operation>? Operations { get; set; }

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

            //CategoriesIncome = new ObservableCollection<Category>(categories.income);
            //CategoriesExpense = new ObservableCollection<Category>(categories.expense);
            //используем метод получения валют
            //Currencies = Financier.GetAllCurrencies().ToList();


            //для теста
            Wallets = new ObservableCollection<MyWallet>();

            CategoriesIncome = new ObservableCollection<Category>() { new Category { CategoryId = 1, Name = "Зарплата", Type = true } };
            CategoriesExpense = new ObservableCollection<Category>() { new Category { CategoryId = 2, Name = "На пивко", Type = false } };

            AllCategoriesInit();

            Currencies = new List<Currency> { new Currency { CurrencyId = 1, Code = 111, Name = "USD" } };

            Operations = new() { new Operation { OperationId = 1, CategoryName = "На пивко", Summa = 2000, WalletId = 1, DateTime = DateTime.Now } };
        }
        public void AddWallet(string name, Currency currency, double sum, string background)
        {
            //var newWallet = new MyWallet(Financier.CreateWallet(name, currency, sum));
            //newWallet.Background = background;
            //WalletBackgroundSaver.Save(newWallet.WalletId, background);
            //Wallets.Add(newWallet);

            //для теста
            var newWallet = new MyWallet
            {
                WalletId = Wallets.Count == 0 ? 1 : Wallets[^1].WalletId + 1,
                Name = name,
                Balance = sum,
                CurrencyName = currency.Name,
                Background = background
            };
            Wallets.Add(newWallet);
            WalletBackgroundSaver.Save(newWallet.WalletId, background);
        }

        public void EditWallet(MyWallet wallet, string newName)
        {
            //var updatedWallet = new MyWallet(Financier.EditWalletName(wallet.WalletId, newName));
            //updatedWallet.Background = wallet.Background;
            //var index = Wallets.IndexOf(wallet);
            //Wallets[index] = updatedWallet;

            //для теста
            var newWallet = new MyWallet
            {
                WalletId = wallet.WalletId,
                Name = newName,
                Balance = wallet.Balance,
                CurrencyName = wallet.CurrencyName,
                Background = wallet.Background
            };
            var index = Wallets.IndexOf(wallet);
            Wallets[index] = newWallet;
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
            AllCategoriesInit();
        }

        public void EditCategory(Category income, Category expense, string newName)
        {
            if (income is not null)
            {
                //Financier.EditCategoryName(income.CategoryId, name);
                var category = new Category { CategoryId = income.CategoryId, Name = newName, Type = income.Type };
                var index = CategoriesIncome.IndexOf(income);
                CategoriesIncome[index] = category;
            }
            else
            {
                //Financier.EditCategoryName(expense.CategoryId, name);
                var category = new Category { CategoryId = expense.CategoryId, Name = newName, Type = expense.Type };
                var index = CategoriesExpense.IndexOf(expense);
                CategoriesExpense[index] = category;
            }
        }

        public void ShowAllOperations(int walletId)
        {
            //Operations = new(Financier.GetAllWalletOperations(walletId));
        }

        public void ShowFilteredOperations(int walletId, int categoryId)
        {
            //Operations = new(Financier.GetFilteredWalletOperations(walletId, categoryName));
        }

        public void MakeOperation(MyWallet wallet, int categoryId, double sum)
        {
            //var result = Financier.MakeWalletOperation(wallet.WalletId, categoryId, sum);
            //Operations.Add(result.operation);
            //var updatedWallet = new MyWallet(result.wallet);
            //updatedWallet.Background = wallet.Background;
            //var index = Wallets.IndexOf(wallet);
            //Wallets[index] = updatedWallet;
        }

        private void AllCategoriesInit()
        {
            var list = new List<Category>();
            foreach (var c in CategoriesIncome)
            {
                list.Add(c);
            }
            foreach (var c in CategoriesExpense)
            {
                list.Add(c);
            }
            AllCategories = list.OrderBy(c => c.Name).ToList();
        }
    }
}
