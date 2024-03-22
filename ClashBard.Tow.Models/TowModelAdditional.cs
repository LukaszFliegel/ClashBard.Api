using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModelAdditional
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Movement { get; set; }
    public int WeaponSkill { get; set; }
    public int BallisticSkill { get; set; }
    public int Strength { get; set; }
    public int? Toughness { get; set; }
    public int? Wounds { get; set; }
    public int Initiative { get; set; }
    public int Attacks { get; set; }
    public int Leadership { get; set; }

    //public virtual required int FactionId { get; set; }
    public virtual TowFaction Faction { get; set; }
    public ICollection<TowSpecialRule>? SpecialRules { get; set; }
}
