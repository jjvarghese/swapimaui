using System.Net.Http.Json;

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
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                people = await response.Content.ReadFromJsonAsync<List<Person>>();
                
            }

            return people;
        }
    }
}