using INSAT._4I4U.TryShare.MobileApp.ViewModel.ProfileFlyoutHeader;

namespace INSAT._4I4U.TryShare.MobileApp;

public partial class App : Application
{
	public App(ProfileFlyoutViewModel flyoutViewModel)
	{
		InitializeComponent();

		MainPage = new AppShell(flyoutViewModel);
	}
}
