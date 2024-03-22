using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModelMount
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Movement { get; set; }
    public int? WeaponSkill { get; set; }
    //public int BallisticSkill { get; set; }
    public int Strength { get; set; }
    public int? Toughness { get; set; } = null;
    public int? ToughnessAdded { get; set; } = null;
    public int? Wounds { get; set; } = null;
    public int? WoundsAdded { get; set; } = null;
    public int? Initiative { get; set; }
    public int? Attacks { get; set; }
    //public int Leadership { get; set; }

    public int PointsCostAdded { get; set; }

    public required TowModelTroopType ModelTroopType { get; set; }

    public virtual ICollection<TowModelAdditional>? Crew { get; set; }


    //public virtual required int FactionId { get; set; }
    public required virtual TowFaction Faction { get; set; }
    public ICollection<TowSpecialRule>? SpecialRules { get; set; }
}
