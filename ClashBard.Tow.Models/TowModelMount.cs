using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModelMount
{
    public TowModelMount(Enum modelType, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction,
        int baseSizeWidth, int baseSizeLength, int minUnitSize = 1, int? maxUnitSize = null, int? armorValue = null)
    {
        ModelType = modelType;
        Movement = m;
        WeaponSkill = ws;
        BallisticSkill = bs;
        Strength = s;
        Toughness = t;
        Wounds = w;
        WoundsAdded = woundsAdded;
        Initiative = i;
        Attacks = a;
        Leadership = ld;
        PointCost = pointCost;
        ModelTroopType = modelTroopType;
        //ModelSlotType = modelSlotType;
        Faction = faction;

        BaseSizeWidth = baseSizeWidth;
        BaseSizeLength = baseSizeLength;
        MinUnitSize = minUnitSize;
        MaxUnitSize = maxUnitSize;
        ArmorValue = armorValue;
    }

    public Enum ModelType { get; set; }
    public int? Movement { get; set; }
    public int? WeaponSkill { get; set; }
    public int? BallisticSkill { get; set; }
    public int Strength { get; set; }
    public int? Toughness { get; set; } = null;
    public int? ToughnessAdded { get; set; } = null;
    public int? Wounds { get; set; } = null;
    public int? WoundsAdded { get; set; } = null;
    public int? Initiative { get; set; }
    public int? Attacks { get; set; }
    public int? Leadership { get; set; }

    public int PointCost { get; set; }

    public int? ArmorValue { get; set; }

    public int BaseSizeWidth { get; set; }
    public int BaseSizeLength { get; set; }

    public int MinUnitSize { get; set; }
    public int? MaxUnitSize { get; set; }

    public virtual ICollection<(TowWeaponType, int)> AvailableWeapons { get; protected set; } = new HashSet<(TowWeaponType, int)>() { };

    public virtual ICollection<TowWeapon> Weapons { get; protected set; } = new List<TowWeapon>() { new HandWeaponTowWeapon() };

    public TowModelTroopType ModelTroopType { get; set; }

    public virtual ICollection<TowModelAdditional> Crew { get; set; } = new HashSet<TowModelAdditional>();


    //public virtual required int FactionId { get; set; }
    public virtual TowFaction Faction { get; set; }
    public ICollection<TowSpecialRule> SpecialRules { get; set; } = new HashSet<TowSpecialRule>() { };
}
