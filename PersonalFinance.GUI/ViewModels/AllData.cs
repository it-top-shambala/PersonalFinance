using System.Collections.Generic;
using System.Collections.ObjectModel;
using PersonalFinance.GUI.Models;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels
{
    public class AllData
    {
        public ObservableCollection<MyWallet> Wallets { get; set; }

        public ObservableCollection<Category> CategoriesIncome { get; set; }
        public ObservableCollection<Category> CategoriesExpense { get; set; }

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
            //CategoriesIncome = new ObservableCollection<Category>(categories.Income);
            //CategoriesExpense = new ObservableCollection<Category>(categories.Expense);

            //используем метод получения валют
            //Currencies = Financier.GetAllCurrencies().ToList();

            //для теста
            Wallets = new ObservableCollection<MyWallet> { new MyWallet
            {
                WalletId = 1, Balance = 1000000, CurrencyName = "USD", Name = "Кошелёк Барсика", Background = "Assets/Backgrounds/2.jpg"
            } };

            CategoriesIncome = new ObservableCollection<Category>() { new Category { CategoryId = 1, Name = "Зарплата", Type = true } };
            CategoriesExpense = new ObservableCollection<Category>() { new Category { CategoryId = 2, Name = "На пивко", Type = false } };

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

        public void EditCategory(Category income, Category expense, string name)
        {
            if (income is not null)
            {
                //Financier.EditCategoryName(income.CategoryId, name);
                var category = new Category { CategoryId = income.CategoryId, Name = name, Type = income.Type };
                var index = CategoriesIncome.IndexOf(income);
                CategoriesIncome[index] = category;
            }
            else
            {
                //Financier.EditCategoryName(expense.CategoryId, name);
                var category = new Category { CategoryId = expense.CategoryId, Name = name, Type = expense.Type };
                var index = CategoriesExpense.IndexOf(expense);
                CategoriesExpense[index] = category;
            }
        }
    }
}
