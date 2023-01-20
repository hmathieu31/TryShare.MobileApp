using INSAT._4I4U.TryShare.MobileApp.Model;
using System.Windows.Input;

namespace INSAT._4I4U.TryShare.MobileApp.View;

[QueryProperty(nameof(Tricycle),"Tricycle")]
public partial class TricycleDetailsPage: ContentPage
{
    public TricycleDetailsPage(TricycleDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.OnDetailsTryToNavigateWithoutConnectivity = async () => await DisplayConnectivityErrorPopupAsync();
        viewModel.OnDetailsTryToNavigateWithoutLocationEnabled = async () => await DisplayLocationUnabledErrorPopupAsync();
        viewModel.OnDetailsTryToNavigateWithoutLocationAuthorized= async () => await DisplayLocationUnauthorizedErrorPopupAsync();
    }

    protected override async void OnAppearing()
    {
        // Call the base methods first
        base.OnAppearing();

        // Cast the BindingContext to a TricycleDetailsViewModel (this cast is safe because the BindingContext is set in the constructor)
        // and call the SetTricycleAddressLabelAsync method defined in the ViewModel
        await (BindingContext as TricycleDetailsViewModel).SetTricycleAddressLabelAsync();
    }

    public async Task DisplayConnectivityErrorPopupAsync()
    {
        await DisplayAlert("Alerte", "Aucune connection internet trouvée", "OK");
    }

    public async Task DisplayLocationUnabledErrorPopupAsync()
    {
        await DisplayAlert("Alerte", "La localisation n'est pas activée", "OK");
    }

    public async Task DisplayLocationUnauthorizedErrorPopupAsync()
    {
        await DisplayAlert("Alerte", "La localisation n'est pas autorisée", "OK");
    }

    private async void GoToMoreCommentsTapped(object sender, TappedEventArgs e)
    {
        await (BindingContext as TricycleDetailsViewModel).GoToMoreCommentsAsync();
    }
    private async void OnTermsAndConditionsTapped(object sender, TappedEventArgs args)
    {
        await (BindingContext as TricycleDetailsViewModel).GoToTermsAndConditionsAsync();
    }
}