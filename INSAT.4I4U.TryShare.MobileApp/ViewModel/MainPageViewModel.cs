using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CountText))]
        int count = 0;

        public string CountText
        {
            get
            {
                string text = "Click me";
                if (count > 0)
                    text = $"Clicked {count} time{(count == 1 ? "" : "s")}";

                SemanticScreenReader.Announce(text);
                return text;
            }
        }
        
        [RelayCommand]
        void IncrementCount()
        {
            Count++;
        }
    }
}

