using System.Net.Http.Json;
using SwapiMaui.Model;

namespace SwapiMaui.Service;

public class SwapiService
{
    private List<Person> people = new List<Person>();

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
            var url = "https://swapi.dev/api/people";
            var response = await httpClient.GetFromJsonAsync<SwapiResponse<Person>>(url);

            if (response.Results.Count > 0)
            {
                people = response?.Results ?? [];

            }

            return people;
        }
    }
}