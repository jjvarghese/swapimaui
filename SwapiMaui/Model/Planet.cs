using System;
using System.Text.Json.Serialization;

namespace SwapiMaui.Model;

public class Planet
{
    public string Name { get; set; }

    public string Climate { get; set; }

    public string Gravity { get; set; }

    [JsonPropertyName("orbital_period")]
    public string OrbitalPeriod { get; set; }

    public string Terrain { get; set; }
}

[JsonSerializable(typeof(List<Planet>))]
internal sealed partial class PlanetContext : JsonSerializerContext;