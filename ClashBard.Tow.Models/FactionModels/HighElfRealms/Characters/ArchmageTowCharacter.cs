using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class ArchmageTowCharacter: TowCharacterMage
{
    private static int pointsCost = 155;

    public ArchmageTowCharacter(TowObject owner)
        :base(owner, HighElvesTowModelType.Archmage, 5, 4, 4, 3, 3, 3, 5, 2, 8, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25, TowMagicLevelType.Level3,
            new TowMagicLoreType[] { TowMagicLoreType.BattleMagic, TowMagicLoreType.Elementalism, TowMagicLoreType.HighMagic, TowMagicLoreType.Illusion },
            new TowMagicItemCategory[] { TowMagicItemCategory.Arcane, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 100)
    {
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        // TODO: Missing special rules: IthilmarWeapons, LileathsBlessing, LoreOfSaphery

        // weapons - Archmage has hand weapon by default (from base class)
        // No additional weapon options per official rules

        // armours - Archmages typically wear robes, not armor
        // No default armor assigned

        AvailableArmours.Add((TowArmourType.LightArmour, 2));
        AvailableArmours.Add((TowArmourType.Shield, 2));        

        // mounts
        AvailableMounts.Add((HighElvesTowModelMountType.ElvenSteed, 14));
        AvailableMounts.Add((HighElvesTowModelMountType.BardedElvenSteed, 18));
        AvailableMounts.Add((HighElvesTowModelMountType.GreatEagle, 60));
        AvailableMounts.Add((HighElvesTowModelMountType.StarDragon, 290));
        AvailableMounts.Add((HighElvesTowModelMountType.SunDragon, 180));
        AvailableMounts.Add((HighElvesTowModelMountType.MoonDragon, 235));
        
        // magic level upgrade option
        AvailableMagicLevels.Add((TowMagicLevelType.Level4, 30));
    }
}
