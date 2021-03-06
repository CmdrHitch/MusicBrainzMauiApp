using Hqub.MusicBrainz.API.Entities;

namespace MusicBrainzMauiApp.Model

{
   public class Artist :BaseModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Genres{ get; set; }

        #nullable enable
        public string? Area { get; set; }

#nullable disable
        public string Country { get; set; } = "";

    }
}
