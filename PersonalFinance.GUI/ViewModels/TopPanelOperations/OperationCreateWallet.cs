using System;
using System.Collections.Generic;
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
                RemoveLettersOrSymbols(ref value!);
                Cut(ref value!);
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

        private static void RemoveLettersOrSymbols(ref string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str[0] is ',' or '0')
                {
                    str = str.Remove(0, 1);
                }

                for (var i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]) && str[i] != ',')
                    {
                        str = str.Remove(i, 1);
                    }
                }

                if (str.Contains(','))
                {
                    for (var i = str.IndexOf(',') + 1; i < str.Length; i++)
                    {
                        if (str[i] == ',')
                        {
                            str = str.Remove(i, 1);
                        }
                    }
                }
            }
        }

        private static void Cut(ref string str)
        {
            if (str.Contains(',') && str.IndexOf(',') + 3 == str.Length - 1)
            {
                str = str.Remove(str.IndexOf(',') + 3);
            }
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
