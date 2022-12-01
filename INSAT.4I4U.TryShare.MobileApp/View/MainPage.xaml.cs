namespace INSAT._4I4U.TryShare.MobileApp.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
	async void OnDetailsButtonClicked()
	{
		await Shell.Current.GoToAsync(nameof(TricycleDetailsPage));
	}
}

