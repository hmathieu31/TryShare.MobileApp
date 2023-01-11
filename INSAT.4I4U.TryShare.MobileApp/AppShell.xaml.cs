using INSAT._4I4U.TryShare.MobileApp.View;

namespace INSAT._4I4U.TryShare.MobileApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TricycleDetailsPage), typeof(TricycleDetailsPage));
		Routing.RegisterRoute(nameof(TermsAndConditionsPage), typeof(TermsAndConditionsPage));
        Routing.RegisterRoute(nameof(CommentPage), typeof(CommentPage));
        Routing.RegisterRoute(nameof(TricycleUnlockingPage), typeof(TricycleUnlockingPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(PostBookingPage), typeof(PostBookingPage));
    }
}
