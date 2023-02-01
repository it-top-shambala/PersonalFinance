using PersonalFinance.GUI.ViewModels.TopPanelOperations;

namespace PersonalFinance.GUI.ViewModels
{
    public class MainWindowViewModel : Notifier
    {
        public TopPanel TopPanel { get; set; }

        public AllData Data { get; set; }

        public MainWindowViewModel()
        {
            TopPanel = new();
            Data = new();
        }
    }
}
