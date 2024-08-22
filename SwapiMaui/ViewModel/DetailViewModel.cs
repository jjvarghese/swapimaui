using CommunityToolkit.Mvvm.ComponentModel;
using SwapiMaui.Model;
using SwapiMaui.ViewModel;

namespace SwapiMaui.ViewModel;

[QueryProperty(nameof(Person), "Person")]
[QueryProperty(nameof(Title), "Title")]
public partial class DetailViewModel : BaseViewModel
{
    [ObservableProperty] private Person person;
    [ObservableProperty] private Film film;
    [ObservableProperty] private String title;
}