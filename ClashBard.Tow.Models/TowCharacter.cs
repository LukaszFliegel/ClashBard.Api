using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System.Text;

namespace ClashBard.Tow.Models;

public class TowCharacter : TowModel
{
    public TowCharacter(TowObject owner, Enum modelType, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld, int pointCost,
        TowModelTroopType modelTroopType, TowFaction faction,
        int? baseSizeWidth, int? baseSizeLength,
        TowMagicItemCategory[]? availableMagicItemTypes = null,
        int minUnitSize = 1, int? maxUnitSize = 1, int mayBuyMagicItemsUpToPoints = 0)
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, pointCost, modelTroopType, faction, //new TowArmySlotType[] { TowArmySlotType.Characters }, 
            baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize)
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

    public new TowModelCharacterMount? Mount { get => base.Mount as TowModelCharacterMount; }

    protected ICollection<TowMagicItemCategory> AvailableMagicItemTypes = new HashSet<TowMagicItemCategory>() { };


    //public override IEnumerable<ValidationError> Validate()
    //{
    //    return base.Validate();
    //}


    public void SetMagicItem(TowMagicItem magicItem)
    {
        if (magicItem.Owner != this)
        {
            throw new ArgumentException("Magic item must belong to the same owner");
        }

        if (AvailableMagicItemTypes.Contains(magicItem.TowMagicItemCategory))
        {
            Assign(magicItem);
        }
    }

    //public void SetMagicArmor(TowMagicArmour magicArmour)
    //{
    //    if(magicArmour.Owner != this)
    //    {
    //        throw new ArgumentException("Magic armour must belong to the same owner");
    //    }

    //    if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.MagicArmour))
    //    {
    //        Assign(magicArmour);
    //    }
    //}

    //public void SetMagicStandard(TowMagicStandard magicBanner)
    //{
    //    if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.MagicStandard))
    //    {
    //        MagicItems.Add(magicBanner);
    //    }
    //}

    //public void SetEnchantedItem(TowEnchantedItem enchantedItem)
    //{
    //    if (enchantedItem.Owner != this)
    //    {
    //        throw new ArgumentException("Enchanted tem item must belong to the same owner");
    //    }

    //    if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.EnchantedItem))
    //    {
    //        Assign(enchantedItem);
    //    }
    //}

    //public void SetTalisman(TowTalisman talisman)
    //{
    //    if (talisman.Owner != this)
    //    {
    //        throw new ArgumentException("Talisman item must belong to the same owner");
    //    }

    //    if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.Talisman))
    //    {
    //        Assign(talisman);
    //    }
    //}

    //public void SetArcaneItem(TowArcaneItem arcaneItem)
    //{
    //    if(arcaneItem.Owner != this)
    //    {
    //        throw new ArgumentException("Arcane item must belong to the same owner");
    //    }

    //    if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.Arcane))
    //    {
    //        Assign(arcaneItem);
    //    }
    //}

    public string GetRulesShortDescription()
    {
        StringBuilder shortDescriptionSb = new();
        string separator = ClashBardStatic.Separator;

        //foreach (var weapon in GetWeapons().Where(p => p.WeaponType != TowWeaponType.HandWeapon))
        //{
        //    shortDescriptionSb.Append(weapon.WeaponType.ToDescriptionString() + separator);
        //    shortDescriptionSb.Append(weapon.GetSpecialRulesShortDescription() + separator);
        //}

        //if(GetWeapons().Where(p => p.WeaponType != TowWeaponType.HandWeapon).Count() != 0)
        //    shortDescriptionSb.AppendLine();

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
            shortDescriptionSb.Append(armor.ArmorType.ToNameString() + separator);
            string specialRulesShortDesc = armor.GetSpecialRulesShortDescription();
            shortDescriptionSb.Append(specialRulesShortDesc + (string.IsNullOrEmpty(specialRulesShortDesc) ? string.Empty : separator));
        }

        if(GetArmours().Count != 0)
            shortDescriptionSb.AppendLine();

        foreach (var rule in SpecialRules.Where(p => p.PrintInSummary))
        {
            shortDescriptionSb.Append(rule.GetShortDescription() + separator);
        }

        //if (SpecialRules.Count != 0)
        //    shortDescriptionSb.AppendLine();

        //foreach (var magicItem in MagicItems)
        //{
        //    shortDescriptionSb.Append(magicItem.GetSpecialRulesShortDescription() + separator);
        //}

        if (Mount != null)
        {
            var charactersRuleToExclude = SpecialRules.Select(p => p.RuleType).ToArray();
            shortDescriptionSb.Append(Mount.GetSpecialRulesShortDescription(charactersRuleToExclude) + separator);
        }

        return shortDescriptionSb.ToString().TrimEnd(separator.ToCharArray());
    }

    //public int UnitStrength()
    //{
    //    var modelTroopType = Mount != null ? Mount.ModelTroopType : ModelTroopType;

    //    switch (modelTroopType)
    //    {
    //        case TowModelTroopType.RegularInfantry:
    //        case TowModelTroopType.RegularInfantryCharacter:
    //            return 1;
    //        case TowModelTroopType.MonstrousInfantry:
    //            return 3;
    //        case TowModelTroopType.LightCavalry:
    //            return 2;
    //        case TowModelTroopType.HeavyCavalry:
    //            return 2;
    //        case TowModelTroopType.MonstrousCavalry:
    //            return 3;
    //        case TowModelTroopType.MonstrousCreature: // as starting wounds
    //            return CalculateTotalWounds();
    //        case TowModelTroopType.WarMachine: // as starting wounds
    //            return CalculateTotalWounds();
    //        case TowModelTroopType.HeavyChariot:
    //            return 5;
    //        case TowModelTroopType.LightChariot:
    //            return 3;
    //        case TowModelTroopType.Behemoth: // as starting wounds
    //            return CalculateTotalWounds();
    //        case TowModelTroopType.WarBeast:
    //            return 1;
    //        case TowModelTroopType.Swarm:
    //            return 3;
    //        default:
    //            throw new Exception("Unknown model type");
    //    }
    //}

    public virtual int CalculateTotalCost()
    {
        int totalCost = PointCost;
        foreach (var magicItem in _magicItems)
        {
            if (magicItem is IExtremelyCommon extremelyCommon)
            {
                totalCost += magicItem.Points * extremelyCommon.NumberOfOccurences;
            }
            else
            {
                totalCost += magicItem.Points;
            }
        }

        foreach (var availableWeapon in AvailableWeapons)
        {
            if (GetWeapons().Any(p => p.WeaponType.Equals(availableWeapon.Item1)))
                totalCost += availableWeapon.Item2;
        }

        foreach (var availableArmor in AvailableArmours)
        {
            if (GetArmours().Any(p => p.ArmorType.Equals(availableArmor.Item1)))
                totalCost += availableArmor.Item2;
        }

        foreach (var specialRule in AvailableSpecialRules)
        {
            if (SpecialRules.Any(p => p.RuleType.Equals(specialRule.Item1)))
                totalCost += specialRule.Item2;
        }

        foreach (var mount in AvailableMounts)
        {
            if (Mount != null && Mount.ModelMountType.Equals(mount.Item1))
            {
                totalCost += mount.Item2;
            }
        }

        return totalCost;
    }
}
