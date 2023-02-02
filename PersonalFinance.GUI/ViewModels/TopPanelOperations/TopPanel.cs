using System;
using PersonalFinance.GUI.Models;
using PersonalFinance.GUI.ViewModels.Commands;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class TopPanel : Notifier
    {
        public OperationCreateWallet CreateWallet { get; set; }
        public MyCommand CommandOpenCloseCreateWallet { get; }
        public MyCommand CommandCreateWallet { get; }

        public OperationEditWallet EditWallet { get; set; }
        public MyCommand CommandOpenCloseEditWallet { get; }
        public MyCommand CommandEditWallet { get; }

        public OperationCreateCategory CreateCategory { get; set; }
        public MyCommand CommandOpenCloseCreateCategory { get; }
        public MyCommand CommandCreateCategory { get; }

        public OperationEditCategory EditCategory { get; set; }
        public MyCommand CommandOpenCloseEditCategory { get; }
        public MyCommand CommandEditCategory { get; }

        private int _height;
        public int Height
        {
            get => _height;
            set => SetField(ref _height, value);
        }

        public TopPanel(Action<string, Currency, double, string> addWallet, Action<MyWallet, string> editWallet, Action<string, bool> addCategory, Action<Category, Category, string> editCategory)
        {
            CreateWallet = new(() => { CommandCreateWallet?.OnCanExecuteChanged(); }, addWallet);
            CommandOpenCloseCreateWallet = new(_ =>
            {
                CreateCategory?.Hide();
                EditCategory?.Hide();
                EditWallet?.Hide();
                Height = CreateWallet.OpenClose();
            }, _ => true);
            CommandCreateWallet = new(_ =>
            {
                CreateWallet.Create();
            }, _ => CreateWallet.RefreshStates());


            EditWallet = new(() => { CommandEditWallet?.OnCanExecuteChanged(); }, editWallet);
            CommandOpenCloseEditWallet = new(_ =>
            {
                CreateWallet?.Hide();
                CreateCategory?.Hide();
                EditCategory?.Hide();
                Height = EditWallet.OpenClose();
            }, _ => true);
            CommandEditWallet = new(_ =>
            {
                EditWallet.Create();
            }, _ => EditWallet.RefreshStates());


            CreateCategory = new(() => { CommandCreateCategory?.OnCanExecuteChanged(); }, addCategory);
            CommandOpenCloseCreateCategory = new(_ =>
            {
                CreateWallet?.Hide();
                EditCategory?.Hide();
                EditWallet?.Hide();
                Height = CreateCategory.OpenClose();
            }, _ => true);
            CommandCreateCategory = new(_ =>
            {
                CreateCategory.Create();
            }, _ => CreateCategory.RefreshStates());


            EditCategory = new(() => { CommandEditCategory?.OnCanExecuteChanged(); }, editCategory);
            CommandOpenCloseEditCategory = new(_ =>
            {
                CreateWallet?.Hide();
                CreateCategory?.Hide();
                EditWallet?.Hide();
                Height = EditCategory.OpenClose();
            }, _ => true);
            CommandEditCategory = new(_ =>
            {
                EditCategory.Create();
            }, _ => EditCategory.RefreshStates());

            Height = 47;
        }
    }
}
