namespace MusicBrainzMauiApp.Model
{
    public  class Medium
    {
        //
        // Summary:
        //     Physical representation of a release

            //
            // Summary:
            //     Gets or sets the number of tracks.
            public int TrackCount { get; set; }

            //
            // Summary:
            //     Gets or sets the position.
            public int Position { get; set; }

            //
            // Summary:
            //     Gets or sets the format.
            public string Format { get; set; }

            ////
            //// Summary:
            ////     Gets or sets the disc list.
            //[DataMember(Name = "discs")]
            //public List<Disc> Discs { get; set; }

            ////
            //// Summary:
            ////     Gets or sets the track list.
            //[DataMember(Name = "tracks")]

    }
}
