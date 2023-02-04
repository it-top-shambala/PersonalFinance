using System;
using PersonalFinance.GUI.Models;
using PersonalFinance.GUI.ViewModels.Commands;

namespace PersonalFinance.GUI.ViewModels.MainPanelOperations
{
    public class MainPanel
    {
        public OperationMaker OperationMaker { get; set; }

        public MyCommand CommandFilterByCategory { get; }

        public MyCommand CommandMakeOperationIncome { get; }

        public MyCommand CommandMakeOperationExpense { get; }

        public MainPanel(Action<int> allOperations, Action<int, int> filteredOperations, Action<MyWallet, int, double> makeOperation)
        {
            OperationMaker = new(() => { CommandFilterByCategory?.OnCanExecuteChanged(); },
                () => { CommandMakeOperationIncome?.OnCanExecuteChanged(); },
                () => { CommandMakeOperationExpense?.OnCanExecuteChanged(); },
                allOperations, filteredOperations, makeOperation);

            CommandFilterByCategory = new(_ =>
            {
                OperationMaker.FilterByCategory();
            }, _ => OperationMaker.CanFilter());

            CommandMakeOperationIncome = new(_ =>
            {
                OperationMaker.MakeOperation();
            }, _ => OperationMaker.CanMakeOperationIncome());

            CommandMakeOperationExpense = new(_ =>
            {
                OperationMaker.MakeOperation();
            }, _ => OperationMaker.CanMakeOperationExpense());
        }
    }
}
