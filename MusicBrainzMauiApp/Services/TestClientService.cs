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
                Artist artist2 = new Artist { MBID = "2", Name = "Artist Two" };
                Artist artist3 = new Artist { MBID = "3", Name = "Artist Three" };
                Artist artist4 = new Artist { MBID = "4", Name = "Artist Four" };
                Artist artist5 = new Artist { MBID = "5", Name = "Artist Five" };

                artists.Add(artist1);
                artists.Add(artist2);
                artists.Add(artist3);
                artists.Add(artist4);
                artists.Add(artist5);
            }); 

            return artists;
        }

        public static async Task<List<Recording>>GetRecordingsAsync(Artist artist)
        {
            var recordings = new List<Recording>();

            await Task.Run(() =>
            {
                var recording1 = new Recording { MBID = "1",  Title = "Recording One" };
                var recording2 = new Recording { MBID = "2",  Title = "Recording Two" };
                var recording3 = new Recording { MBID = "3",  Title = "Recording Three" };
                var recording4 = new Recording { MBID = "4",  Title = "Recording Four" };
                var recording5 = new Recording { MBID = "5",  Title = "Recording Five" };
                var recording6 = new Recording { MBID = "6",  Title = "Recording Six" };

                recordings.Add(recording1);
                recordings.Add(recording2);
                recordings.Add(recording3);
                recordings.Add(recording4);
                recordings.Add(recording5);
                recordings.Add(recording6);
            });

            return recordings;
        }
        
    }
}
