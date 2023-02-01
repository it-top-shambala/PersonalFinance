using System;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class OperationCreateCategory : OperationAbstract
    {
        public bool IsIncome { get; set; }
        public bool IsExpense { get; set; }

        private readonly Action<string, bool> _addCategory;

        public OperationCreateCategory(Action action, Action<string, bool> addCategory) : base(action)
        {
            IsIncome = true;
            IsExpense = false;
            _addCategory = addCategory;
        }

        public override void Create()
        {
            _addCategory.Invoke(Name!, IsIncome);
            Clear();
        }
    }
}
