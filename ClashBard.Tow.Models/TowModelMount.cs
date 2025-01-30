using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModelMount : TowObjectWithSpecialRules//, ISaveImprover
{
    public TowModelMount(TowObject owner, Enum modelType, int? m, int? ws, int? bs, int s, int? t, int? w, int? i, int? a, int? ld, TowModelTroopType modelTroopType, TowFaction faction,
        int baseSizeWidth, int baseSizeLength)
        :base(owner)
    {
        ModelMountType = modelType;
        Movement = m;
        WeaponSkill = ws;
        BallisticSkill = bs;
        Strength = s;
        Toughness = t;
        //ToughnessAdded = toughnessAdded;
        Wounds = w;
        //WoundsAdded = woundsAdded;
        Initiative = i;
        Attacks = a;
        Leadership = ld;
        //PointCost = pointCost;
        ModelTroopType = modelTroopType;
        Faction = faction;

        BaseSizeWidth = baseSizeWidth;
        BaseSizeLength = baseSizeLength;
        //MinUnitSize = minUnitSize;
        //MaxUnitSize = maxUnitSize;
        //ArmorValue = armorValue;

        //AssignDefault(new HandWeaponTowWeapon(this));
    }

    public Enum ModelMountType { get; set; }
    public int? Movement { get; set; }
    public int? WeaponSkill { get; set; }
    public int? BallisticSkill { get; set; }
    public int Strength { get; set; }
    public int? Toughness { get; set; } = null;
    //public int? ToughnessAdded { get; set; } = null;
    public int? Wounds { get; set; } = null;
    //public int? WoundsAdded { get; set; } = null;
    public int? Initiative { get; set; }
    public int? Attacks { get; set; }
    public int? Leadership { get; set; }

    //public int PointCost { get; set; }

    //public int? ArmorValue { get; set; }

    public int BaseSizeWidth { get; set; }
    public int BaseSizeLength { get; set; }

    //public int MinUnitSize { get; set; }
    //public int? MaxUnitSize { get; set; }

    //public ICollection<(TowWeaponType, int)> AvailableWeapons { get; protected set; } = new HashSet<(TowWeaponType, int)>() { };

    //private ICollection<TowWeapon> Weapons { get; set; } = new List<TowWeapon>() { };

    //public ICollection<TowWeapon> GetWeapons(bool excludeHandWeapon = true)
    //{
    //    return Weapons.Where(p => excludeHandWeapon ? p.WeaponType != TowWeaponType.HandWeapon : true).ToList();
    //}

    public TowModelTroopType ModelTroopType { get; set; }

    //public ICollection<TowModelAdditional> Crew { get; set; } = new HashSet<TowModelAdditional>();


    //public virtual required int FactionId { get; set; }
    public TowFaction Faction { get; set; }

    //public int? MeleeSaveBaseline => ArmorValue.HasValue ? ArmorValue.Value : null;

    //public int MeleeSaveImprovement => 0;

    //public int? RangedSaveBaseline => ArmorValue.HasValue ? ArmorValue.Value : null;

    //public int RangedSaveImprovement => 0;

    //public bool AsteriskOnSave => false;

    // needed?
    //public void Assign(TowWeapon weapon)
    //{
    //    if (!AvailableWeapons.Select(p => p.Item1).Contains(weapon.WeaponType))
    //    {
    //        throw new Exception($"Weapon {weapon.WeaponType} not available for {ModelMountType} mount");
    //    }

    //    // TTA: does mount weapons can have save improvers?
    //    //if (weapon is ISaveImprover saveImprover)
    //    //{
    //    //    SaveImprovers.Add(saveImprover);
    //    //}

    //    //if (weapon is IWardSaveImprover wardSaveImprover)
    //    //{
    //    //    WardSaveImprovers.Add(wardSaveImprover);
    //    //}

    //    Weapons.Add(weapon);
    //}

    //public void AssignDefault(TowWeapon weapon)
    //{
    //    if (!AvailableWeapons.Select(p => p.Item1).Contains(weapon.WeaponType))
    //    {
    //        AvailableWeapons.Add((weapon.WeaponType, 0));
    //    }

    //    // TTA: does mount weapons can have save improvers?
    //    //if (weapon is ISaveImprover saveImprover)
    //    //{
    //    //    SaveImprovers.Add(saveImprover);
    //    //}

    //    //if (weapon is IWardSaveImprover wardSaveImprover)
    //    //{
    //    //    WardSaveImprovers.Add(wardSaveImprover);
    //    //}

    //    Weapons.Add(weapon);
    //}

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
