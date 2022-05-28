using Hqub.MusicBrainz.API;
using Hqub.MusicBrainz.API.Entities;

namespace MusicBrainzMauiApp.Services
{
    //New Class to overcome namespace clash with Hqub.MusicBrainz
    public static  class CoverArtService
    {

        public static async Task<string> GetCoverArtUri(MusicBrainzClient client, string mbid)
        {
            var release = await client.Releases.GetAsync(mbid);

            return "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg";

            //if (release.CoverArtArchive.Artwork)
            //{
            //    var uri = CoverArtArchive.GetCoverArtUri(release.Id);
            //    return uri.AbsoluteUri;
            //}
            //else
            //{
            //    return "https://musicbrainz.org/release/b90a9cca-6416-4ded-b181-b67c30b0e03a";
            //}
        }

    }
}
