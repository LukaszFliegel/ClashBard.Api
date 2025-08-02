using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class StormWeaverTowCharacter : TowCharacterMage
{
    private static int pointsCost = 85;

    public StormWeaverTowCharacter(TowObject owner)
        : base(owner, HighElvesTowModelType.StormWeaver, 5, 4, 4, 3, 3, 2, 4, 2, 9, pointsCost,
               TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25, 
               TowMagicLevelType.Level1,
               new TowMagicLoreType[] { TowMagicLoreType.DarkMagic, TowMagicLoreType.Elementalism, TowMagicLoreType.Illusion },
               new TowMagicItemCategory[] { TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, 
                                           TowMagicItemCategory.EnchantedItem, TowMagicItemCategory.Arcane }, 
               mayBuyMagicItemsUpToPoints: 75)
    {
        // Special rules - as per official rules and JSON
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new IthilmarWeapons());
        AssignSpecialRule(new LoreOfSaphery());
        AssignSpecialRule(new ValourOfAges());

        // Default equipment - Hand weapon (inherited from TowModel base class)

        // Wizard level upgrades (from JSON: Level 2 = +30 pts, Level 3 = +60 pts)
        AvailableMagicLevels.Add((TowMagicLevelType.Level2, 30));
        AvailableMagicLevels.Add((TowMagicLevelType.Level3, 60));

        // Mount options (from JSON: Unicorn = 35 pts)
        AvailableMounts.Add((HighElvesTowModelMountType.Unicorn, 35));
    }
}
