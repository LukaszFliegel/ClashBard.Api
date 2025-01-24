using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModelMount: TowObjectWithSpecialRules, ISaveImprover
{
    public TowModelMount(TowObject owner, TowModelMountType modelType, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction,
        int baseSizeWidth, int baseSizeLength, int minUnitSize = 1, int? maxUnitSize = null, int? armorValue = null)
        :base(owner)
    {
        ModelMountType = modelType;
        Movement = m;
        WeaponSkill = ws;
        BallisticSkill = bs;
        Strength = s;
        Toughness = t;
        ToughnessAdded = toughnessAdded;
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

        Assign(new HandWeaponTowWeapon(this));
    }

    public TowModelMountType ModelMountType { get; set; }
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

    public ICollection<(TowWeaponType, int)> AvailableWeapons { get; protected set; } = new HashSet<(TowWeaponType, int)>() { };

    private ICollection<TowWeapon> Weapons { get; set; } = new List<TowWeapon>() { };

    public TowModelTroopType ModelTroopType { get; set; }

    public ICollection<TowModelAdditional> Crew { get; set; } = new HashSet<TowModelAdditional>();


    //public virtual required int FactionId { get; set; }
    public TowFaction Faction { get; set; }

    public int? MeleeSaveBaseline => ArmorValue.HasValue ? ArmorValue.Value : null;

    public int MeleeSaveImprovement => 0;

    public int? RangedSaveBaseline => ArmorValue.HasValue ? ArmorValue.Value : null;

    public int RangedSaveImprovement => 0;

    public bool AsteriskOnSave => false;

    public void Assign(TowWeapon weapon)
    {
        Weapons.Add(weapon);
    }

    public int UnitStrength()
    {
        switch (ModelTroopType)
        {
            case TowModelTroopType.LightCavalry:
                return 2;
            case TowModelTroopType.HeavyCavalry:
                return 2;
            case TowModelTroopType.MonstrousCavalry:
                return 3;
            case TowModelTroopType.HeavyChariot:
                return 5;
            case TowModelTroopType.LightChariot:
                return 3;
            default:
                throw new Exception($"Unit strength of mount with model troop type {ModelTroopType} unknown");
        }
    }
}
