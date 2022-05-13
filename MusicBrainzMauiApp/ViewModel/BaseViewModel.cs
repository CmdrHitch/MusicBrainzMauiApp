using CommunityToolkit.Mvvm.ComponentModel;

namespace MusicBrainzMauiApp.ViewModel
{
    public partial class BaseViewModel : ObservableObject 
    {
        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotBusy))] // the isBusy property has [AlsoNotifyChangeFor(nameof(IsNotBusy))],
        bool isBusy;                             // which will also notify IsNotBusy when the value changes


        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
    }
}
