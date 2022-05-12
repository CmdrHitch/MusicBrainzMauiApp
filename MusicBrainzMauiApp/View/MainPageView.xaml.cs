using MusicBrainzMauiApp.ViewModel;

namespace MusicBrainzMauiApp.View;
public partial class MainPageView : ContentPage
{
    public string SearchTerm { get; set; }


    public MainPageView(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
  
}

