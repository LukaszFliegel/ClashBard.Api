using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ManticoreTowMount : TowModelMount
{
    private static int pointsCost = 130;
    private static TowModelMountType modelType = TowModelMountType.BlackDragon;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.MonstrousCreature;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int minUnitSize = 1;
    private const int maxUnitSize = 1;
    private const int armourValue = 5;

    public ManticoreTowMount() : this(m: 6, ws: 5, bs: null, s: 5, t: null, toughnessAdded: 1, w: null, woundsAdded: 4, i: 5, a: 4, ld: null)
    {
        Weapons.Add(new WickedClawsTowWeapon());

        AvailableWeapons.Add((TowWeaponType.VenomousTail, 15));

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new Fly9());
        SpecialRules.Add(new LargeTarget());
        SpecialRules.Add(new StompAttacksD3());
        SpecialRules.Add(new Swiftstride());
        SpecialRules.Add(new Terror());
        SpecialRules.Add(new WilfulBeast());
    }

    protected ManticoreTowMount(int? m, int ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int i, int a, int? ld) 
        : base(modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize, armourValue)
    {
    }
}
