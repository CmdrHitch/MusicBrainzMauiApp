using MusicBrainzMauiApp.ViewModel;


namespace MusicBrainzMauiApp.View;

public partial class ArtistsPageView : ContentPage
{
	public ArtistsPageView(ArtistsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}