using PersonalFinance.GUI.ViewModels.Commands;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class TopPanel : Notifier
    {
        public OperationCreateWallet CreateWallet { get; set; }
        public MyCommand CommandOpenCloseCreateWallet { get; }
        public MyCommand CommandCreateWallet { get; }

        public OperationCreateCategory CreateCategory { get; set; }
        public MyCommand CommandOpenCloseCreateCategory { get; }
        public MyCommand CommandCreateCategory { get; }

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
                CreateCategory?.Hide();
                Height = CreateWallet.OpenClose();
            }, _ => true);
            CommandCreateWallet = new(_ =>
            {
                CreateWallet.Create();
            }, _ => CreateWallet.RefreshStates());


            CreateCategory = new(() => { CommandCreateCategory?.OnCanExecuteChanged(); });
            CommandOpenCloseCreateCategory = new(_ =>
            {
                CreateWallet?.Hide();
                Height = CreateCategory.OpenClose();
            }, _ => true);
            CommandCreateCategory = new(_ =>
            {
                CreateCategory.Create();
            }, _ => CreateCategory.RefreshStates());

            Height = 47;
        }
    }
}
