using INSAT._4I4U.TryShare.MobileApp.Model;

namespace INSAT._4I4U.TryShare.MobileApp.View;


[QueryProperty(nameof(Tricycle), "Tricycle")]
public partial class TricycleUnlockingPage : ContentPage
{
    public TricycleUnlockingPage(TricycleUnlockingViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}