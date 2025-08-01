using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class PrinceTowCharacter: TowCharacter
{
    private static int pointsCost = 120;

    public PrinceTowCharacter(TowObject owner)
        :base(owner, HighElvesTowModelType.Prince, 5, 6, 6, 4, 3, 3, 6, 4, 10, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25,
            new TowMagicItemCategory[] { TowMagicItemCategory.MagicArmour, TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 100)
    {
        // special rules
        AssignSpecialRule(new AlwaysStrikesFirst());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new MartialProwess());

        // weapons
        AvailableWeapons.Add((TowWeaponType.Longbow, 5));
        AvailableWeapons.Add((TowWeaponType.AdditionalHandWeapon, 3));
        AvailableWeapons.Add((TowWeaponType.GreatWeapon, 4));
        AvailableWeapons.Add((TowWeaponType.Halberd, 3));
        AvailableWeapons.Add((TowWeaponType.Lance, 4));

        // armours
        AssignDefault(new LightArmourTowArmour(this));

        AvailableArmours.Add((TowArmourType.HeavyArmour, 3));
        AvailableArmours.Add((TowArmourType.FullPlateArmour, 6));
        AvailableArmours.Add((TowArmourType.Shield, 2));        

        // mounts
        AvailableMounts.Add((HighElvesTowModelMountType.ElvenSteed, 12));
        AvailableMounts.Add((HighElvesTowModelMountType.BardedElvenSteed, 18));
        AvailableMounts.Add((HighElvesTowModelMountType.GreatEagle, 40));
        AvailableMounts.Add((HighElvesTowModelMountType.Griffon, 150));
        AvailableMounts.Add((HighElvesTowModelMountType.StarDragon, 350));
        AvailableMounts.Add((HighElvesTowModelMountType.SunDragon, 280));
        AvailableMounts.Add((HighElvesTowModelMountType.MoonDragon, 240));
    }
}
