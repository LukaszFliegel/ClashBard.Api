using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Mounts;

public class ColdOneTowMount : TowModelMount
{
    private static DarkElvesTowModelMountType modelType = DarkElvesTowModelMountType.ColdOne;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.HeavyCavalry;
    private const int baseSizeWidth = 30;
    private const int baseSizeLength = 60;

    public ColdOneTowMount(TowObject owner) : this(owner, m: 7, ws: 3, bs: null, s: 4, t: null, w: null, i: 2, a: 2, ld: null)
    {
        // special rules
        AssignSpecialRule(new ArmourBane1("(Cold One only)"));
    }

    protected ColdOneTowMount(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, troopType, faction, baseSizeWidth, baseSizeLength)
    {
    }
}
