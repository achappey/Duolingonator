namespace Duolingonator.Models;

public class Profile
{
    public string Username { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int Followers { get; set; }

    public int Streak { get; set; }
}
