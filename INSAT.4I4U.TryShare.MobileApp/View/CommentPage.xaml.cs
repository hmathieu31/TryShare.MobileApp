using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.View
{
    [QueryProperty(nameof(Tricycle), "Tricycle")]
    public partial class CommentPage : ContentPage
    {
        public CommentPage(CommentViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((CommentViewModel)BindingContext).OnAppearing();
        }
    }
}