using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters;

public class SupremeSorceressTowCharacter : TowCharacterMage
{
    private static int pointsCost = 150;

    public SupremeSorceressTowCharacter(TowObject owner)
        :base(owner, DarkElvesTowModelType.SupremeSorceress, 5, 4, 4, 3, 3, 3, 5, 2, 8, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new DarkElvesTowFaction(), 25, 25, TowMagicLevelType.Level3,
            new TowMagicLoreType[] { TowMagicLoreType.BattleMagic, TowMagicLoreType.Daemonology, TowMagicLoreType.DarkMagic, TowMagicLoreType.Elementalism, TowMagicLoreType.Illusion },
            new TowMagicItemCategory[] { TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem, TowMagicItemCategory.Arcane },
            mayBuyMagicItemsUpToPoints: 100)
    {
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new EternalHatred());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new HekartisBlessing());
        AssignSpecialRule(new LoreOfNaggaroth()); // it's a magic lore, shall it be a special rule?
        AssignSpecialRule(new Murderous());

        AvailableMagicLevels.Add((TowMagicLevelType.Level4, 30));

        // weapons

        // armours

        // mounts
        AvailableMounts.Add((DarkElvesTowModelMountType.DarkSteed, 14));
        AvailableMounts.Add((DarkElvesTowModelMountType.ColdOne, 18));
        AvailableMounts.Add((DarkElvesTowModelMountType.DarkPegasus, 35));
        AvailableMounts.Add((DarkElvesTowModelMountType.BlackDragon, 280));

        // lores
    }
}
