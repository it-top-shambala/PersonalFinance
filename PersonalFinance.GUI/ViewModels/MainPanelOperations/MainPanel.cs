using System;
using System.Windows;
using PersonalFinance.GUI.Models;
using PersonalFinance.GUI.ViewModels.Commands;

namespace PersonalFinance.GUI.ViewModels.MainPanelOperations
{
    public class MainPanel : Notifier
    {
        public OperationMaker OperationMaker { get; set; }

        public MyCommand CommandFilterByCategory { get; }

        public MyCommand CommandShowAllOperations { get; }

        public MyCommand CommandMakeOperationIncome { get; }

        public MyCommand CommandMakeOperationExpense { get; }

        private int _filterCount;
        public int FilterCount
        {
            get => _filterCount;
            set
            {
                _ = SetField(ref _filterCount, value);
                AllOperationsButtonVisibility = _filterCount == 0 ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private Visibility _allOperationsButtonVisibility;
        public Visibility AllOperationsButtonVisibility
        {
            get => _allOperationsButtonVisibility;
            set => SetField(ref _allOperationsButtonVisibility, value);
        }

        public MainPanel(Action<int> allOperations, Action<int, int> filteredOperations, Action<MyWallet, int, double> makeOperation)
        {
            OperationMaker = new(() => { CommandFilterByCategory?.OnCanExecuteChanged(); },
                () => { CommandMakeOperationIncome?.OnCanExecuteChanged(); },
                () => { CommandMakeOperationExpense?.OnCanExecuteChanged(); },
                allOperations, filteredOperations, makeOperation);

            CommandFilterByCategory = new(_ =>
            {
                OperationMaker.FilterByCategory();
                FilterCount++;
            }, _ => OperationMaker.CanFilter());

            CommandMakeOperationIncome = new(_ =>
            {
                OperationMaker.MakeOperation();
            }, _ => OperationMaker.CanMakeOperationIncome());

            CommandMakeOperationExpense = new(_ =>
            {
                OperationMaker.MakeOperation();
            }, _ => OperationMaker.CanMakeOperationExpense());

            CommandShowAllOperations = new(_ =>
            {
                FilterCount = 0;
                OperationMaker.AllOperations();
            }, _ => true);

            FilterCount = 0;
        }
    }
}
