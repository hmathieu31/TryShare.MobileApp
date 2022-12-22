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
    }

    protected override async void OnAppearing()
    {
        // Call the base methods first
        base.OnAppearing();

        // Cast the BindingContext to a TricycleDetailsViewModel (this cast is safe because the BindingContext is set in the constructor)
        // and call the SetTricycleAddressLabelAsync method defined in the ViewModel
        await (BindingContext as TricycleDetailsViewModel).SetTricycleAddressLabelAsync();
    }

    private void OnTermsAndConditionsTapped(object sender, TappedEventArgs args)
    {
        await (BindingContext as TricycleDetailsViewModel).GoToTermsAndConditionsAsync();
    }
}