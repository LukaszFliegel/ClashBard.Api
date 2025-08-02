using ClashBard.Tow.Models.Armors;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class SeaGuardGarrisonCommanderTowCharacter : TowCharacter
{
    private static int pointsCost = 90;

    public SeaGuardGarrisonCommanderTowCharacter(TowObject owner)
        : base(owner, HighElvesTowModelType.SeaGuardGarrisonCommander, 5, 6, 7, 4, 3, 2, 5, 3, 9, pointsCost,
               TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25,
               new TowMagicItemCategory[] { TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.MagicArmour, 
                                           TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem }, 
               mayBuyMagicItemsUpToPoints: 75)
    {
        // Special rules - as per official rules and JSON
        AssignSpecialRule(new AccomplishedArchers());
        AssignSpecialRule(new IthilmarWeapons());
        AssignSpecialRule(new NavalDiscipline());
        AssignSpecialRule(new StrikeFirst());
        AssignSpecialRule(new ValourOfAges());

        // Default equipment - Hand weapon, Warbow, Light armour
        // Hand weapon - inherited from TowModel base class
        Assign(new WarbowTowWeapon(this)); // Default warbow
        Assign(new LightArmourTowArmour(this)); // Default light armour

        // Equipment options
        // Alternative weapon option: Hand weapon + Longbow (4 pts from JSON)
        AvailableWeapons.Add((TowWeaponType.Longbow, 4));

        // Armor options
        AvailableArmours.Add((TowArmourType.HeavyArmour, 3));

        // Equipment options
        AvailableWeapons.Add((TowWeaponType.CavalrySpear, 2)); // if appropriately mounted
        AvailableArmours.Add((TowArmourType.Shield, 2));

        // Mount options
        AvailableMounts.Add((HighElvesTowModelMountType.GreatEagle, 60));
        AvailableMounts.Add((HighElvesTowModelMountType.Griffon, 130));

        // Can be the General (0 points from JSON)
        // Can be Battle Standard Bearer (25 points from JSON)
        // Characters can be generals and BSBs by default in this system
    }
}
