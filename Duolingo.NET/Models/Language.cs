
using System.Text.Json.Serialization;

namespace Duolingo.NET.Models;

public class Language
{


    [JsonPropertyName("language_string")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("language")]
    public string Code { get; set; } = null!;

    [JsonPropertyName("points")]
    public int Points { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

}