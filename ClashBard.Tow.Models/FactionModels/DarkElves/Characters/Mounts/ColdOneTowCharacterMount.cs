using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;

public class ColdOneTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 18;
    private static DarkElfTowModelMountType modelType = DarkElfTowModelMountType.ColdOne;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.HeavyCavalry;
    private const int baseSizeWidth = 30;
    private const int baseSizeLength = 60;
    private static int? armourValue = null;

    public ColdOneTowCharacterMount(TowObject owner) : this(owner, m: 7, ws: 3, bs: null, s: 4, t: null, toughnessAdded: 1, w: null, woundsAdded: null, i: 2, a: 2, ld: null)
    {
        // special rules
        AssignSpecialRule(new ArmourBane1("(Cold One only)"));
        AssignSpecialRule(new ArmouredHide1());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new Stupidity());
        AssignSpecialRule(new Swiftstride());
    }

    protected ColdOneTowCharacterMount(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int i, int a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
    }
}
