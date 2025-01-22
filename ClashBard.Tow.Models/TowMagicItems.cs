using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System.Reflection;
using System.Text;

namespace ClashBard.Tow.Models;

public abstract class TowMagicItem: TowObjectWithSpecialRules
{    
    public TowMagicItem(Enum magicItemType, int points, TowMagicItemCategory towMagicItemCategory)
    {
        MagicItemType = magicItemType;
        Points = points;
        TowMagicItemCategory = towMagicItemCategory;
    }

    public TowMagicItemCategory TowMagicItemCategory { get; private set; }
    public Enum MagicItemType { get; set; }
    public int Points { get; }

    public string GetMagicItemRulesShortDescription()
    {
        StringBuilder shortDescriptionSb = new();
        string separator = ClashBardStatic.Separator;

        foreach (var rule in SpecialRules.Where(p => p.PrintInSummary))
        {
            shortDescriptionSb.Append(rule.GetShortDescription() + separator);
        }

        return shortDescriptionSb.ToString().TrimEnd(separator.ToCharArray());
    }
}

public class TowMagicWeapon : TowMagicItem
{
    public TowMagicWeapon(TowMagicItemWeaponType magicWeaponType, int points, int? range, TowWeaponStrength strength, int armorPiercing)
        :base(magicWeaponType, points, TowMagicItemCategory.MagicWeapon)
    {
        MagicWeaponType = magicWeaponType;
        Range = range;
        Strength = strength;
        ArmorPiercing = armorPiercing;
    }

    public TowMagicItemWeaponType MagicWeaponType { get; set; }

    public int? Range { get; set; } = 0; // 0 means range "Combat"

    public TowWeaponStrength Strength { get; set; }

    public int ArmorPiercing { get; set; }    
}

public class TowMagicArmour : TowMagicItem
{
    public TowMagicArmour(TowMagicItemArmorType armorType, int points,
        int armoursSaveValue, int wardSaveValue = 0)
        : this(armorType, points, 
              armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue, armoursSaveValue,
              wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue, wardSaveValue)
    {

    }

    public TowMagicArmour(TowMagicItemArmorType armorType, int points,
        int meleeSaveBaseline, int meleeSaveImprovement, int rangedSaveBaseline, int rangedSaveImprovement, int magicMeleeSaveBaseline, int magicMeleeSaveImprovement, int magicRangedSaveBaseline, int magicRangedSaveImprovement, 
        int meleeWardSaveBaseline = 0, int meleeWardSaveImprovement = 0, int rangedWardSaveBaseline = 0, int rangedWardSaveImprovement = 0, int magicWardMeleeSaveBaseline = 0, int magicWardMeleeSaveImprovement = 0, int magicWardRangedSaveBaseline = 0, int magicWardRangedSaveImprovement = 0)
        : base(armorType, points, TowMagicItemCategory.MagicArmour)
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

    public TowMagicItemArmorType ArmorType { get; set; }

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
    public TowTalisman(TowMagicItemTalismanType talismanType, int points)
        : base(talismanType, points, TowMagicItemCategory.Talisman)
    {
        
    }
}

public class TowEnchantedItem : TowMagicItem
{
    public TowEnchantedItem(TowMagicItemEnchantedType talismanType, int points)
        : base(talismanType, points, TowMagicItemCategory.EnchantedItem)
    {

    }
}

public class TowArcaneItem : TowMagicItem
{
    public TowArcaneItem(TowMagicItemArcaneType arcaneType, int points)
        : base(arcaneType, points, TowMagicItemCategory.Arcane)
    {

    }
}

public class TowMagicBanner : TowMagicItem
{
    public TowMagicBanner(TowMagicItemBannerType magicBannerType, int points)
        : base(magicBannerType, points, TowMagicItemCategory.MagicBanner)
    {

    }
}