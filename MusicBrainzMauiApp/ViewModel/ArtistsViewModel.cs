using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;
using Hqub.MusicBrainz.API;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicBrainzMauiApp.Model;
using MusicBrainzMauiApp.Services;

namespace MusicBrainzMauiApp.ViewModel;

[QueryProperty(nameof(SearchTerm), nameof(SearchTerm))] //The SearchTerm binds to backing field searchTerm and provided getters and setters
public partial class ArtistsViewModel : BaseViewModel
{
    public ObservableCollection<Artist> Artists { get; set; } = new();
    MusicBrainzClientService client;

    [ObservableProperty]
    string searchTerm;
    private string _lastName;
    private static int limit = 5;

    [ObservableProperty]
    bool isRefreshing;

    public ArtistsViewModel(MusicBrainzClientService client)
    {
        this.client = client;
        searchTerm = "Search not Passsed";
        Debug.WriteLine("ArtistsViewModel constructing");
    }

    [ICommand]
    Task Back() => Shell.Current.GoToAsync("..");

    [ICommand] // DON'T FORGET THE GOD DAMED 'I'
    public async Task ArtistSearch()
    {
        if (IsBusy || searchTerm == _lastName)
            return;

        try
        {
            IsBusy = true;
            _lastName = searchTerm;

            Debug.WriteLine($"Search term is: {searchTerm}");

           var artists = await client.GetArtists(searchTerm, limit);
           //await Task.Delay(2000);

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
