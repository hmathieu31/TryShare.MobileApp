using CommunityToolkit.Mvvm.Messaging;
using INSAT._4I4U.TryShare.MobileApp.Message;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Tricycles;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    public partial class TricycleUnlockingViewModel : BaseViewModel
    {

        public ObservableCollection<Tricycle> Tricycles { get; } = new();

        [ObservableProperty]
        private bool isPopupVisible = false;

        [ObservableProperty]
        private Tricycle tricycle;

        [RelayCommand]
        public async Task GoToMainPageAsync(Tricycle tricycle)
        {
            await Shell.Current.Navigation.PopToRootAsync();
            IsPopupVisible = false;

            WeakReferenceMessenger.Default.Send(new BookingCompletedMessage());
        }
    }
}
