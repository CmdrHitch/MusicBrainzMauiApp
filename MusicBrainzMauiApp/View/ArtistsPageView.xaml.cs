using MusicBrainzMauiApp.ViewModel;

namespace MusicBrainzMauiApp.View;

public partial class ArtistsPageView : ContentPage
{
	public ArtistsPageView(ArtistsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}