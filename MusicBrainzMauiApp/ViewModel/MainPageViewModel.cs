using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using MusicBrainzMauiApp.Model;
using MusicBrainzMauiApp.View;


namespace MusicBrainzMauiApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
  
        public MainPageViewModel()
        {

        }

        [ICommand]
        Task NavArtistsView() =>
            Shell.Current.GoToAsync(nameof(ArtistsView));

    }
}