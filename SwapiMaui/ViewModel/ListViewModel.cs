using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using SwapiMaui.Model;
using SwapiMaui.Service;
using SwapiMaui.View;
using SwapiMaui.ViewModel;

namespace SwapiMaui.ViewModel;
public partial class ListViewModel : BaseViewModel
{
    private readonly SwapiService swapiService;

    public ObservableCollection<Person> People { get; } = new();
    public ObservableCollection<Film> Films { get; } = new();
    public ObservableCollection<ListItem> Items { get; } = new();

    public ListViewModel(SwapiService swapiService)
    {
        Title = "Swapi Maui";

        this.swapiService = swapiService;
    }

    [RelayCommand]
    private async Task GetPeopleAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            
            Films.Clear();
            Items.Clear();
            
            var people = await swapiService.GetPeople();
            
            if (People.Count != 0) People.Clear();

            foreach (var person in people)
            {
                People.Add(person);
                Items.Add(new ListItem 
                {
                    Headline = person.Name,
                    Subtitle = person.Gender
                });
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);

            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    private async Task GetFilmsAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            
            People.Clear();
            Items.Clear();

            var films = await swapiService.GetFilms();
            
            if (Films.Count != 0) Films.Clear();

            foreach (var film in films)
            {
                Films.Add(film);
                Items.Add(new ListItem
                {
                    Headline = film.Title,
                    Subtitle = $"Episode {film.EpisodeId}"
                });
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);

            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    private async Task GoToPersonDetailAsync(Person person)
    {
        if (person is null) return;

        await Shell.Current.GoToAsync($"{nameof(DetailPage)}", true, new Dictionary<string, object>
        {
            { "Person", person },
            { "Title", person.Name}
        });
    }
    
    [RelayCommand]
    private async Task GoToFilmDetailAsync(Film film)
    {
        if (film is null) return;

        await Shell.Current.GoToAsync($"{nameof(DetailPage)}", true, new Dictionary<string, object>
        {
            { "Film", film },
            { "Title", film.Title}
        });
    }
}