using System;
using PersonalFinance.GUI.Models;
using PersonalFinance.GUI.ViewModels.Commands;

namespace PersonalFinance.GUI.ViewModels.MainPanelOperations
{
    public class MainPanel
    {
        public OperationMaker OperationMaker { get; set; }

        public MyCommand CommandFilterByCategory { get; }

        public MyCommand CommandMakeOperation { get; }

        public MainPanel(Action<int> allOperations, Action<int, int> filteredOperations, Action<MyWallet, int, double> makeOperation)
        {
            OperationMaker = new(() => { CommandFilterByCategory?.OnCanExecuteChanged(); },
                () => { CommandMakeOperation?.OnCanExecuteChanged(); },
                allOperations, filteredOperations, makeOperation);

            CommandFilterByCategory = new(_ =>
            {
                OperationMaker.FilterByCategory();
            }, _ => OperationMaker.CanFilter());

            CommandMakeOperation = new(_ =>
            {
                OperationMaker.MakeOperation();
            }, _ => OperationMaker.CanMakeOperaton());
        }
    }
}
