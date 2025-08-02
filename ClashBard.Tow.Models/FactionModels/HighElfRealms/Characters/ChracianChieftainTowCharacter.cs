using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.Models.Armors;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class ChracianChieftainTowCharacter : TowCharacter
{
    private static int pointsCost = 105;

    public ChracianChieftainTowCharacter(TowObject owner)
        : base(owner, HighElvesTowModelType.ChracianChieftain, 5, 6, 4, 4, 3, 3, 5, 3, 9, pointsCost,
               TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25,
               new TowMagicItemCategory[] { TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.MagicArmour, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
               mayBuyMagicItemsUpToPoints: 75)
    {
        // Special rules - as per official rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new FuriousCharge());
        AssignSpecialRule(new MoveThroughCover());
        AssignSpecialRule(new StrikeFirst());
        AssignSpecialRule(new Stubborn());
        AssignSpecialRule(new LionCloak());
        // TODO: Add IthilmarWeapons special rule when implemented
        
        // Default equipment
        // Hand weapon - inherited from TowModel base class
        Assign(new HeavyArmourTowArmour(this)); // Heavy armour
        
        // Optional equipment
        AvailableWeapons.Add((TowWeaponType.AdditionalHandWeapon, 4));
        AvailableWeapons.Add((TowWeaponType.ChracianGreatBlade, 3));
        
        // General and BSB options
        // Can be general (0 points from JSON)
        // Can be BSB (25 points from JSON) - handled by system
        
        // Mount options
        // Note: Furious Charge, Move Through Cover and Strike First do not apply to mounts
        // TODO: Add Chieftain's Chariot mount when implemented (105 points)
        
        // Named character-like restrictions but this is a generic character type
        // Can take magic items up to 75 points
    }
}
