using System.Net.Http.Json;
using SwapiMaui.Model;

namespace SwapiMaui.Service;

public class SwapiService
{
    private const string BaseUrl = "https://swapi.dev/api";

    private List<Person> people = new List<Person>();
    private List<Film> films = new List<Film>();
    private List<Planet> planets = new List<Planet>();

    private HttpClient httpClient;

    public SwapiService()
    {
        httpClient = new HttpClient();
    }

    public async Task<List<Person>> GetPeople()
    {
        if (people.Count > 0)
        {
            return people;
        }
        else
        {
            const string url = $"{BaseUrl}/people";

            var response = await httpClient.GetFromJsonAsync<SwapiResponse<Person>>(url);

            if (response.Results.Count > 0)
            {
                people = response?.Results ?? [];

            }

            return people;
        }
    }

    public async Task<List<Film>> GetFilms()
    {
        if (films.Count > 0)
        {
            return films;
        }
        else
        {
            const string url = $"{BaseUrl}/films";

            var response = await httpClient.GetFromJsonAsync<SwapiResponse<Film>>(url);

            if (response.Results.Count > 0)
            {
                films = response?.Results ?? [];

            }

            return films.OrderBy(film => film.EpisodeId).ToList();
        }
    }

    public async Task<List<Planet>> GetPlanets()
    {
        if (planets.Count > 0)
        {
            return planets;
        }
        else
        {
            const string url = $"{BaseUrl}/planets";

            var response = await httpClient.GetFromJsonAsync<SwapiResponse<Planet>>(url);

            if (response.Results.Count > 0)
            {
                planets = response?.Results ?? [];

            }

            return planets;
        }
    }
}