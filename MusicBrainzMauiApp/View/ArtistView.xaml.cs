using MusicBrainzMauiApp.ViewModel;

namespace MusicBrainzMauiApp.View;


public partial class ArtistView : ContentPage
{
	public ArtistView(ArtistViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}