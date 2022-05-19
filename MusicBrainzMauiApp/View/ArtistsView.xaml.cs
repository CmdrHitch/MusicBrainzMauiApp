using MusicBrainzMauiApp.ViewModel;
using MusicBrainzMauiApp.Model;
using System.Diagnostics;


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