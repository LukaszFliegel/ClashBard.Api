using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class HandmaidenOfTheEverqueenTowCharacter : TowCharacter
{
    private static int pointsCost = 65;

    public HandmaidenOfTheEverqueenTowCharacter(TowObject owner)
        : base(owner, HighElvesTowModelType.HandmaidenOfTheEverqueen, 6, 6, 6, 4, 3, 2, 7, 3, 9, pointsCost,
               TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25,
               new TowMagicItemCategory[] { TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.MagicArmour, 
                                           TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem }, 
               mayBuyMagicItemsUpToPoints: 50)
    {
        // Special rules - as per official rules
        AssignSpecialRule(new ArrowsOfIsha());
        AssignSpecialRule(new Evasive());
        AssignSpecialRule(new IgnoresCover());
        AssignSpecialRule(new ImmuneToPsychology());
        AssignSpecialRule(new IthilmarArmour());
        AssignSpecialRule(new IthilmarWeapons());
        AssignSpecialRule(new StrikeFirst());

        // Default equipment
        // Hand weapon - inherited from TowModel base class
        Assign(new HandmaidensSpearTowWeapon(this));
        Assign(new BowOfAvelornTowWeapon(this));
        Assign(new LightArmourTowArmour(this));

        // Equipment options
        AvailableArmours.Add((TowArmourType.HeavyArmour, 3));

        // Equipment options
        AvailableSpecialRules.Add((TowSpecialRuleType.HornOfIsha, 25));

        // Can be the General (0 points from JSON)
        // Characters can be generals by default in this system
    }
}
