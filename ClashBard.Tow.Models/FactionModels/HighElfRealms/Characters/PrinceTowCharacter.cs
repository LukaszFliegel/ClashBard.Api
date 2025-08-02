using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class PrinceTowCharacter: TowCharacter
{
    private static int pointsCost = 130;

    public PrinceTowCharacter(TowObject owner)
        :base(owner, HighElvesTowModelType.Prince, 5, 7, 7, 4, 3, 3, 6, 4, 10, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25,
            new TowMagicItemCategory[] { TowMagicItemCategory.MagicArmour, TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 100)
    {
        // special rules
        AssignSpecialRule(new IthilmarWeapons());
        AssignSpecialRule(new StrikeFirst());
        AssignSpecialRule(new ValourOfAges());

        // weapons
        AvailableWeapons.Add((TowWeaponType.Longbow, 4));
        AvailableWeapons.Add((TowWeaponType.AdditionalHandWeapon, 3));
        AvailableWeapons.Add((TowWeaponType.CavalrySpear, 2));
        AvailableWeapons.Add((TowWeaponType.GreatWeapon, 4));
        AvailableWeapons.Add((TowWeaponType.Halberd, 3));
        AvailableWeapons.Add((TowWeaponType.Lance, 4));

        // Optional Rules weapon - Bow of Avelorn (from JSON: 12 pts)
        AvailableWeapons.Add((TowWeaponType.BowOfAvelorn, 12));

        // armours
        AssignDefault(new LightArmourTowArmour(this));

        AvailableArmours.Add((TowArmourType.HeavyArmour, 3));
        AvailableArmours.Add((TowArmourType.FullPlateArmour, 6));
        AvailableArmours.Add((TowArmourType.Shield, 2));        

        // mounts
        AvailableMounts.Add((HighElvesTowModelMountType.ElvenSteed, 14));
        AvailableMounts.Add((HighElvesTowModelMountType.BardedElvenSteed, 18));
        AvailableMounts.Add((HighElvesTowModelMountType.GreatEagle, 60));
        AvailableMounts.Add((HighElvesTowModelMountType.Griffon, 130));
        AvailableMounts.Add((HighElvesTowModelMountType.StarDragon, 290));
        AvailableMounts.Add((HighElvesTowModelMountType.SunDragon, 180));
        AvailableMounts.Add((HighElvesTowModelMountType.MoonDragon, 235));
    }
}
