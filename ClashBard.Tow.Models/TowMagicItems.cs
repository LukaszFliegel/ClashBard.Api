using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System.Reflection;
using System.Text;

namespace ClashBard.Tow.Models;

public abstract class TowMagicItem: TowObjectWithSpecialRules
{    
    public TowMagicItem(TowObject owner, Enum magicItemType, int points, TowMagicItemCategory towMagicItemCategory)
        :base(owner)
    {
        MagicItemType = magicItemType;
        Points = points;
        TowMagicItemCategory = towMagicItemCategory;
    }

    public TowMagicItemCategory TowMagicItemCategory { get; private set; }
    public Enum MagicItemType { get; set; }
    public int Points { get; }

    public override bool Equals(object? obj)
    {
        var magicItem = obj as TowMagicItem;

        return magicItem != null && this.MagicItemType == magicItem.MagicItemType;
    }

    //public override bool Equals(object? obj)
    //{
    //    // Check if null or different type
    //    if (obj == null || GetType() != obj.GetType())
    //        return false;

    //    var other = obj as TowMagicItem;

    //    // Compare MagicItemType first as it's always used
    //    if (!this.MagicItemType.Equals(other.MagicItemType))
    //        return false;

    //    // Check if either object has IMultiplicable
    //    var thisMultiplicable = this.SpecialRules.OfType<IMultiplicable>().SingleOrDefault();
    //    var otherMultiplicable = other.SpecialRules.OfType<IMultiplicable>().SingleOrDefault();

    //    // If one has IMultiplicable and other doesn't, they're not equal
    //    if ((thisMultiplicable == null) != (otherMultiplicable == null))
    //        return false;

    //    // If both have IMultiplicable, compare their Ids
    //    if (thisMultiplicable != null && otherMultiplicable != null)
    //    {
    //        return thisMultiplicable.Id == otherMultiplicable.Id;
    //    }

    //    // If neither has IMultiplicable, they're equal (as long as MagicItemType matches, which we checked above)
    //    return true;
    //}

    public override int GetHashCode()
    {
        //if(SpecialRules.Any(p => p is IMultiplicable))
        //{
        //    //var extremellyCommonItemIt = SpecialRules.Where(p => p is IMultiplicable).Select(p => p as IMultiplicable).Single().Id;
        //    var extremellyCommonItemIt = SpecialRules.OfType<IMultiplicable>().Single();
        //    return HashCode.Combine(this.MagicItemType.GetHashCode(), extremellyCommonItemIt.Id);
        //}

        return this.MagicItemType.GetHashCode();
    }
}

public class TowMagicWeapon : TowMagicItem
{
    public TowMagicWeapon(TowObject owner, Enum magicWeaponType, int points, int? range, TowWeaponStrength strength, int armorPiercing)
        :base(owner, magicWeaponType, points, TowMagicItemCategory.MagicWeapon)
    {
        MagicWeaponType = magicWeaponType;
        Range = range;
        Strength = strength;
        ArmorPiercing = armorPiercing;
    }

    public Enum MagicWeaponType { get; set; } // TowMagicItemWeaponType

    public int? Range { get; set; } = 0; // 0 means range "Combat"

    public TowWeaponStrength Strength { get; set; }

    public int ArmorPiercing { get; set; }

    public override string GetSpecialRulesShortDescription(TowSpecialRuleType[]? excludeRules = null)
    {
        StringBuilder shortDescriptionSb = new();
        string separator = ClashBardStatic.Separator;

        if (Range.HasValue && Range.Value > 0)
        {
            shortDescriptionSb.Append($"{Range}\"{separator}");
        }

        shortDescriptionSb.Append($"{Strength.ToNameString()}{separator}");

        if (ArmorPiercing > 0)
        {
            shortDescriptionSb.Append($"AP -{ArmorPiercing}{separator}");
        }

        shortDescriptionSb.Append(base.GetSpecialRulesShortDescription());

        return shortDescriptionSb.ToString().TrimEnd(separator.ToCharArray());
    }
}

public class TowMagicArmour : TowMagicItem
{
    public TowMagicArmour(TowObject owner, Enum armorType, int points,
        int armoursSaveValue, int wardSaveValue = 0)
        : this(owner, armorType, points, 
              armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue,
              wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue)
    {

    }

