
using System.Text.Json.Serialization;

namespace Duolingonator.Models;

public class LanguageData
{
    public IEnumerable<Skill> Skills { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string Code { get; set; } = null!;

    public IEnumerable<Calendar> Calendar { get; set; } = null!;


}