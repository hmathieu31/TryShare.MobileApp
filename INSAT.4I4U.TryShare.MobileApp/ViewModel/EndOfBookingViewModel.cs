using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using INSAT._4I4U.TryShare.MobileApp.Services.Comments;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

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


        [RelayCommand]
        async Task GetCommentsAsync()
        {
            IsActivityIndicatorRunning = true;
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var comments = await _commentService.GetCommentAsync();

                if (Comments.Count != 0)
                {
                    Comments.Clear();
                }

                foreach (var comment in comments)
                {
                    Comments.Add(comment);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get comment: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
            IsActivityIndicatorRunning = false;
        }
    }
}