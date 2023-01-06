using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.Services.Comments;
using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
    [QueryProperty(nameof(Tricycle), "Tricycle")]
    public partial class CommentViewModel : BaseViewModel
    {
        public ObservableCollection<Comment> Comments { get; } = new();
        ICommentService commentService;
        public CommentViewModel(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [RelayCommand]
        async Task GetCommentsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var comments = await commentService.GetCommentAsync();

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