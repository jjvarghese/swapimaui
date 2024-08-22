using CommunityToolkit.Mvvm.ComponentModel;
using SwapiMaui.Model;

namespace SwapiMaui.ViewModel;

[QueryProperty(nameof(Person), "Person")]
[QueryProperty(nameof(Film), "Film")]
[QueryProperty(nameof(Planet), "Planet")]
[QueryProperty(nameof(Title), "Title")]
public partial class DetailViewModel : BaseViewModel
{
    [ObservableProperty] private Person person;
    [ObservableProperty] private Film film;
    [ObservableProperty] private Planet planet;
    [ObservableProperty] private string title;
}