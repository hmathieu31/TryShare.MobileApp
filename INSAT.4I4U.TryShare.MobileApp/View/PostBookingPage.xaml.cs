using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.View
{
    [QueryProperty(nameof(Tricycle), "Tricycle")]
    public partial class PostBookingPage : ContentPage
    {
        public PostBookingPage(CommentViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}