using System.Net.Http.Json;
using SwapiMaui.Model;

namespace SwapiMaui.Service;

public class SwapiService
{
    private const string BaseUrl = "https://swapi.dev/api";
    
    private List<Person> people = new List<Person>();
    private List<Film> films = new List<Film>();

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

            return films;
        }
    }
}