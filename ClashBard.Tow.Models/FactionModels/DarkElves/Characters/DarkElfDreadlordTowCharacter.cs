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
        // special rules
        AssignSpecialRule(new EternalHatred());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new StrikeFirst());

        AvailableSpecialRules.Add((TowSpecialRuleType.SeaDragonCloak, 4));

        // weapons
        AvailableWeapons.Add((TowWeaponType.RepeaterCrossbow, 6));
        AvailableWeapons.Add((TowWeaponType.RepeaterHandbow, 5));
        AvailableWeapons.Add((TowWeaponType.BraceOfRepeaterHandbows, 10));

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
        AvailableMounts.Add((DarkElfTowModelMountType.DarkSteed, 14));
        AvailableMounts.Add((DarkElfTowModelMountType.ColdOne, 18));
        AvailableMounts.Add((DarkElfTowModelMountType.ColdOneChariot, 125));
        AvailableMounts.Add((DarkElfTowModelMountType.BlackDragon, 280));
        AvailableMounts.Add((DarkElfTowModelMountType.Manticore, 130));

        
    }
}
