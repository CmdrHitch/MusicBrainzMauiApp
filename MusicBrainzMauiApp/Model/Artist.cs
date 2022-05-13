namespace MusicBrainzMauiApp.Model
{
   public class Artist :BaseModel
    {
        public string MBID { get; set; }
        public string Name { get; set; }
    }
}

        //< CollectionView
        //    ItemsSource = "{Binding Artists}"
        //    BackgroundColor = "Transparent"
        //    SelectionMode = "Single" >
        //    < CollectionView.ItemTemplate >
        //        < DataTemplate x: DataType = "model:Artist" >
        //            < Label
        //                Text = "{Binding Name}" TextColor = "Black" />
        //        </ DataTemplate >

        //    </ CollectionView.ItemTemplate >

        //</ CollectionView >