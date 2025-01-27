using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters;

public class DarkElfDreadlordTowCharacter: TowCharacter
{
    private static int pointsCost = 130;

    public DarkElfDreadlordTowCharacter(TowObject owner)
        :base(owner, DarkElfTowModelType.DarkElfDreadlord, 5, 7, 7, 4, 3, 3, 6, 4, 10, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new DarkElvesTowFaction(), 25, 25,
            new TowMagicItemCategory[] { TowMagicItemCategory.MagicArmour, TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 100)
    {
        AvailableArmours.Add((TowArmourType.LightArmour, 0));
        AvailableArmours.Add((TowArmourType.HeavyArmour, 3));
        AvailableArmours.Add((TowArmourType.FullPlateArmour, 6));
        AvailableArmours.Add((TowArmourType.Shield, 2));
        AvailableArmours.Add((TowArmourType.SeaDragonCloak, 4));

        AvailableWeapons.Add((TowWeaponType.RepeaterCrossbow, 6));
        AvailableWeapons.Add((TowWeaponType.RepeaterHandbow, 5));
        AvailableWeapons.Add((TowWeaponType.BraceOfRepeaterHandbows, 10));

        AvailableWeapons.Add((TowWeaponType.AdditionalHandWeapon, 3));
        AvailableWeapons.Add((TowWeaponType.GreatWeapon, 4));
        AvailableWeapons.Add((TowWeaponType.Halberd, 3));
        AvailableWeapons.Add((TowWeaponType.Lance, 4));

        AssignSpecialRule(new EternalHatred());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new StrikeFirst());

        AvailableMounts.Add((TowModelMountType.DarkSteed, 14));
        AvailableMounts.Add((TowModelMountType.ColdOne, 18));
        AvailableMounts.Add((TowModelMountType.ColdOneChariot, 125));
        AvailableMounts.Add((TowModelMountType.BlackDragon, 280));
        AvailableMounts.Add((TowModelMountType.Manticore, 130));

        Assign(new LightArmourTowArmour(this));
    }
}
