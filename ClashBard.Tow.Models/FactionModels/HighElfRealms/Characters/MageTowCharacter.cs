using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class MageTowCharacter: TowCharacterMage
{
    private static int pointsCost = 80;

    public MageTowCharacter(TowObject owner)
        :base(owner, HighElvesTowModelType.Mage, 5, 4, 4, 3, 3, 2, 4, 1, 8, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25, TowMagicLevelType.Level1,
            new TowMagicLoreType[] { TowMagicLoreType.BattleMagic, TowMagicLoreType.Elementalism, TowMagicLoreType.HighMagic, TowMagicLoreType.Illusion },
            new TowMagicItemCategory[] { TowMagicItemCategory.Arcane, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 50)
    {
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        // TODO: Add IthilmarWeapons, LileathsBlessing, LoreOfSaphery special rules

        // magic level upgrade
        AvailableMagicLevels.Add((TowMagicLevelType.Level2, 30));

        // weapons
        // Basic mage has no purchasable weapons - special weapons require Elven Honours
        // AvailableWeapons.Add((TowWeaponType.Longbow, 5));

        // armours - Mages typically wear robes, not armor
        // No default armor assigned
        AvailableArmours.Add((TowArmourType.LightArmour, 2));
        AvailableArmours.Add((TowArmourType.Shield, 2));        

        // mounts
        AvailableMounts.Add((HighElvesTowModelMountType.ElvenSteed, 14));
        AvailableMounts.Add((HighElvesTowModelMountType.BardedElvenSteed, 18));
        AvailableMounts.Add((HighElvesTowModelMountType.GreatEagle, 60));
    }
}
