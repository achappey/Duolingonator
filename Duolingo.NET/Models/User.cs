using System.Text.Json.Serialization;

namespace Duolingo.NET.Models;

public class User
{

    [JsonPropertyName("languages")]
    public IEnumerable<Language> Languages { get; set; } = null!;

    [JsonPropertyName("language_data")]
    public Dictionary<string, LanguageData> LanguageData { get; set; } = null!;


}