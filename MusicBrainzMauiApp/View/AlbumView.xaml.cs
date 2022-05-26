using MusicBrainzMauiApp.ViewModel;


namespace MusicBrainzMauiApp.View;


public partial class AlbumView : ContentPage
{
	readonly AlbumViewModel viewModel;
	public AlbumView(AlbumViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        Task.Run(() => viewModel.SetViewTitle());
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    Task.Run(() => viewModel.SetViewTitle());

    //}
}