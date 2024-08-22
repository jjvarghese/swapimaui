using System.Text.Json.Serialization;

namespace SwapiMaui.Model;

public class Person
{
    public string Name { get; set; }

    [JsonPropertyName("hair_color")]
    public string HairColor { get; set; }

    [JsonPropertyName("skin_color")]
    public string SkinColor { get; set; }

    [JsonPropertyName("eye_color")]
    public string EyeColor { get; set; }

    public string Gender { get; set; }

    public string Homeworld { get; set; }

    public string[] Films { get; set; }

    public string[] Species { get; set; }

    public string[] Vehicles { get; set; }

    public string[] Starships { get; set; }
}

[JsonSerializable(typeof(List<Person>))]
internal sealed partial class PersonContext : JsonSerializerContext;