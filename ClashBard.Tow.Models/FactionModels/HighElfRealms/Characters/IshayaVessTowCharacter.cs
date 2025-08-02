using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.Models.Armors;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms.Characters;

public class IshayaVessTowCharacter : TowCharacter
{
    private static int pointsCost = 170;

    public IshayaVessTowCharacter(TowObject owner)
        : base(owner, HighElvesTowModelType.IshayaVess, 5, 7, 7, 4, 3, 3, 7, 3, 9, pointsCost,
               TowModelTroopType.RegularInfantryCharacter, new HighElvesTowFaction(), 25, 25,
               new TowMagicItemCategory[] { }, mayBuyMagicItemsUpToPoints: 0)
    {
        // special rules - as per official rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        
        // Named character equipment (fixed)
        // Hand weapon - inherited from TowModel base class
        Assign(new MathlannsIreTowWeapon(this)); // Mathlann's Ire magic weapon
        Assign(new WarbowTowWeapon(this)); // Warbow
        
        // Armor
        Assign(new HeavyArmourTowArmour(this)); // Heavy armour
        Assign(new ShieldTowArmour(this)); // Shield
        
        // General option (0 points from JSON)
        // Characters can be generals by default in this system
        
        // Named characters cannot take additional equipment
        // All equipment is fixed as per character sheet
    }
}
