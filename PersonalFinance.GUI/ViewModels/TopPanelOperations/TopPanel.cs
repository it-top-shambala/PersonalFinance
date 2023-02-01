using PersonalFinance.GUI.ViewModels.Commands;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class TopPanel : Notifier
    {
        public OperationCreateWallet CreateWallet { get; set; }
        public MyCommand CommandOpenCloseCreateWallet { get; }
        public MyCommand CommandCreateWallet { get; }

        public OperationCreateIncomeCategory CreateIncomeCategory { get; set; }
        public MyCommand CommandOpenCloseCreateIncomeCategory { get; }
        public MyCommand CommandCreateIncomeCategory { get; }

        public OperationCreateExpenseCategory CreateExpenseCategory { get; set; }
        public MyCommand CommandOpenCloseCreateExpenseCategory { get; }
        public MyCommand CommandCreateExpenseCategory { get; }

        private int _height;
        public int Height
        {
            get => _height;
            set => SetField(ref _height, value);
        }

        public TopPanel()
        {
            CreateWallet = new(() => { CommandCreateWallet?.OnCanExecuteChanged(); });
            CommandOpenCloseCreateWallet = new(_ =>
            {
                CreateIncomeCategory?.Hide();
                CreateExpenseCategory?.Hide();
                Height = CreateWallet.OpenClose();
            }, _ => true);
            CommandCreateWallet = new(_ =>
            {
                CreateWallet.Create();
            }, _ => CreateWallet.RefreshStates());


            CreateIncomeCategory = new(() => { CommandCreateIncomeCategory?.OnCanExecuteChanged(); });
            CommandOpenCloseCreateIncomeCategory = new(_ =>
            {
                CreateExpenseCategory?.Hide();
                CreateWallet?.Hide();
                Height = CreateIncomeCategory.OpenClose();
            }, _ => true);
            CommandCreateIncomeCategory = new(_ =>
            {
                CreateIncomeCategory.Create();
            }, _ => CreateIncomeCategory.RefreshStates());


            CreateExpenseCategory = new(() => { CommandCreateExpenseCategory?.OnCanExecuteChanged(); });
            CommandOpenCloseCreateExpenseCategory = new(_ =>
            {
                CreateIncomeCategory?.Hide();
                CreateWallet?.Hide();
                Height = CreateExpenseCategory.OpenClose();
            }, _ => true);
            CommandCreateExpenseCategory = new(_ =>
            {
                CreateExpenseCategory.Create();
            }, _ => CreateExpenseCategory.RefreshStates());


            Height = 47;
        }
    }
}
