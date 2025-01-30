using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;

public class ColdOneChariotsTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 125;
    private static DarkElfTowModelMountType modelType = DarkElfTowModelMountType.ColdOneChariot;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.HeavyChariot;
    private const int baseSizeWidth = 50;
    private const int baseSizeLength = 100;
    private static int? armourValue = 4;

    public ColdOneChariotsTowCharacterMount(TowObject owner) : this(owner, m: null, ws: null, bs: null, s: 5, t: 5, toughnessAdded: null, w: 4, woundsAdded: null, i: null, a: null, ld: null)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new FirstCharge());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new ImpactHitsD6Plus1());
        AssignSpecialRule(new Stupidity());

        // crew
        Crew.Add(new ColdOneTowModelAdditional(this));
        Crew.Add(new ColdOneTowModelAdditional(this));

        Crew.Add(new KnightCharioteerTowModelAdditional(this));
        Crew.Add(new KnightCharioteerTowModelAdditional(this));
    }

    protected ColdOneChariotsTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
    }
}
