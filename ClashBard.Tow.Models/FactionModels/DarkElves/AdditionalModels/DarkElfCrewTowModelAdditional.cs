using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DarkElfCrewTowModelAdditional : TowModelAdditional
{
    private static DarkElfTowModelAdditionalType modelType = DarkElfTowModelAdditionalType.DarkElfCrew;
    private static TowFaction faction = new DarkElvesTowFaction();

    public DarkElfCrewTowModelAdditional() : this(m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 2, i: 4, a: 2, ld: 8)
    {
        Armours.Add(new LightArmourTowArmour());

        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new Skirmishers());
    }

    protected DarkElfCrewTowModelAdditional(int? m, int ws, int bs, int s, int? t, int? w, int i, int a, int ld)
        : base(modelType, m, ws, bs, s, t, w, i, a, ld, faction)
    {
    }
}

