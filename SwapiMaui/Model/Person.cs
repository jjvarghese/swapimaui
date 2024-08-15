using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace SwapiMaui.Model;
public class Person
{
    public String Name { get; set; }
    
    [JsonPropertyName("hair_color")]
    public String HairColor { get; set; }
    
    [JsonPropertyName("skin_color")]
    public String SkinColor { get; set; }
    
    [JsonPropertyName("eye_color")]
    public String EyeColor { get; set; }
    
    public String Gender { get; set; }
    
    public String Homeworld { get; set; }
    
    public String[] Films { get; set; }
    
    public String[] Species { get; set; }

    public String[] Vehicles { get; set; }
    
    public String[] Starships { get; set; }
}

[JsonSerializable(typeof(List<Person>))]
internal sealed partial class PersonContext : JsonSerializerContext;