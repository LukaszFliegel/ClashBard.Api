using ClashBard.Tow.Models.TowTypes;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public abstract class TowFaction: TowObject
{
    //[Key]
    //public int Id { get; set; }
    //public required string Name { get; set; }

    public TowFactionType FactionType { get; protected set; }
}
