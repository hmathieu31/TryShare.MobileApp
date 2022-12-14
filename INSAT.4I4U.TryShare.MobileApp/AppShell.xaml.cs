using INSAT._4I4U.TryShare.MobileApp.View;

namespace INSAT._4I4U.TryShare.MobileApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TricycleDetailsPage), typeof(TricycleDetailsPage));
        Routing.RegisterRoute(nameof(TricycleUnlockingPage), typeof(TricycleUnlockingPage));
    }
}
