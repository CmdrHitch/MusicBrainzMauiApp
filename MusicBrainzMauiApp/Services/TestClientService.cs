using MusicBrainzMauiApp.Model;

namespace MusicBrainzMauiApp.Services
{
  public static class TestClientService
    {
        public static async Task<List<Artist>>GetAritistsAsync()
        {
            var artists = new List<Artist>();
            
            await Task.Run(() =>
            {
                Artist artist1 = new Artist { MBID = "1", Name = "Artist One" };
                Artist artist2 = new Artist { MBID = "1", Name = "Artist Two" };
                Artist artist3 = new Artist { MBID = "1", Name = "Artist Three" };
                Artist artist4 = new Artist { MBID = "1", Name = "Artist Four" };
                Artist artist5 = new Artist { MBID = "1", Name = "Artist Five" };

                artists.Add(artist1);
                artists.Add(artist2);
                artists.Add(artist3);
                artists.Add(artist4);
                artists.Add(artist5);
            }); 

            return artists;
        }
        
    }
}
