using ClashBard.Tow.Models.TowTypes;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowFaction
{
    //[Key]
    //public int Id { get; set; }
    //public required string Name { get; set; }

    public TowFactionType FactionType { get; set; }
}
