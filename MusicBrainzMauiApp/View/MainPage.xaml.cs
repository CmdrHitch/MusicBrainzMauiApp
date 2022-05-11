using MusicBrainzMauiApp.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace MusicBrainzMauiApp.View;


public partial class MainPage : ContentPage
{

	public MainPage(ArtistViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}

