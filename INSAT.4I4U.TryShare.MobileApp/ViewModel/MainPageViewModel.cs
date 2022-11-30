using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycle;
using CommunityToolkit.Mvvm.Input;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {

        public ObservableCollection<Tricycle> Tricycles { get; } = new();

        readonly ITricycleService tricycleMockService;

        public MainPageViewModel(ITricycleService tricycleMockService)
        {
            Title = "Accueil";
            this.tricycleMockService = tricycleMockService;
        }

        [RelayCommand]
        async Task GetTricyclesAsync()
        {
            // Implémentation de la méthode qui accède au service
            // et met les tricycles dans la `tricycles` (qui a été crée 
            // automatiquement en caché normalement 
            //- tu peux le vérifier en utilisant l'autocomplete)

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var list = await tricycleMockService.GetTricycleList();

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

    }
}

