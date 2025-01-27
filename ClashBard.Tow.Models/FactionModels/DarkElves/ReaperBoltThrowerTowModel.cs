using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ReaperBoltThrowerTowModel : TowModel
{
    private static int pointsCost = 80;
    private static DarkElfTowModelType modelType = DarkElfTowModelType.ReaperBoltThrower;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.WarMachine;
    private const int baseSizeWidth = 50;
    private const int baseSizeLength = 50;
    private const int minUnitSize = 1;
    private const int maxUnitSize = 1;

    public ReaperBoltThrowerTowModel(TowObject owner) : this(owner, m: null, ws: null, bs: null, s: null, t: 6, w: 2, i: null, a: null, ld: null)
    {

    }

    protected ReaperBoltThrowerTowModel(TowObject owner, int? m, int? ws, int? bs, int? s, int t, int w, int? i, int? a, int? ld) 
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize)
    {
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new Skirmishers());

        // wepons
        AssignDefault(new RepeaterBoltThrowerTowWeapon(this));
        AssignDefault(new RepeaterBoltThrowerRapidFireTowWeapon(this));

        // armours
        AssignDefault(new LightArmourTowArmour(this));

        // crew
        Crew.Add(new DarkElfCrewTowModelAdditional(this)); // Crew represents 2 crew members (2 attacks and 2 wounds, this is how it's described in the army book)
    }
}
