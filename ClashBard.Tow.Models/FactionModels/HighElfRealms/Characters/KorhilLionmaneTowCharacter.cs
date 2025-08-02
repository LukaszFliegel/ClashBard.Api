using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.Models.Armors;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class KorhilLionmaneTowCharacter : TowCharacter
{
    private static int pointsCost = 175;

    public KorhilLionmaneTowCharacter(TowObject owner)
        : base(owner, HighElvesTowModelType.KorhilLionmane, 5, 7, 5, 4, 3, 3, 6, 4, 9, pointsCost,
               TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25,
               new TowMagicItemCategory[] { }, mayBuyMagicItemsUpToPoints: 0)
    {
        // Special rules - as per official rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new FuriousCharge());
        AssignSpecialRule(new MightyConstitution());
        AssignSpecialRule(new MoveThroughCover());
        AssignSpecialRule(new Stubborn());
        
        // Named character equipment (fixed)
        // Hand weapon - inherited from TowModel base class
        Assign(new ChayalTowWeapon(this)); // Chayal magic weapon
        
        // Armor
        Assign(new HeavyArmourTowArmour(this)); // Heavy armour
        // The Pelt of Charandis is an enchanted item that improves armor save and grants Ward Save
        // It's represented as part of the character's inherent defensive abilities
        
        // General option (0 points from JSON)
        // Characters can be generals by default in this system
        
        // Named characters cannot take additional equipment
        // All equipment is fixed as per character sheet
        
        // Note: Furious Charge and Move Through Cover do not apply to mounts
    }
}
