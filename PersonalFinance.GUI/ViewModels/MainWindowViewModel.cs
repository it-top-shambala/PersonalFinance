using PersonalFinance.GUI.ViewModels.TopPanelOperations;

namespace PersonalFinance.GUI.ViewModels
{
    public class MainWindowViewModel : Notifier
    {
        public AllData Data { get; set; }

        public TopPanel TopPanel { get; set; }

        public MainWindowViewModel()
        {
            Data = new();
            TopPanel = new(Data.AddWallet, Data.EditWallet, Data.AddCategory, Data.EditCategory);
        }
    }
}
