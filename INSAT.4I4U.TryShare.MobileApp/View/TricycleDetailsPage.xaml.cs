using INSAT._4I4U.TryShare.MobileApp.Model;
using Xamarin.Google.Crypto.Tink.Mac;

namespace INSAT._4I4U.TryShare.MobileApp.View;

[QueryProperty(nameof(Tricycle),"Tricycle")]
public partial class TricycleDetailsPage: ContentPage
{

    TricycleDetailsViewModel _viewModel = new();

    public TricycleDetailsPage(TricycleDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetTricycleAddress();

    }

}