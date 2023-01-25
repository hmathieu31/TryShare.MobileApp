using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using INSAT._4I4U.TryShare.MobileApp.Services.Comments;
using INSAT._4I4U.TryShare.MobileApp.Services.User;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using Microsoft.Maui.Layouts;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    [QueryProperty(nameof(SelectedTricycle), "Tricycle")]
    public partial class EndOfBookingViewModel : BaseViewModel
    {
        public ObservableCollection<Comment> Comments { get; } = new();

        private readonly IBookingService _bookingService;
        private readonly IUserService _userService;

        [ObservableProperty]
        Tricycle? selectedTricycle;

        [ObservableProperty]
        bool isActivityIndicatorRunning = false;

        public EndOfBookingViewModel(IBookingService bookingService, IUserService userService)
        {
            this._bookingService = bookingService;
            this._userService = userService;
        }

        [RelayCommand]
        public async Task GoToMainPageAsync()
        {
            IsActivityIndicatorRunning= true;
            await _bookingService.RequestEndOfBookingAsync(SelectedTricycle);
            _userService.RemoveTricycleToUser(await _userService.GetUserIdentityAsync());
            await Shell.Current.Navigation.PopToRootAsync();
            IsActivityIndicatorRunning= false;
        }

    }
}