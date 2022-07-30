namespace Duolingonator.Models;

public class Profile
{
    public string Username { get; set; } = null!;

    public string Bio { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }

    public int Followers { get; set; }

    public int Streak { get; set; }

    public string LearningLanguage { get; set; } = null!;

}
