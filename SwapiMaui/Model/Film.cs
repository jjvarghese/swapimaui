using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace SwapiMaui.Model;

public class Film
{
    public String Title { get; set; }
    
    [JsonPropertyName("episode_id")]
    public int EpisodeId { get; set; }
    
    [JsonPropertyName("opening_crawl")]
    public String OpeningCrawl { get; set; }
    
    public String Director { get; set; }
    
    public String Producer { get; set; }
    
    [JsonPropertyName("release_date")]
    public String ReleaseDate { get; set; }
    
    public String[] Characters { get; set; }
    
    public String[] Species { get; set; }
    
    public String[] Planets { get; set; }

    public String[] Vehicles { get; set; }
    
    public String[] Starships { get; set; }
}

[JsonSerializable(typeof(List<Film>))]
internal sealed partial class FilmContext : JsonSerializerContext;