using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using INSAT._4I4U.TryShare.MobileApp.Services.Trycicle;
using CommunityToolkit.Mvvm.Input;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {

        public ObservableCollection<Tricycle> Tricycles { get; } = new();

        readonly TrycicleMockService trycicleMockService;

        public Command GetTricycleCommand { get; }

        public MainPageViewModel(TrycicleMockService trycicleMockService)
        {
            Title = "Accueil";
            this.trycicleMockService = trycicleMockService;
            GetTricycleCommand = new Command(async () => await GetTricyclesAsync());
        }


        async Task GetTricyclesAsync()
        {

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var tricycles = await trycicleMockService.GetMockTrycicleList();
                

                if (Tricycles.Count != 0)
                    Tricycles.Clear();

                foreach (var tricycle in tricycles)
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

    }
}

