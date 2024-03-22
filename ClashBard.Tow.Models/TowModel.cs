using ClashBard.Tow.Models.TowTypes;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModel
{
    public TowModel()
    {
        
    }

    public TowModel(Enum modelType, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld)
    {
        ModelType = modelType;
        Movement = m;
        WeaponSkill = ws;
        BallisticSkill = bs;
        Strength = s;
        Toughness = t;
        Wounds = w;
        Initiative = i;
        Attacks = a;
        Leadership = ld;
    }

    //[Key]
    //public int Id { get; set; }
    //public required string Name { get; set; }

    public required Enum ModelType { get; set; }
    public int? Movement { get; set; }
    public int WeaponSkill { get; set; }
    public int BallisticSkill { get; set; }
    public int Strength { get; set; }
    public int Toughness { get; set; }
    public int Wounds { get; set; }
    public int Initiative { get; set; }
    public int Attacks { get; set; }
    public int Leadership { get; set; }

    public virtual ICollection<(TowWeaponType, int)> AvailableWeapons { get; protected set; } = new HashSet<(TowWeaponType, int)>() {  };

    public void AddAvailableWeapon(TowWeaponType weaponType, int points)
    {
        AvailableWeapons.Add((weaponType, points));
    }

    public void RemoveAvailableWeapon(TowWeaponType weaponType, int points)
    {
        AvailableWeapons.Remove((weaponType, points));
    }

    public void AssignWeapon(TowWeapon weapon)
    {
        if (!AvailableWeapons.Any(w => w.Item1 == weapon.WeaponType))
        {
            throw new Exception($"Weapon {weapon.WeaponType} not available for {ModelType} model");
        }

        Weapons.Add(weapon);
    }

    public virtual ICollection<TowWeapon> Weapons { get; protected set; } = new List<TowWeapon>() { TowGlobals.HandWeapon };
    public virtual ICollection<TowArmor> Armors { get; protected set; } = new List<TowArmor>() { };

    public int Points { get; set; }
    public required TowModelSlotType ModelSlotType { get; set; }

    public TowModelTroopType ModelTroopType { get; set; }
    public int MinUnitSize { get; set; }
    public int MaxUnitSize { get; set; }

    public virtual TowModelMount? Mount { get; set; }
    public virtual ICollection<TowModelAdditional>? Crew { get; set; }


    public required virtual TowFaction Faction { get; set; }
    public virtual ICollection<TowSpecialRule>? SpecialRules { get; set; }
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
    //Undefined = 0,
    Infantry = 1,
    MonstrousInfantry,
    LightCavalry,    
    HeavyCavalry,
    MonstrousCavalry,
    MonstrousCreature,
    WarMachine,
    HeavyChariot,
    LightChariot,
    Behemoth,
}
