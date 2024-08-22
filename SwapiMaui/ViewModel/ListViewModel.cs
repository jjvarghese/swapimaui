using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using SwapiMaui.Model;
using SwapiMaui.Service;
using SwapiMaui.View;

namespace SwapiMaui.ViewModel;
public partial class ListViewModel : BaseViewModel
{
    private readonly SwapiService swapiService;

    private Collection<Person> People { get; } = new();
    private Collection<Film> Films { get; } = new();
    private Collection<Planet> Planets { get; } = new();

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
            Planets.Clear();

            var people = await swapiService.GetPeople();

            if (People.Count != 0) People.Clear();

            foreach (var person in people)
            {
                People.Add(person);
                Items.Add(new ListItem
                {
                    Headline = person.Name,
                    Subtitle = person.Gender,
                    Person = person
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
            Planets.Clear();

            var films = await swapiService.GetFilms();

            if (Films.Count != 0) Films.Clear();

            foreach (var film in films)
            {
                Films.Add(film);
                Items.Add(new ListItem
                {
                    Headline = film.Title,
                    Subtitle = $"Episode {film.EpisodeId}",
                    Film = film
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
    private async Task GetPlanetsAsync()
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
            People.Clear();

            var planets = await swapiService.GetPlanets();

            if (Planets.Count != 0) Planets.Clear();

            foreach (var planet in planets)
            {
                Planets.Add(planet);
                Items.Add(new ListItem
                {
                    Headline = planet.Name,
                    Subtitle = planet.Climate,
                    Planet = planet
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
    private async Task GoToDetailsAsync(ListItem item)
    {
        if (item.Person is not null)
        {
            await GoToPersonDetailAsync(item.Person);
        }
        else if (item.Film is not null)
        {
            await GoToFilmDetailAsync(item.Film);
        }
        else if (item.Planet is not null)
        {
            await GoToPlanetDetailAsync(item.Planet);
        }
    }

    private async Task GoToPlanetDetailAsync(Planet planet)
    {
        if (planet is null) return;

        await Shell.Current.GoToAsync($"{nameof(DetailPage)}", true, new Dictionary<string, object>
        {
            { "Planet", planet },
            { "Title", planet.Name}
        });
    }

    private async Task GoToPersonDetailAsync(Person person)
    {
        if (person is null) return;

        await Shell.Current.GoToAsync($"{nameof(DetailPage)}", true, new Dictionary<string, object>
        {
            { "Person", person },
            { "Title", person.Name}
        });
    }

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