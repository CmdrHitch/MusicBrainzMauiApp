using MusicBrainzMauiApp.ViewModel;

namespace MusicBrainzMauiApp.View;
public partial class MainPageView : ContentPage
{
    public MainPageView(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
  
}

