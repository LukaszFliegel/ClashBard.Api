using ClashBard.Tow.Models.TowTypes;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowArmor
{
    //[Key]
    //public int Id { get; set; }
    //public required string Name { get; set; }

    public TowArmor(TowArmorType armorType, int meleeSaveBaseline, int rangedSaveBaseline, int magicMeleeSaveBaseline, int magicRangedSaveBaseline, int meleeSaveImprovement = 0, int rangedSaveImprovement = 0, int magicMeleeSaveImprovement = 0, int magicRangedSaveImprovement = 0)
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
    }

    public TowArmorType ArmorType { get; set; }

    public int MeleeSaveBaseline { get; set; }
    public int MeleeSaveImprovement { get; set; }

    public int RangedSaveBaseline { get; set; }
    public int RangedSaveImprovement { get; set; }


    public int MagicMeleeSaveBaseline { get; set; }
    public int MagicMeleeSaveImprovement { get; set; }

    public int MagicRangedSaveBaseline { get; set; }
    public int MagicRangedSaveImprovement { get; set; }

    public ICollection<TowSpecialRule>? SpecialRules { get; set; }

    //public virtual int? FactionId { get; set; } = null;
    //public virtual TowFaction? Faction { get; set; } = null;
}
