using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class EltharionTheGrimTowCharacter: TowCharacter
{
    private static int pointsCost = 160;

    public EltharionTheGrimTowCharacter(TowObject owner)
        :base(owner, HighElvesTowModelType.EltharionTheGrim, 5, 7, 6, 4, 3, 3, 7, 4, 10, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25,
            new TowMagicItemCategory[] { },
            mayBuyMagicItemsUpToPoints: 0) // Named characters typically can't buy additional magic items
    {
        // special rules
        AssignSpecialRule(new AlwaysStrikesFirst());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MartialProwess());
        AssignSpecialRule(new Terror());
        AssignSpecialRule(new HatredDarkElves());

        // weapons - Eltharion has his signature equipment
        AssignDefault(new HandWeaponTowWeapon(this)); // Default weapon
        AvailableWeapons.Add((TowWeaponType.GreatWeapon, 0)); // Fangsword of Eltharion (no cost as named character equipment)
        AvailableWeapons.Add((TowWeaponType.Longbow, 0)); // Inherited from his elven nature

        // armours - Eltharion has his signature armor
        AssignDefault(new FullPlateArmourTowArmour(this)); // Armour of Yvresse
        AssignDefault(new ShieldTowArmour(this));

        // Named characters typically don't have mount options in basic implementation
        // Could add Stormwing (Griffon) as specific mount later
    }
}
