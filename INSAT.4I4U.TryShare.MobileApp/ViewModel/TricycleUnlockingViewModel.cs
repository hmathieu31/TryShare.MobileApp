using CommunityToolkit.Mvvm.Messaging;
using INSAT._4I4U.TryShare.MobileApp.Message;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    [QueryProperty(nameof(SelectedTricycle), "Tricycle")]
    public partial class TricycleUnlockingViewModel : BaseViewModel
    {
        private readonly IBookingService _bookingService;

        [ObservableProperty]
        Tricycle? selectedTricycle;

        [ObservableProperty]
        int ratingControlValue;

        [ObservableProperty]
        bool isActivityIndicatorRunning = false;
        public TricycleUnlockingViewModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [RelayCommand]
        public async Task BookAndGoToMainPageAsync()
        {
            IsActivityIndicatorRunning = true;
            if (SelectedTricycle is null)
                throw new InvalidOperationException("Tricycle should not be null");

            // Set the Rating of the tricycle to book to the value of the RatingControl
            SelectedTricycle.Rating = RatingControlValue;

            var result = await _bookingService.RequestTricycleBookingAsync(SelectedTricycle);
            if (!result)
            {
                Debug.WriteLine("Authentication was invalid");
            }
            else
            {

                await Shell.Current.Navigation.PopToRootAsync();
                WeakReferenceMessenger.Default.Send(new BookingCompletedMessage());

            }
            IsActivityIndicatorRunning = false;
        }
    }
}
