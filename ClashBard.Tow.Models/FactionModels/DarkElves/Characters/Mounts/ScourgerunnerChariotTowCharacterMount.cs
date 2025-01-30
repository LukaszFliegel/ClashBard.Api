using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;

public class ScourgerunnerChariotTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 85;
    private static DarkElfTowModelMountType modelType = DarkElfTowModelMountType.ScourgerunnerChariot;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.LightChariot;
    private const int baseSizeWidth = 50;
    private const int baseSizeLength = 100;
    private const int armourValue = 5;

    public ScourgerunnerChariotTowCharacterMount(TowObject owner) : this(owner, m: null, ws: null, bs: 4, s: 4, t: 4, toughnessAdded: null, w: 4, woundsAdded: 4, i: null, a: null, ld: 4)
    {
        Crew.Add(new DarkSteedTowModelAdditional(this));
        Crew.Add(new DarkSteedTowModelAdditional(this));

        Crew.Add(new BeastmasterCrewTowModelAdditional(this));
        Crew.Add(new BeastmasterCrewTowModelAdditional(this));

        Assign(new RavagerHarpoonTowWeapon(this));

        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new ImpactHitsD6());
        AssignSpecialRule(new SeaDragonCloak());
        AssignSpecialRule(new Swiftstride());
    }

    protected ScourgerunnerChariotTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
    }
}