    public TowMagicArmour(TowObject owner, Enum armorType, int points,
        int meleeSaveBaseline, int meleeSaveImprovement, int rangedSaveBaseline, int rangedSaveImprovement, int magicMeleeSaveBaseline, int magicMeleeSaveImprovement, int magicRangedSaveBaseline, int magicRangedSaveImprovement, 
        int meleeWardSaveBaseline = 0, int meleeWardSaveImprovement = 0, int rangedWardSaveBaseline = 0, int rangedWardSaveImprovement = 0, int magicWardMeleeSaveBaseline = 0, int magicWardMeleeSaveImprovement = 0, int magicWardRangedSaveBaseline = 0, int magicWardRangedSaveImprovement = 0)
        : base(owner, armorType, points, TowMagicItemCategory.MagicArmour)
    {
        ArmorType = armorType;
        MeleeSaveBaseline = meleeSaveBaseline;
        MeleeSaveImprovement = meleeSaveImprovement;
        RangedSaveBaseline = rangedSaveBaseline;
        RangedSaveImprovement = rangedSaveImprovement;
        MagicMeleeSaveBaseline = magicMeleeSaveBaseline;
        MagicMeleeSaveImprovement = magicMeleeSaveImprovement;
        MagicRangedSaveBaseline = magicRangedSaveBaseline;
        MagicRangedSaveImprovement = magicRangedSaveImprovement;
        MeleeWardSaveBaseline = meleeWardSaveBaseline;
        MeleeWardSaveImprovement = meleeWardSaveImprovement;
        RangedWardSaveBaseline = rangedWardSaveBaseline;
        RangedWardSaveImprovement = rangedWardSaveImprovement;
        MagicWardMeleeSaveBaseline = magicWardMeleeSaveBaseline;
        MagicWardMeleeSaveImprovement = magicWardMeleeSaveImprovement;
        MagicWardRangedSaveBaseline = magicWardRangedSaveBaseline;
        MagicWardRangedSaveImprovement = magicWardRangedSaveImprovement;
    }

    public Enum ArmorType { get; set; } // TowMagicItemArmorType

    // armour save
    public int MeleeSaveBaseline { get; set; }
    public int MeleeSaveImprovement { get; set; }

    public int RangedSaveBaseline { get; set; }
    public int RangedSaveImprovement { get; set; }


    public int MagicMeleeSaveBaseline { get; set; }
    public int MagicMeleeSaveImprovement { get; set; }

    public int MagicRangedSaveBaseline { get; set; }
    public int MagicRangedSaveImprovement { get; set; }

    // ward save
    public int MeleeWardSaveBaseline { get; set; }
    public int MeleeWardSaveImprovement { get; set; }

    public int RangedWardSaveBaseline { get; set; }
    public int RangedWardSaveImprovement { get; set; }


    public int MagicWardMeleeSaveBaseline { get; set; }
    public int MagicWardMeleeSaveImprovement { get; set; }

    public int MagicWardRangedSaveBaseline { get; set; }
    public int MagicWardRangedSaveImprovement { get; set; }
}

public class TowTalisman : TowMagicItem
{
    public TowTalisman(TowObject owner, Enum talismanType, int points) // Enum = TowMagicItemTalismanType
        : base(owner, talismanType, points, TowMagicItemCategory.Talisman)
    {
        
    }
}

public class TowEnchantedItem : TowMagicItem
{
    public TowEnchantedItem(TowObject owner, Enum talismanType, int points) // Enum = TowMagicItemEnchantedType
        : base(owner, talismanType, points, TowMagicItemCategory.EnchantedItem)
    {

    }
}

public class TowArcaneItem : TowMagicItem
{
    public TowArcaneItem(TowObject owner, Enum arcaneType, int points) // Enum = TowMagicItemArcaneType
        : base(owner, arcaneType, points, TowMagicItemCategory.Arcane)
    {

    }
}

public class TowMagicStandard : TowMagicItem
{
    public TowMagicStandard(TowObject owner, Enum magicStandardType, int points) // Enum = TowMagicItemBannerType
        : base(owner, magicStandardType, points, TowMagicItemCategory.MagicStandard)
    {

    }
}