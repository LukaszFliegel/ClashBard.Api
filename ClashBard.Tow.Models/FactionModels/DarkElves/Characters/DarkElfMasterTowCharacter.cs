using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters;

public class DarkElfMasterTowCharacter : TowCharacterBsb
{
    private static int pointsCost = 70;

    public DarkElfMasterTowCharacter(TowObject owner)
        :base(owner, DarkElfTowModelType.DarkElfMaster, 5, 6, 6, 4, 3, 2, 5, 3, 9, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new DarkElvesTowFaction(), 25, 25, 50,
            new TowMagicItemCategory[] { TowMagicItemCategory.MagicArmour, TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 50)
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
        AvailableMounts.Add((TowModelMountType.DarkSteed, 14));
        AvailableMounts.Add((TowModelMountType.ColdOne, 18));
        AvailableMounts.Add((TowModelMountType.ColdOneChariot, 125));
    }
}
