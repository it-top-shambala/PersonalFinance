using System;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class OperationCreateIncomeCategory : OperationAbstract
    {
        public OperationCreateIncomeCategory(Action action) : base(action) { }

        public override void Create()
        {
            Clear();
            //используем метод для создания(добавления) новой категории
        }
    }
}
