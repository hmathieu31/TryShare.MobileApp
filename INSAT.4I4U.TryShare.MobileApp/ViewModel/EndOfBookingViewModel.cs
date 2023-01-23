using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using INSAT._4I4U.TryShare.MobileApp.Services.Comments;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;
using Microsoft.Maui.Layouts;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    [QueryProperty(nameof(SelectedTricycle), "Tricycle")]
    public partial class EndOfBookingViewModel : BaseViewModel
    {
        public ObservableCollection<Comment> Comments { get; } = new();

        readonly ICommentService _commentService;
        readonly IBookingService _bookingService;

        [ObservableProperty]
        Tricycle? selectedTricycle;

        [ObservableProperty]
        bool isActivityIndicatorRunning = false;
        public EndOfBookingViewModel(ICommentService commentService, IBookingService bookingService)
        {
            this._commentService = commentService;
            this._bookingService = bookingService;
        }

        [RelayCommand]
        public async Task GoToMainPageAsync()
        {
            IsActivityIndicatorRunning= true;
            await _bookingService.RequestEndOfBookingAsync(SelectedTricycle);
            await Shell.Current.Navigation.PopToRootAsync();
            IsActivityIndicatorRunning= false;
        }

    }
}