using System.Text.Json.Serialization;

namespace SwapiMaui.Model;

public class Film
{
    public string Title { get; set; }

    [JsonPropertyName("episode_id")]
    public int EpisodeId { get; set; }

    [JsonPropertyName("opening_crawl")]
    public string OpeningCrawl { get; set; }

    public string Director { get; set; }

    public string Producer { get; set; }

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }

    public string[] Characters { get; set; }

    public string[] Species { get; set; }

    public string[] Planets { get; set; }

    public string[] Vehicles { get; set; }

    public string[] Starships { get; set; }
}

[JsonSerializable(typeof(List<Film>))]
internal sealed partial class FilmContext : JsonSerializerContext;