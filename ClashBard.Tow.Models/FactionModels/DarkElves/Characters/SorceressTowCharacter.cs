using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters;

public class SorceressTowCharacter : TowCharacterMage
{
    private static int pointsCost = 75;

    public SorceressTowCharacter(TowObject owner)
        :base(owner, DarkElfTowModelType.Sorceress, 5, 4, 4, 3, 3, 2, 4, 1, 8, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new DarkElvesTowFaction(), 25, 25, TowMagicLevelType.Level1,
            new TowMagicLoreType[] { TowMagicLoreType.BattleMagic, TowMagicLoreType.Daemonology, TowMagicLoreType.DarkMagic, TowMagicLoreType.Elementalism, TowMagicLoreType.Illusion },
            new TowMagicItemCategory[] { TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem, TowMagicItemCategory.Arcane },
            mayBuyMagicItemsUpToPoints: 50)
    {
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new EternalHatred());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new HekartisBlessing());
        AssignSpecialRule(new LoreOfNaggaroth()); // it's a magic lore, shall it be a special rule?
        AssignSpecialRule(new Murderous());

        AvailableMagicLevels.Add((TowMagicLevelType.Level2, 30));

        // weapons

        // armours

        // mounts
        AvailableMounts.Add((DarkElfTowModelMountType.DarkSteed, 14));
        AvailableMounts.Add((DarkElfTowModelMountType.ColdOne, 18));
        AvailableMounts.Add((DarkElfTowModelMountType.DarkPegasus, 35));
    }
}
