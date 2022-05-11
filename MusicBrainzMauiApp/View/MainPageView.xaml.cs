using MusicBrainzMauiApp.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace MusicBrainzMauiApp.View;


public partial class MainPageView : ContentPage
{

	public MainPageView(ArtistsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}

