using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;

public class ManticoreTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 130;
    private static DarkElfTowModelMountType modelType = DarkElfTowModelMountType.Manticore;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.MonstrousCreature;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int armourValue = 5;

    public ManticoreTowCharacterMount(TowObject owner) : this(owner, m: 6, ws: 5, bs: null, s: 5, t: null, toughnessAdded: 1, w: null, woundsAdded: 4, i: 5, a: 4, ld: null)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new Fly9());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new StompAttacksD3());
        AssignSpecialRule(new Swiftstride());
        AssignSpecialRule(new Terror());
        AssignSpecialRule(new WilfulBeast());

        // weapons
        AssignDefault(new WickedClawsTowWeapon(this));

        AvailableWeapons.Add((TowWeaponType.VenomousTail, 15));
    }

    protected ManticoreTowCharacterMount(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int i, int a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
    }
}
