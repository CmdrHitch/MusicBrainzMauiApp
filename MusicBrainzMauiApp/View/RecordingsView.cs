namespace MusicBrainzMauiApp.View;

public class RecordingsView : ContentPage
{
	public RecordingsView()
	{
		Content = new StackLayout
		{
			Children = {
				new Label { Text = "Welcome to .NET MAUI!" }
			}
		};
	}
}