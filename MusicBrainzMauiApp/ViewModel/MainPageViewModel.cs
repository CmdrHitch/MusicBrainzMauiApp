using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using MusicBrainzMauiApp.Model;
using MusicBrainzMauiApp.View;


namespace MusicBrainzMauiApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        //private SearchQuery searchQuery;
        private string searchTerm;

        public string SearchTerm
        {
            get => searchTerm;
            set => searchTerm = value;
        }

        public MainPageViewModel()
        {
            var searchQuery = new SearchQuery();
        }

        [ICommand]
        Task NavArtistsView() => Shell.Current.GoToAsync($"{nameof(ArtistsPageView)}?SearchTerm={SearchTerm}");
        
        /*    
        public async Task NavArtistsView()
        {
            //searchQuery.SearchTermExpr = SearchTerm;
            //searchQuery.limit = 20; // To/Do
            
            await Shell.Current.GoToAsync($"ArtistsPageView?Term={searchTerm}");
            Debug.WriteLine("ArtistsPageView Returned");
        }*/
    }
}