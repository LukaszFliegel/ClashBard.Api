using ClashBard.Tow.Models.TowTypes;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowArmour: TowObjectWithSpecialRules
{
    public TowArmour(TowArmourType armorType, 
        int? meleeSaveBaseline = null, int? rangedSaveBaseline = null, 
        int? meleeWardSaveBaseline = null, int? rangedWardSaveBaseline = null, 
        int meleeSaveImprovement = 0, int rangedSaveImprovement = 0, 
        int meleeWardSaveImprovement = 0, int rangedWardSaveImprovement = 0,
        bool asteriskOnSave = false, bool asteristOnWardSave = false)
    {
        ArmorType = armorType;
        MeleeSaveBaseline = meleeSaveBaseline;
        MeleeSaveImprovement = meleeSaveImprovement;
        RangedSaveBaseline = rangedSaveBaseline;
        RangedSaveImprovement = rangedSaveImprovement;
        MeleeWardSaveBaseline = meleeWardSaveBaseline;
        MeleeWardSaveImprovement = meleeWardSaveImprovement;
        RangedWardSaveBaseline = rangedWardSaveBaseline;
        RangedWardSaveImprovement = rangedWardSaveImprovement;
        AsteriskOnSave = asteriskOnSave;
        AsteriskOnWardSave = asteristOnWardSave;
    }

    public TowArmourType ArmorType { get; }

    public int? MeleeSaveBaseline { get; }
    public int MeleeSaveImprovement { get; }

    public int? RangedSaveBaseline { get; }
    public int RangedSaveImprovement { get; }


    public int? MeleeWardSaveBaseline { get; }
    public int MeleeWardSaveImprovement { get; }

    public int? RangedWardSaveBaseline { get; }
    public int RangedWardSaveImprovement { get; }

    public bool AsteriskOnSave { get; }
    public bool AsteriskOnWardSave { get; }
}
