using INSAT._4I4U.TryShare.MobileApp.Model;
using INSAT._4I4U.TryShare.MobileApp.ViewModel.Base;

namespace INSAT._4I4U.TryShare.MobileApp.ViewModel
{
	[QueryProperty(nameof(Tricycle), "Tricycle")]
	public partial class TricycleDetailsViewModel : BaseViewModel
	{
		public TricycleDetailsViewModel()
		{
		}
		[ObservableProperty]
		Tricycle tricycle;
	}
}