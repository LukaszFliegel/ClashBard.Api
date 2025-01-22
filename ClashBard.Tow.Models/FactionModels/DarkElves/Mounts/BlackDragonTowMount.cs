using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class BlackDragonTowMount : TowModelMount
{
    private static int pointsCost = 280;
    private static TowModelMountType modelType = TowModelMountType.BlackDragon;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.Behemoth;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int minUnitSize = 1;
    private const int maxUnitSize = 1;
    private const int armourValue = 4;

    public BlackDragonTowMount() : this(m: 6, ws: 6, bs: null, s: 7, t: null, toughnessAdded: 3, w: null, woundsAdded: 6, i: 4, a: 6, ld: null)
    {
        Weapons.Add(new WickedClawsTowWeapon());
        Weapons.Add(new SerratedMawTowWeapon());
        Weapons.Add(new NoxiousBreathTowWeapon());

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new Fly10());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new LargeTarget());
        SpecialRules.Add(new StompAttacksD6());
        SpecialRules.Add(new Swiftstride());
        SpecialRules.Add(new Terror());
    }

    protected BlackDragonTowMount(int? m, int ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int i, int a, int? ld) 
        : base(modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize, armourValue)
    {
    }
}
