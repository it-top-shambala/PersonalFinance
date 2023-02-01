using System;
using System.Runtime.Serialization;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class OperationCreateCategory : OperationAbstract
    {
        public bool IsIncome { get; set; }
        public bool IsExpense { get; set; }

        private readonly Action<Category> _addCategoryIncome;
        private readonly Action<Category> _addCategoryExpense;

        public OperationCreateCategory(Action action, Action<Category> addCategoryIncome, Action<Category> addCategoryExpense) : base(action)
        {
            IsIncome = true;
            IsExpense = false;
            _addCategoryIncome = addCategoryIncome;
            _addCategoryExpense = addCategoryExpense;
        }

        public override void Create()
        {
            Clear();
            var type = IsIncome;
            //var newCategory = Financier.CreateCategory(Name, type);
            //if (type)
            //{
            //    _addCategoryIncome.Invoke(newCategory);
            //}
            //else
            //{
            //    _addCategoryExpense.Invoke(newCategory);
            //}
        }
    }
}
