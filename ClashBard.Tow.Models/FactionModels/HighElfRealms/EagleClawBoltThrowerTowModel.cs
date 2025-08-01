using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.HighElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.HighElfRealms;

public class EagleClawBoltThrowerTowModel : TowModel
{
    private static int pointsCost = 100;
    private static HighElvesTowModelType modelType = HighElvesTowModelType.EagleClawBoltThrower;
    private static TowFaction faction = new HighElvesTowFaction();
    private static TowModelTroopType troopType = TowModelTroopType.WarMachine;
    private const int baseSizeWidth = 50;
    private const int baseSizeLength = 50;
    private const int minUnitSize = 1;
    private const int maxUnitSize = 1;

    public EagleClawBoltThrowerTowModel(TowObject owner) : this(owner, m: null, ws: null, bs: null, s: null, t: 7, w: 3, i: null, a: null, ld: null)
    {

    }

    protected EagleClawBoltThrowerTowModel(TowObject owner, int? m, int? ws, int? bs, int? s, int t, int w, int? i, int? a, int? ld) 
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize)
    {
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new ValourOfAges());
        AssignSpecialRule(new Skirmishers());

        // Eagle Claw crew will be handled by the war machine mechanics
        // The weapon capabilities are handled via special rules/attacks
    }
}
