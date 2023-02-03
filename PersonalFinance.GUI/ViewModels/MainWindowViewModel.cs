using PersonalFinance.GUI.ViewModels.MainPanelOperations;
using PersonalFinance.GUI.ViewModels.TopPanelOperations;

namespace PersonalFinance.GUI.ViewModels
{
    public class MainWindowViewModel : Notifier
    {
        public AllData Data { get; set; }

        public TopPanel TopPanel { get; set; }

        public MainPanel MainPanel { get; set; }

        public MainWindowViewModel()
        {
            Data = new();
            TopPanel = new(Data.AddWallet, Data.EditWallet, Data.AddCategory, Data.EditCategory);
            MainPanel = new(Data.ShowAllOperations, Data.ShowFilteredOperations);
        }
    }
}
