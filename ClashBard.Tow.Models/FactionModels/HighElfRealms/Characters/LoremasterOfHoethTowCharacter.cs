using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class LoremasterOfHoethTowCharacter: TowCharacterMage
{
    private static int pointsCost = 100;

    public LoremasterOfHoethTowCharacter(TowObject owner)
        :base(owner, HighElvesTowModelType.LoremasterOfHoeth, 5, 5, 4, 3, 3, 2, 5, 2, 9, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25, TowMagicLevelType.Level1,
            new TowMagicLoreType[] { TowMagicLoreType.LoreOfSaphery, TowMagicLoreType.BattleMagic, TowMagicLoreType.Elementalism, TowMagicLoreType.Illusion },
            new TowMagicItemCategory[] { TowMagicItemCategory.Arcane, TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 50)
    {
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new AttunedToMagic());
        AssignSpecialRule(new MagicResistance2());
        // Loremaster knows all spells from chosen lore (handled by magic system)

        // weapons - Loremasters are scholar-warriors
        AssignDefault(new HandWeaponTowWeapon(this)); // Default weapon
        AvailableWeapons.Add((TowWeaponType.GreatWeapon, 4));
        AvailableWeapons.Add((TowWeaponType.Longbow, 5));

        // armours
        AssignDefault(new LightArmourTowArmour(this));
        AvailableArmours.Add((TowArmourType.HeavyArmour, 3));
        AvailableArmours.Add((TowArmourType.Shield, 2));

        // mounts
        AvailableMounts.Add((HighElvesTowModelMountType.ElvenSteed, 12));
        AvailableMounts.Add((HighElvesTowModelMountType.BardedElvenSteed, 18));
        AvailableMounts.Add((HighElvesTowModelMountType.GreatEagle, 40));
    }
}
