[QueryProperty(nameof(Tricycle), "Tricycle")]
public partial class TricycleDetailsViewModel : BaseViewModel
{
	public TricycleDetailsViewModel()
	{
	}
	[ObservableProperty]
	Tricycle tricycle;
}