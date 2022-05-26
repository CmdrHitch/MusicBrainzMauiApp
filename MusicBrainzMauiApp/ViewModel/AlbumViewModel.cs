using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

using MusicBrainzMauiApp.Model;
using MusicBrainzMauiApp.Services;

namespace MusicBrainzMauiApp.ViewModel
{

    [QueryProperty(nameof(Albums),"Albums")]
    public partial class AlbumViewModel : ClientBaseViewModel
    {

        [ObservableProperty]
        List<Release> albums;

        [ObservableProperty]
        string blah;

        public AlbumViewModel(MusicBrainzClientService client)
        {
            this.client = client; 
        }

        public async Task SetViewTitle()
        {
            await Task.Run(() => Blah = albums.First().Title);
            

            Debug.WriteLine("AlbumTitle", albums.First().Title);

            
        }

    }
}
