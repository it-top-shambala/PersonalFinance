using System;
using PersonalFinance.GUI.ViewModels.Commands;

namespace PersonalFinance.GUI.ViewModels.MainPanelOperations
{
    public class MainPanel
    {
        public OperationViewer OperationViewer { get; set; }
        public MyCommand CommandFilterByCategory { get; }

        public MainPanel(Action<int> allOperations, Action<int, int> filteredOperations)
        {
            OperationViewer = new(allOperations, filteredOperations);
            CommandFilterByCategory = new(_ =>
            {
                OperationViewer.FilterByCategory();
            }, _ => OperationViewer.RefreshStates());
        }
    }
}
