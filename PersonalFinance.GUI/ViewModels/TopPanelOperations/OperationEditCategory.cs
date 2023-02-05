using System;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class OperationEditCategory : OperationAbstract
    {
        private readonly Action<Category, Category, string> _editCategory;

        private Category? _categoryIncome;
        public Category? SelectedCategoryIncome
        {
            get => _categoryIncome;
            set
            {
                _categoryIncome = value;
                OnPropertyChanged();
                if (value is not null)
                {
                    Name = _categoryIncome?.Name;
                    SelectedCategoryExpense = null;
                }
            }
        }

        private Category? _categoryExpense;
        public Category? SelectedCategoryExpense
        {
            get => _categoryExpense;
            set
            {
                _categoryExpense = value;
                OnPropertyChanged();
                if (value is not null)
                {
                    Name = _categoryExpense?.Name;
                    SelectedCategoryIncome = null;
                }
            }
        }

        public OperationEditCategory(Action action, Action<Category, Category, string> editCategory) : base(action)
        {
            _editCategory = editCategory;
        }

        public override bool RefreshState()
        {
            return !string.IsNullOrWhiteSpace(Name) && (SelectedCategoryIncome is not null || SelectedCategoryExpense is not null);
        }

        public override void Create()
        {
            _editCategory.Invoke(SelectedCategoryIncome!, SelectedCategoryExpense!, Name!);
            Clear();
        }

        protected override void Clear()
        {
            Name = string.Empty;
            SelectedCategoryIncome = null;
            SelectedCategoryExpense = null;
        }
    }
}
