using System;
using PersonalFinance.GUI.ViewModels.Commands;
using PersonalFinance.Lib.Models;

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

        public TopPanel(Action<string, bool> addCategory, Action<string, Currency, double, string> addWallet)
        {
            CreateWallet = new(() => { CommandCreateWallet?.OnCanExecuteChanged(); }, addWallet);
            CommandOpenCloseCreateWallet = new(_ =>
            {
                CreateCategory?.Hide();
                Height = CreateWallet.OpenClose();
            }, _ => true);
            CommandCreateWallet = new(_ =>
            {
                CreateWallet.Create();
            }, _ => CreateWallet.RefreshStates());


            CreateCategory = new(() => { CommandCreateCategory?.OnCanExecuteChanged(); }, addCategory);
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
