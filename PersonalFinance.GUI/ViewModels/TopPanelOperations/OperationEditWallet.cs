using System;
using PersonalFinance.GUI.Models;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class OperationEditWallet : OperationAbstract
    {
        private readonly Action<MyWallet, string> _editWallet;

        private MyWallet? _selectedWallet;
        public MyWallet? SelectedWallet
        {
            get => _selectedWallet;
            set
            {
                _ = SetField(ref _selectedWallet, value);
                Name = _selectedWallet?.Name;
            }
        }

        public OperationEditWallet(Action action, Action<MyWallet, string> editWallet) : base(action)
        {
            _editWallet = editWallet;
        }

        public override bool RefreshState()
        {
            return !string.IsNullOrWhiteSpace(Name) && SelectedWallet is not null;
        }

        public override void Create()
        {
            _editWallet.Invoke(SelectedWallet!, Name!);
            Clear();
        }

        protected override void Clear()
        {
            Name = string.Empty;
            SelectedWallet = null;
        }
    }
}
