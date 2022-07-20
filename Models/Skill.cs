
using System.Text.Json.Serialization;

namespace Duolingonator.Models;

public class Skill
{
    public string LanguageName { get; set; } = null!;

    public string LanguageCode { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Explanation { get; set; }

}