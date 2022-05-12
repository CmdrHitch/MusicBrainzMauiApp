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
[QueryProperty(nameof(name), "name")]
public partial class ArtistsViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; set; } = new();
    MusicBrainzClientService client;

    [ObservableProperty]
    private string name;
    public string Name 
    { 
        get => name;
        set => name = value;
    }

    private string _lastName;
    private static int limit = 5; 

    public ArtistsViewModel(MusicBrainzClientService client)
    {
        this.client = client; 
    }

    [ObservableProperty]
    bool isRefreshing;

    [ICommand] // DON'T FORGET THE GOD DAMED 'I'
    public async Task ArtistSearch()
    {
        if (IsBusy || Name == _lastName)
            return;

        try
        {
            IsBusy = true;
            _lastName = Name;

            Debug.WriteLine($"Search term is: { Name}");

           var artists = await client.GetArtists(Name, limit);
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
