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

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        Task.Run(() => viewModel.LoadRealeases());
    }
    //protected override void On()
    //{
    //    base.OnAppearing();
    //    Task.Run(() => viewModel.LoadRealeases());
    //}

}	 