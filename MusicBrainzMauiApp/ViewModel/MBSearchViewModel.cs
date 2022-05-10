using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;
using Hqub.MusicBrainz.API;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MusicBrainzMauiApp.Model;

namespace MusicBrainzMauiApp.ViewModel;

public partial class MBSearchViewModel : BaseViewModel
{
    public ObservableCollection<Albums> Albums { get; set; } = new();

    public MBSearchViewModel()
    {

    }

    [ObservableProperty]
    bool isRefreshing;

    [ICommand] // DONT FORGET THE GOD DAMED 'I'
    public async Task MBSearch()
    {
        if (IsBusy)
            return;

        var client = new MusicBrainzClient();

        string term = "\"Pink Floyd\"";

        Debug.WriteLine(term);

        var artists = await client.Artists.SearchAsync(term);

        if (artists == null)
        {
            Debug.WriteLine("artists is null");
            return;
        }
        else
        {
            if (artists.Count() == 0)
                return;
        }
        

        foreach (var artist in artists)
        {
                Debug.WriteLine(artist.Name);
        }
       

    }
}
