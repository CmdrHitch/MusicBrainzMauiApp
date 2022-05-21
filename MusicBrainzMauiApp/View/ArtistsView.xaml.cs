using MusicBrainzMauiApp.ViewModel;

namespace MusicBrainzMauiApp.View;

public partial class ArtistsView : ContentPage
{
	public ArtistsView(ArtistsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}