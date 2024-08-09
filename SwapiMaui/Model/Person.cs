using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

public class Person
{
    public String Name { get; set; }
    
    public String HairColor { get; set; }
    
    public String SkinColor { get; set; }
    
    public String EyeColor { get; set; }
    
    public String Gender { get; set; }
    
    public String Homeworld { get; set; }
    
    public String[] Films { get; set; }
    
    public String[] Species { get; set; }

    public String[] Vehicles { get; set; }
    
    public String[] Starships { get; set; }
}

[JsonSerializable(typeof(List<Person>))]
internal sealed partial class PersonContext : JsonSerializerContext
{

}