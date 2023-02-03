using System;
using PersonalFinance.GUI.Models;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels.MainPanelOperations
{
    public class OperationMaker : Notifier
    {
        private readonly Action _canFilter;
        private readonly Action _canMakeOperation;
        private readonly Action<int> _allOperations;
        private readonly Action<int, int> _filteredOperations;
        private readonly Action<MyWallet, int, double> _makeOperation;

        private MyWallet? _selectedWallet;
        public MyWallet? SelectedWallet
        {
            get => _selectedWallet;
            set
            {
                _ = SetField(ref _selectedWallet, value);
                if (_selectedWallet != null)
                {
                    _allOperations.Invoke(_selectedWallet.WalletId);
                }
                _canFilter.Invoke();
                _canMakeOperation.Invoke();
            }
        }

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
                    SelectedCategoryExpense = null;
                    SumExpense = null;
                }
                _canMakeOperation.Invoke();
            }
        }

        private string? _sumIncome;
        public string? SumIncome
        {
            get => _sumIncome;
            set
            {
                if (value is not null)
                {
                    SumFormatter.RemoveLettersOrSymbols(ref value);
                    SumFormatter.Cut(ref value);
                }
                _sumIncome = value;
                OnPropertyChanged();
                if (value is not null)
                {
                    SelectedCategoryExpense = null;
                    SumExpense = null;
                }
                _canMakeOperation.Invoke();
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
                    SelectedCategoryIncome = null;
                    SumIncome = null;
                }
                _canMakeOperation.Invoke();
            }
        }

        private string? _sumExpense;
        public string? SumExpense
        {
            get => _sumExpense;
            set
            {
                if (value is not null)
                {
                    SumFormatter.RemoveLettersOrSymbols(ref value);
                    SumFormatter.Cut(ref value);
                }
                _sumExpense = value;
                OnPropertyChanged();
                if (value is not null)
                {
                    SelectedCategoryIncome = null;
                    SumIncome = null;
                }
                _canMakeOperation.Invoke();
            }
        }

        private Category? _filterCategory;
        public Category? FilterCategory
        {
            get => _filterCategory;
            set
            {
                _filterCategory = value;
                OnPropertyChanged();
                if (value is not null)
                {
                    SelectedCategoryIncome = null;
                }
                _canFilter.Invoke();
            }
        }

        public OperationMaker(Action canFilter, Action canMakeOperation, Action<int> allOperations, Action<int, int> filteredOperations, Action<MyWallet, int, double> makeOperation)
        {
            _canFilter = canFilter;
            _canMakeOperation = canMakeOperation;
            _allOperations = allOperations;
            _filteredOperations = filteredOperations;
            _makeOperation = makeOperation;
        }

        public void FilterByCategory()
        {
            if (SelectedCategoryIncome is not null)
            {
                _filteredOperations.Invoke(_selectedWallet!.WalletId, SelectedCategoryIncome.CategoryId);
            }
            else
            {
                _filteredOperations.Invoke(_selectedWallet!.WalletId, SelectedCategoryExpense!.CategoryId);
            }
            Clear();
        }

        public bool CanFilter()
        {
            return SelectedWallet is not null && FilterCategory is not null;
        }

        public void MakeOperation()
        {
            var categoryId = SelectedCategoryIncome is not null ? SelectedCategoryIncome.CategoryId : SelectedCategoryExpense!.CategoryId;
            var sum = SumIncome is not null ? double.Parse(SumIncome!, System.Globalization.CultureInfo.InvariantCulture) : -double.Parse(SumExpense!, System.Globalization.CultureInfo.InvariantCulture);
            _makeOperation.Invoke(SelectedWallet!, categoryId, sum);
            Clear();
        }

        public bool CanMakeOperaton()
        {
            return (SelectedWallet is not null && SelectedCategoryIncome is not null && SumIncome is not null) ||
                   (SelectedWallet is not null && SelectedCategoryExpense is not null && SumExpense is not null && (SelectedWallet.Balance - double.Parse(SumExpense!, System.Globalization.CultureInfo.InvariantCulture) >= 0));
        }

        private void Clear()
        {
            SelectedCategoryIncome = SelectedCategoryExpense = null;
            SumIncome = SumExpense = null;
        }
    }
}
