using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;
using Hqub.MusicBrainz.API;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MusicBrainzMauiApp.Model;
using MusicBrainzMauiApp.Services;

namespace MusicBrainzMauiApp.ViewModel;

public partial class ArtistViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; set; } = new();
    MusicBrainzClientService client;
    public string SearchTerm { get; set; }
    private static int limit = 5; 

    public ArtistViewModel(MusicBrainzClientService client)
    {
        this.client = client; 
    }

    [ObservableProperty]
    bool isRefreshing;

    [ICommand] // DON'T FORGET THE GOD DAMED 'I'
    public async Task ArtistSearch()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            Debug.WriteLine($"Search term is: { SearchTerm}");

           var artists = await client.GetArtists(SearchTerm, limit);
            await Task.Delay(2000);

            foreach(var artist in artists)
            {
                Artists.Add(artist);
            }
        }
        catch(Exception ex)
        {
            Debug.WriteLine($"Unable to get Artists: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        } 
    }
}
