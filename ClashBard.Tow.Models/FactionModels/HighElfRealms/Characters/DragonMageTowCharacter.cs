using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.Models.Armors;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class DragonMageTowCharacter : TowCharacterMage
{
    private static int pointsCost = 275;

    public DragonMageTowCharacter(TowObject owner)
        : base(owner, HighElvesTowModelType.DragonMage, null, 4, 4, 3, 5, 6, 5, 2, 8, pointsCost,
               TowModelTroopType.MonstrousCreature, new HighElvesTowFaction(), 60, 100, TowMagicLevelType.Level1,
               new TowMagicLoreType[] { TowMagicLoreType.BattleMagic, TowMagicLoreType.Elementalism },
               new TowMagicItemCategory[] { TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.MagicArmour, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem, TowMagicItemCategory.Arcane },
               mayBuyMagicItemsUpToPoints: 50)
    {
        // Special rules - Dragon Mage has extensive special rules from both mage and dragon
        // Mage special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new BlessingsOfAsuryan());
        // TODO: Add IthilmarWeapons, LileathsBlessing, LoreOfSaphery special rules when implemented
        
        // Dragon special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new DragonArmour());
        AssignSpecialRule(new Fly10());
        AssignSpecialRule(new Impetuous());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new StompAttacksD6());
        AssignSpecialRule(new Swiftstride());
        AssignSpecialRule(new Terror());

        // Equipment
        // Dragon Mage: Hand weapon (inherited), Light armour
        Assign(new LightArmourTowArmour(this));
        
        // Sun Dragon equipment: Wicked claws, Dragon fire, Draconic scales (as full plate armour)
        // These are inherent to the dragon and don't need separate assignment
        
        // Magic level upgrade
        AvailableMagicLevels.Add((TowMagicLevelType.Level2, 30));
        
        // Dragon Mage is permanently mounted on Sun Dragon - no mount options
        // Base size reflects dragon: 60x100mm
        
        // Can be general (0 points from JSON)
        
        // Note: Dragon Mage stats represent the combined character+mount
        // Movement: Sun Dragon has M6, but this is handled by special rules like Fly(10) and Swiftstride
        // The null movement passed to constructor indicates the dragon's movement is handled by special rules
    }
}
