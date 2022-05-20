namespace MusicBrainzMauiApp.Model
{
   public class Artist :BaseModel
    {
        public string Name { get; set; }

        public List<Albums> Albums { get; set; }
    }
}
