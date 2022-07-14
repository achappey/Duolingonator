using System.ComponentModel.DataAnnotations;

namespace Duolingonator.Models;

public class Language
{
    public string Name { get; set; } = null!;

    [Key]
    public string Code { get; set; } = null!;

    public int Points { get; set; }

    public int Level { get; set; }

}