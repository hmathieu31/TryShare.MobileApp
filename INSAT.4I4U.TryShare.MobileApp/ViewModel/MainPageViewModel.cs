using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;

using Microsoft.Maui.Controls.Maps;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {

        public ObservableCollection<Tricycle> Tricycles { get; } = new();

        [ObservableProperty]
        private bool isPopupVisible = false;

        [ObservableProperty]
        private Tricycle selectedTricycle;

        readonly ITricycleService tricycleService;

        public MainPageViewModel(ITricycleService tricycleService)
        {
            this.tricycleService = tricycleService;
        }

        public void DisplayPopup(int id)
        {
            SelectedTricycle = Tricycles.First(x => x.Id == id);
            IsPopupVisible = true;
        }

        public void HidePopup()
        {
            IsPopupVisible = false;
        }

        [RelayCommand]
        async Task GetTricyclesAsync()
        {

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var list = await tricycleService.GetTricyclesAsync();

                if (Tricycles.Count != 0)
                    Tricycles.Clear();

                foreach (var tricycle in list)
                    Tricycles.Add(tricycle);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get tricycle {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GoToDetailsAsync(Tricycle tricycle)
        {
            await Shell.Current.GoToAsync(nameof(TricycleDetailsPage), true, new Dictionary<string, object>
                { {"Tricycle", tricycle } });
            IsPopupVisible = false;
        }
    }
}

