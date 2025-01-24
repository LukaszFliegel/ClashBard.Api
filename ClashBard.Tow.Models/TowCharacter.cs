using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ClashBard.Tow.Models;

public class TowCharacter : TowModel
{
    public TowCharacter(TowObject owner, Enum modelType, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction,
        int baseSizeWidth, int baseSizeLength,
        TowMagicItemCategory[]? availableMagicItemTypes = null,
        int minUnitSize = 1, int? maxUnitSize = 1, int mayBuyMagicItemsUpToPoints = 0)
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, pointCost, modelTroopType/*, modelSlotType*/, faction, baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize)
    {
        MayBuyMagicItemsUpToPoints = mayBuyMagicItemsUpToPoints;

        if (availableMagicItemTypes != null)
        {
            foreach (var magicItemType in availableMagicItemTypes)
            {
                AvailableMagicItemTypes.Add(magicItemType);
            }
        }
    }

    public int MayBuyMagicItemsUpToPoints { get; private set; }

    public ICollection<TowMagicItemCategory> AvailableMagicItemTypes = new HashSet<TowMagicItemCategory>() { };

    public int CalculateTotalWounds()
    {
        if (Mount != null)
            return Wounds + Mount.WoundsAdded ?? 0;

        return Wounds;
    }

    public void SetMagicItem(TowMagicItem magicItem)
    {
        if (AvailableMagicItemTypes.Contains(magicItem.TowMagicItemCategory))
        {
            MagicItems.Add(magicItem);
        }
    }

    public void SetMagicArmor(TowMagicArmour magicArmour)
    {
        if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.MagicArmour))
        {
            MagicItems.Add(magicArmour);
        }
    }

    public void SetMagicBanner(TowMagicBanner magicBanner)
    {
        if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.MagicBanner))
        {
            MagicItems.Add(magicBanner);
        }
    }

    public void SetEnchantedItem(TowEnchantedItem enchantedItem)
    {
        if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.EnchantedItem))
        {
            MagicItems.Add(enchantedItem);
        }
    }

    public void SetTalisman(TowTalisman talisman)
    {
        if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.Talisman))
        {
            MagicItems.Add(talisman);
        }
    }

    public void SetArcaneItem(TowArcaneItem arcaneItem)
    {
        if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.Arcane))
        {
            MagicItems.Add(arcaneItem);
        }
    }

    public string GetRulesShortDescription()
    {
        StringBuilder shortDescriptionSb = new();
        string separator = ClashBardStatic.Separator;

        foreach (var weapon in GetWeapons().Where(p => p.WeaponType != TowWeaponType.HandWeapon))
        {
            shortDescriptionSb.Append(weapon.WeaponType.ToDescriptionString() + separator);
            shortDescriptionSb.Append(weapon.GetSpecialRulesShortDescription() + separator);
        }

        if(GetWeapons().Where(p => p.WeaponType != TowWeaponType.HandWeapon).Count() != 0)
            shortDescriptionSb.AppendLine();

        // for printing take armour with highest MeleeSaveBaseline and all armours that have any improvement
        List<TowArmour> armoursToPrint = new();

        if (GetArmours().Any(p => p.MeleeSaveBaseline > 0))
            armoursToPrint.Add(GetArmours().Where(p => p.MeleeSaveBaseline > 0).OrderBy(p => p.MeleeSaveBaseline).First());

        armoursToPrint.AddRange(GetArmours().Where(p =>
            p.MeleeSaveImprovement > 0
            || p.RangedSaveImprovement > 0
            || p.MeleeWardSaveImprovement > 0
            || p.RangedWardSaveImprovement > 0
            ));

        foreach (var armor in armoursToPrint)
        {
            shortDescriptionSb.Append(armor.ArmorType.ToDescriptionString() + separator);
            string specialRulesShortDesc = armor.GetSpecialRulesShortDescription();
            shortDescriptionSb.Append(specialRulesShortDesc + (string.IsNullOrEmpty(specialRulesShortDesc) ? string.Empty : separator));
        }

        if(GetArmours().Count != 0)
            shortDescriptionSb.AppendLine();

        foreach (var rule in SpecialRules.Where(p => p.PrintInSummary))
        {
            shortDescriptionSb.Append(rule.GetShortDescription() + separator);
        }

        if (SpecialRules.Count != 0)
            shortDescriptionSb.AppendLine();

        //foreach (var magicItem in MagicItems)
        //{
        //    shortDescriptionSb.Append(magicItem.GetMagicItemRulesShortDescription() + separator);
        //}

        if(Mount != null)
            shortDescriptionSb.Append(Mount.GetSpecialRulesShortDescription() + separator);

        return shortDescriptionSb.ToString().TrimEnd(separator.ToCharArray());
    }

    public int UnitStrength()
    {
        var modelTroopType = Mount != null ? Mount.ModelTroopType : ModelTroopType;

        switch (modelTroopType)
        {
            case TowModelTroopType.RegularInfantry:
            case TowModelTroopType.RegularInfantryCharacter:
                return 1;
            case TowModelTroopType.MonstrousInfantry:
                return 3;
            case TowModelTroopType.LightCavalry:
                return 2;
            case TowModelTroopType.HeavyCavalry:
                return 2;
            case TowModelTroopType.MonstrousCavalry:
                return 3;
            case TowModelTroopType.MonstrousCreature: // as starting wounds
                return CalculateTotalWounds();
            case TowModelTroopType.WarMachine: // as starting wounds
                return CalculateTotalWounds();
            case TowModelTroopType.HeavyChariot:
                return 5;
            case TowModelTroopType.LightChariot:
                return 3;
            case TowModelTroopType.Behemoth: // as starting wounds
                return CalculateTotalWounds();
            case TowModelTroopType.WarBeast:
                return 1;
            case TowModelTroopType.Swarm:
                return 3;
            default:
                throw new Exception("Unknown model type");
        }
    }

    public int CalculateTotalCost()
    {
        int totalCost = PointCost;
        foreach (var magicItem in MagicItems)
        {
            totalCost += magicItem.Points;
        }

        foreach (var availableWeapon in AvailableWeapons)
        {
            if (GetWeapons().Any(p => p.WeaponType == availableWeapon.Item1))
                totalCost += availableWeapon.Item2;
        }

        foreach (var availableArmor in AvailableArmours)
        {
            if (GetArmours().Any(p => p.ArmorType == availableArmor.Item1))
                totalCost += availableArmor.Item2;
        }

        foreach (var specialRule in AvailableSpecialRules)
        {
            if (SpecialRules.Any(p => p.RuleType == specialRule.Item1))
                totalCost += specialRule.Item2;
        }

        foreach (var mount in AvailableMounts)
        {
            if (Mount != null && Mount.ModelMountType == mount.Item1)
            {
                totalCost += mount.Item2;
            }
        }

        return totalCost;
    }
}
