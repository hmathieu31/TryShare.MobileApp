namespace INSAT._4I4U.TryShare.MobileApp.View;

public partial class TricycleDetailsPage: ContentPage
{
    public TricycleDetailsPage(TricycleDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}