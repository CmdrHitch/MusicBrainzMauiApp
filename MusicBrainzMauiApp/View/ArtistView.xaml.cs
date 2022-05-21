using MusicBrainzMauiApp.ViewModel;

namespace MusicBrainzMauiApp.View;


public partial class ArtistView : ContentPage
{
	private ArtistViewModel viewModel;
	public ArtistView(ArtistViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetRecordings();
    }
}	