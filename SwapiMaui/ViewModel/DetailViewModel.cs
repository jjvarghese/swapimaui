using CommunityToolkit.Mvvm.ComponentModel;
using SwapiMaui.Model;
using SwapiMaui.ViewModel;

namespace SwapiMaui.ViewModel;

[QueryProperty("Person", "Person")]
public partial class DetailViewModel : BaseViewModel
{
    [ObservableProperty] private Person person;

}