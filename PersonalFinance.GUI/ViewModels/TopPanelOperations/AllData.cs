using System.Collections.Generic;
using System.Collections.ObjectModel;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class AllData
    {
        public ObservableCollection<Wallet> Wallets { get; set; }

        public List<Category> CategoriesIncome { get; set; }
        public List<Category> CategoriesExpense { get; set; }

        public AllData()
        {
            Wallets = new ObservableCollection<Wallet> { new Wallet { WalletId = 1, Balance = 1000000, CurrencyName = "USD", Name = "На корм котику" } };
            //используем метод получения кошельков
            //наследоваться от Wallet (добавить путь в картинке и буквенный код валюты)

            CategoriesIncome = new List<Category>() { new Category { CategoryId = 1, Name = "На пивко", Type = false } };
            CategoriesExpense = new List<Category>() { new Category { CategoryId = 2, Name = "Зарплата", Type = true } };
            //используем методы получения категорий
        }

        public void AddCategoryIncome(Category newCategory)
        {
            CategoriesIncome.Add(newCategory);
        }

        public void AddCategoryExpense(Category newCategory)
        {
            CategoriesExpense.Add(newCategory);
        }


    }
}
