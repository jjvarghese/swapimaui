namespace SwapiMaui.ViewModel;

using CommunityToolkit.Mvvm.ComponentModel;


public partial class BaseViewModel : ObservableObject
{
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    [ObservableProperty] bool isBusy;
    
    [ObservableProperty] string title;
    public bool IsNotBusy => !isBusy;
}

