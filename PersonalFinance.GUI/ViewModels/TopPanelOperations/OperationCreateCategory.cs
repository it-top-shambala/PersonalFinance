using System;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class OperationCreateCategory : OperationAbstract
    {
        public bool IsIncome { get; set; }
        public bool IsExpence { get; set; }

        public OperationCreateCategory(Action action) : base(action)
        {
            IsIncome = true;
            IsExpence = false;
        }

        public override void Create()
        {
            Clear();
            var type = IsIncome;
            //Financier.CreateCategory(Name, type);

            //Category CreateCategory(string name, bool type)
        }
    }
}
