using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ScourgerunnerChariotTowModel : TowModel//, ISaveImprover
{
    private static int pointsCost = 85;
    private static int armorValue = 5;

    public ScourgerunnerChariotTowModel(TowObject owner) : this(owner, m: null, ws: null, bs: null, s: 4, t: 4, w: 4, i: null, a: null, ld: null)
    {
        
    }

    protected ScourgerunnerChariotTowModel(TowObject owner, int? m, int? ws, int? bs, int s, int t, int w, int? i, int? a, int? ld) 
        : base(owner, DarkElfTowModelType.ScourgerunnerChariots, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightChariot, new DarkElvesTowFaction(), 50, 100, 1, 3, armorValue)
    {
        // special rules
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new ImpactHitsD6());
        AssignSpecialRule(new OpenOrder());
        AssignSpecialRule(new SeaDragonCloak());
        AssignSpecialRule(new Swiftstride());

        // weapons
        AssignDefault(new RavagerHarpoonTowWeapon(this));

        // crew
        Crew.Add(new DarkSteedTowModelAdditional(this));
        Crew.Add(new DarkSteedTowModelAdditional(this));

        Crew.Add(new BeastmasterCrewTowModelAdditional(this));
        Crew.Add(new BeastmasterCrewTowModelAdditional(this));
    }

    //public int? MeleeSaveBaseline => armorValue;

    //public int MeleeSaveImprovement => 0;

    //public int? RangedSaveBaseline => armorValue;

    //public int RangedSaveImprovement => 0;

    //public bool AsteriskOnSave => false;
}
