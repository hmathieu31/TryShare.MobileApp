using INSAT._4I4U.TryShare.MobileApp.View;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.ProfileFlyoutHeader;

namespace INSAT._4I4U.TryShare.MobileApp;

public partial class AppShell : Shell
{
	public AppShell(ProfileFlyoutViewModel flyoutViewModel)
	{
		InitializeComponent();
		BindingContext = flyoutViewModel;
        Routing.RegisterRoute(nameof(TricycleDetailsPage), typeof(TricycleDetailsPage));
		Routing.RegisterRoute(nameof(TermsAndConditionsPage), typeof(TermsAndConditionsPage));
        Routing.RegisterRoute(nameof(CommentPage), typeof(CommentPage));
        Routing.RegisterRoute(nameof(TricycleUnlockingPage), typeof(TricycleUnlockingPage));
    }
}
