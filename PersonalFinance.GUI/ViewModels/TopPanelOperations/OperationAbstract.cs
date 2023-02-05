using System;
using System.Windows;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public abstract class OperationAbstract : Notifier
    {
        protected Action Refresh { get; init; }

        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                if (SetField(ref _name, value))
                {
                    Refresh?.Invoke();
                }
            }
        }

        private Visibility _isVisible;
        public Visibility IsVisible
        {
            get => _isVisible;
            set => SetField(ref _isVisible, value);
        }

        protected OperationAbstract(Action action)
        {
            Refresh = action;
            _isVisible = Visibility.Collapsed;
        }

        public int OpenClose()
        {
            int height;
            if (IsVisible == Visibility.Visible)
            {
                Hide();
                height = 47;
            }
            else
            {
                Show();
                height = 150;
            }
            return height;
        }

        private void Show()
        {
            IsVisible = Visibility.Visible;
        }

        protected virtual void Clear()
        {
            Name = string.Empty;
        }

        public void Hide()
        {
            Clear();
            IsVisible = Visibility.Collapsed;
        }

        public virtual bool RefreshState()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }

        public abstract void Create();
    }
}
