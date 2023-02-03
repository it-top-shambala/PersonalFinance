using System;
using System.Collections.Generic;
using PersonalFinance.GUI.Models;
using PersonalFinance.Lib.Models;

namespace PersonalFinance.GUI.ViewModels.TopPanelOperations
{
    public class OperationCreateWallet : OperationAbstract
    {
        private readonly Action<string, Currency, double, string> _addWallet;

        private string? _sum;
        public string? Sum
        {
            get => _sum;
            set
            {
                SumFormatter.RemoveLettersOrSymbols(ref value!);
                SumFormatter.Cut(ref value!);
                if (SetField(ref _sum, value))
                {
                    RefreshState?.Invoke();
                }
            }
        }

        private Currency? _selectedCurrency;
        public Currency? SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                if (SetField(ref _selectedCurrency, value))
                {
                    RefreshState?.Invoke();
                }
            }
        }

        public List<ImageSource>? ImageSources { get; set; }

        private ImageSource? _selectedImage;
        public ImageSource? SelectedImage
        {
            get => _selectedImage;
            set
            {
                if (SetField(ref _selectedImage, value))
                {
                    RefreshState?.Invoke();
                }
            }
        }

        public OperationCreateWallet(Action action, Action<string, Currency, double, string> addWallet) : base(action)
        {
            InitImageSources();
            _addWallet = addWallet;
        }

        protected override void Clear()
        {
            Name = string.Empty;
            Sum = string.Empty;
            SelectedCurrency = null;
            SelectedImage = null;
        }

        public override void Create()
        {
            var sum = Sum == string.Empty ? 0 : double.Parse(Sum!, System.Globalization.CultureInfo.InvariantCulture);
            _addWallet.Invoke(Name!, SelectedCurrency!, sum, SelectedImage!.Path!);
            Clear();
        }

        public override bool RefreshStates()
        {
            return !string.IsNullOrWhiteSpace(Name) && SelectedCurrency is not null && !string.IsNullOrWhiteSpace(SelectedImage?.Path);
        }

        private void InitImageSources()
        {
            ImageSources = new List<ImageSource>();
            for (var i = 0; i < 6; i++)
            {
                ImageSources.Add(new ImageSource { Path = $"Assets/Backgrounds/{i}.jpg" });
            }
        }
    }
}
