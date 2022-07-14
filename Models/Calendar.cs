
namespace Duolingonator.Models;

public class Calendar
{
    public string Skill { get; set; } = null!;

    public string EventType { get; set; } = null!;

    public int Improvement { get; set; }

    public DateTimeOffset DateTime { get; set; }


}