using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModel
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public int? Movement { get; set; }
    public int WeaponSkill { get; set; }
    public int BallisticSkill { get; set; }
    public int Strength { get; set; }
    public int Toughness { get; set; }
    public int Wounds { get; set; }
    public int Initiative { get; set; }
    public int Attacks { get; set; }
    public int Leadership { get; set; }

    public int Points { get; set; }
    public TowModelSlotType ModelSlotType { get; set; }

    public TowModelTroopType ModelTroopType { get; set; }
    public int MinUnitSize { get; set; }
    public int MaxUnitSize { get; set; }

    public virtual TowModelMount? Mount { get; set; }
    public virtual ICollection<TowModelAdditional>? Crew { get; set; }

    public virtual required TowFaction Faction { get; set; }
    public ICollection<TowModelSpecialRule>? SpecialRules { get; set; }
}

public enum TowModelSlotType
{
    Character = 1,
    Core,
    Special,
    Rare,
}

public enum TowModelTroopType
{     
    Infantry = 1,
    MonstrousInfantry,
    LightCavalry,    
    HeavyCavalry,
    MonstrousCavalry,
    MonstrousCreature,
    WarMachine,
    HeavyChariot,
    LightChariot,
    Beheamoth,
}