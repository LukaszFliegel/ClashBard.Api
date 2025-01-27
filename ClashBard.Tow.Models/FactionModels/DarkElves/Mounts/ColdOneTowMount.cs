using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ColdOneTowMount : TowModelMount
{
    private static int pointsCost = 18;

    public ColdOneTowMount(TowObject owner) : this(owner, m: 7, ws: 3, bs: null, s: 4, t: null, toughnessAdded: 1, w: null, woundsAdded: null, i: 2, a: 2, ld: null)
    {
        // special rules
        AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new ArmouredHide1());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new Stupidity());
        AssignSpecialRule(new Swiftstride());
    }

    protected ColdOneTowMount(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int i, int a, int? ld) 
        : base(owner, TowModelMountType.ColdOne, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, TowModelTroopType.HeavyCavalry, new DarkElvesTowFaction(), 30, 60)
    {
    }
}
