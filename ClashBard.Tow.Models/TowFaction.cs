using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowFaction
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
