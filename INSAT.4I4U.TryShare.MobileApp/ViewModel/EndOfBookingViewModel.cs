using CommunityToolkit.Mvvm.Messaging;
using Foundation;
using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Booking;
using INSAT._4I4U.TryShare.MobileApp.Services.Comments;
using INSAT._4I4U.TryShare.MobileApp.View;
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
        public EndOfBookingViewModel(ICommentService commentService, IBookingService bookingService)
        {
            this._commentService = commentService;
            this._bookingService = bookingService;
        }

        [RelayCommand]
        public async Task GoToMainPageAsync()
        {
            _bookingService.RequestEndOfBookingAsync(selectedTricycle);
            await Shell.Current.Navigation.PopToRootAsync();
        }


        [RelayCommand]
        async Task GetCommentsAsync()
        {
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
        }
    }
}