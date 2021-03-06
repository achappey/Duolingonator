using System.Text.Json.Serialization;

namespace Duolingo.NET.Models;

public class User
{

    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [JsonPropertyName("created_dt")]
    public long CreatedDate { get; set; }

    [JsonPropertyName("bio")]
    public string? Bio { get; set; }

    [JsonPropertyName("learning_language")]
    public string LearningLanguage { get; set; } = null!;

    [JsonPropertyName("site_streak")]
    public int SiteStreak { get; set; }

    [JsonPropertyName("languages")]
    public IEnumerable<Language> Languages { get; set; } = null!;

    [JsonPropertyName("language_data")]
    public Dictionary<string, LanguageData> LanguageData { get; set; } = null!;

    [JsonPropertyName("tracking_properties")]
    public TrackingProperties TrackingProperties { get; set; } = null!;
}

public class TrackingProperties
{

    [JsonPropertyName("num_followers")]
    public int NumFollowers { get; set; }

}