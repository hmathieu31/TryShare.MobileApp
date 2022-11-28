namespace INSAT._4I4U.TryShare.MobileApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TricycleDetailsPage), typeof(TricycleDetailsPage));
	}
}
