using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModelCharacterMount: TowModelMount, ISaveImprover
{
    public TowModelCharacterMount(TowObject owner, Enum modelType, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction,
        int baseSizeWidth, int baseSizeLength, /*int minUnitSize = 1, int? maxUnitSize = null,*/ int? armorValue = null)
        :base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, modelTroopType, faction, baseSizeWidth, baseSizeLength)
    {
        ToughnessAdded = toughnessAdded;
        WoundsAdded = woundsAdded;
        PointCost = pointCost;

        ArmorValue = armorValue;

        AssignDefault(new HandWeaponTowWeapon(this));
    }

    public int? ToughnessAdded { get; set; } = null;
    public int? WoundsAdded { get; set; } = null;

    public int PointCost { get; set; }

    public int? ArmorValue { get; set; }

    //public int MinUnitSize { get; set; }
    //public int? MaxUnitSize { get; set; }

    public ICollection<(TowWeaponType, int)> AvailableWeapons { get; protected set; } = new HashSet<(TowWeaponType, int)>() { };

    private ICollection<TowWeapon> Weapons { get; set; } = new List<TowWeapon>() { };

    public ICollection<TowWeapon> GetWeapons(bool excludeHandWeapon = true)
    {
        return Weapons.Where(p => excludeHandWeapon ? p.WeaponType != TowWeaponType.HandWeapon : true).ToList();
    }

    public ICollection<TowModelAdditional> Crew { get; set; } = new HashSet<TowModelAdditional>();

    protected ICollection<TowMagicItem> MagicItems { get; set; } = new HashSet<TowMagicItem>();

    public virtual ICollection<TowMagicItem> GetMagicItems()
    {
        return MagicItems.ToList();
    }

    public int? MeleeSaveBaseline => ArmorValue.HasValue ? ArmorValue.Value : null;

    public int MeleeSaveImprovement => 0;

    public int? RangedSaveBaseline => ArmorValue.HasValue ? ArmorValue.Value : null;

    public int RangedSaveImprovement => 0;

    public bool AsteriskOnSave => false;

    // needed?
    public void Assign(TowWeapon weapon)
    {
        if (!AvailableWeapons.Select(p => p.Item1).Contains(weapon.WeaponType))
        {
            throw new Exception($"Weapon {weapon.WeaponType} not available for {ModelMountType} mount");
        }

        // TTA: does mount weapons can have save improvers?
        //if (weapon is ISaveImprover saveImprover)
        //{
        //    SaveImprovers.Add(saveImprover);
        //}

        //if (weapon is IWardSaveImprover wardSaveImprover)
        //{
        //    WardSaveImprovers.Add(wardSaveImprover);
        //}

        Weapons.Add(weapon);
    }

    public void AssignDefault(TowWeapon weapon)
    {
        if (!AvailableWeapons.Select(p => p.Item1).Contains(weapon.WeaponType))
        {
            AvailableWeapons.Add((weapon.WeaponType, 0));
        }

        // TTA: does mount weapons can have save improvers?
        //if (weapon is ISaveImprover saveImprover)
        //{
        //    SaveImprovers.Add(saveImprover);
        //}

        //if (weapon is IWardSaveImprover wardSaveImprover)
        //{
        //    WardSaveImprovers.Add(wardSaveImprover);
        //}

        Weapons.Add(weapon);
    }
}
