using System;
using PersonalFinance.GUI.Models;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels.MainPanelOperations
{
    public class OperationViewer : Notifier
    {
        private readonly Action<int> _allOperations;
        private readonly Action<int, int> _filteredOperations;

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
                    SelectedCategoryIncome = null;
                }
            }
        }

        public OperationViewer(Action<int> allOperations, Action<int, int> filteredOperations)
        {
            _allOperations = allOperations;
            _filteredOperations = filteredOperations;
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
        }

        public bool RefreshStates()
        {
            return SelectedWallet is not null && (SelectedCategoryIncome is not null || SelectedCategoryExpense is not null);
        }
    }
}
