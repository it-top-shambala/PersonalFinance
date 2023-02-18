using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PersonalFinance.GUI.Models;
using PersonalFinance.Lib.BL;
using PersonalFinance.Lib.DAL;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels
{
    public class AllData
    {
        public ObservableCollection<MyWallet> Wallets { get; set; }

        public ObservableCollection<Category> CategoriesIncome { get; set; }
        public ObservableCollection<Category> CategoriesExpense { get; set; }
        public ObservableCollection<Category>? AllCategories { get; set; }

        public List<Currency> Currencies { get; set; }

        public ObservableCollection<Operation>? Operations { get; set; }

        private readonly Financier _db;

        public AllData()
        {
            _db = new(new PersonalFinanceDbContext());

            var list = _db.GetAllWallets();
            Wallets = new ObservableCollection<MyWallet>();
            var backgrounds = WalletBackgroundSaver.Load();
            foreach (var item in list)
            {
                var myWallet = new MyWallet(item);
                myWallet.Background = backgrounds.Find(b => b.Id == myWallet.WalletId).Path;
                Wallets.Add(myWallet);
            }

            var (income, expense) = _db.GetAllCategories();

            CategoriesIncome = new ObservableCollection<Category>(income);
            CategoriesExpense = new ObservableCollection<Category>(expense);
            Currencies = _db.GetAllCurrencies().ToList();

            AllCategories = new();

            AllCategoriesInit();

            Operations = new();

            ////для теста
            //Wallets = new ObservableCollection<MyWallet>();

            //CategoriesIncome = new ObservableCollection<Category>() { new Category { CategoryId = 1, Name = "Зарплата", Type = true } };
            //CategoriesExpense = new ObservableCollection<Category>() { new Category { CategoryId = 2, Name = "Продукты", Type = false } };

            //Currencies = new List<Currency> { new Currency { CurrencyId = 1, Code = "111", Name = "USD" } };

            //Operations = new() { new Operation { OperationId = 1, CategoryName = "Зарплата", Summa = 1000, WalletId = 1, DateTime = DateTime.Now } };
        }
        public void AddWallet(string name, Currency currency, double sum, string background)
        {
            var newWallet = new MyWallet(_db.CreateWallet(name, currency, sum)!)
            {
                Background = background
            };
            WalletBackgroundSaver.Save(newWallet.WalletId, background);
            Wallets.Add(newWallet);

            ////для теста
            //var newWallet = new MyWallet
            //{
            //    WalletId = Wallets.Count == 0 ? 1 : Wallets[^1].WalletId + 1,
            //    Name = name,
            //    Balance = sum,
            //    CurrencyName = currency.Name,
            //    Background = background
            //};
            //Wallets.Add(newWallet);
            //WalletBackgroundSaver.Save(newWallet.WalletId, background);
        }

        public void EditWallet(MyWallet wallet, string newName)
        {
            var updatedWallet = new MyWallet(_db.EditWalletName(wallet.WalletId, newName))
            {
                Background = wallet.Background
            };
            var index = Wallets.IndexOf(wallet);
            Wallets[index] = updatedWallet;

            ////для теста
            //var newWallet = new MyWallet
            //{
            //    WalletId = wallet.WalletId,
            //    Name = newName,
            //    Balance = wallet.Balance,
            //    CurrencyName = wallet.CurrencyName,
            //    Background = wallet.Background
            //};
            //var index = Wallets.IndexOf(wallet);
            //Wallets[index] = newWallet;
        }

        public void AddCategory(string name, bool type)
        {
            var newCategory = _db.CreateCategory(name, type);
            if (type)
            {
                CategoriesIncome.Add(newCategory!);
            }
            else
            {
                CategoriesExpense.Add(newCategory!);
            }
            AllCategoriesInit();
        }

        public void EditCategory(Category income, Category expense, string newName)
        {
            if (income is not null)
            {
                _db.EditCategoryName(income.CategoryId, newName);
                var category = new Category { CategoryId = income.CategoryId, CategoryName = newName, Type = income.Type };
                var index = CategoriesIncome.IndexOf(income);
                CategoriesIncome[index] = category;
            }
            else
            {
                _db.EditCategoryName(expense.CategoryId, newName);
                var category = new Category { CategoryId = expense.CategoryId, CategoryName = newName, Type = expense.Type };
                var index = CategoriesExpense.IndexOf(expense);
                CategoriesExpense[index] = category;
            }
            AllCategoriesInit();
        }

        public void ShowAllOperations(int walletId)
        {
            Operations!.Clear();
            foreach (var o in _db.GetAllWalletOperations(walletId).ToList())
            {
                Operations.Add(o);
            }
        }

        public void ShowFilteredOperations(int walletId, int categoryId)
        {
            Operations!.Clear();
            foreach (var o in _db.GetFilteredWalletOperations(walletId, categoryId).ToList())
            {
                Operations.Add(o);
            }
        }

        public void MakeOperation(MyWallet wallet, int categoryId, double sum)
        {
            var result = _db.MakeWalletOperation(wallet.WalletId, categoryId, sum);
            Operations!.Add(result.operation);
            var updatedWallet = new MyWallet(result.wallet)
            {
                Background = wallet.Background
            };
            var index = Wallets.IndexOf(wallet);
            Wallets[index] = updatedWallet;
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

            AllCategories!.Clear();

            foreach (var c in list.OrderBy(c => c.CategoryName).ToList())
            {
                AllCategories.Add(c);
            }
        }
    }
}
