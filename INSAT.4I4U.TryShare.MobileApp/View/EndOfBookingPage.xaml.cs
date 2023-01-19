using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.View
{
    [QueryProperty(nameof(Tricycle), "Tricycle")]
    public partial class EndOfBookingPage : ContentPage
    {
        public EndOfBookingPage(CommentViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}