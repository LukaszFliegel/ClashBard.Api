﻿using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ScourgerunnerChariotTowModel : TowModel
{
    private static int pointsCost = 85;

    public ScourgerunnerChariotTowModel() : this(m: null, ws: null, bs: null, s: 4, t: 4, w: 4, i: null, a: null, ld: null)
    {
        Crew.Add(new DarkSteedTowModelAdditional());
        Crew.Add(new DarkSteedTowModelAdditional());

        Crew.Add(new BeastmasterCrewTowModelAdditional());
        Crew.Add(new BeastmasterCrewTowModelAdditional());

        Weapons.Add(new RavagerHarpoonTowWeapon());

        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new ImpactHitsD6());
        SpecialRules.Add(new OpenOrder());
        SpecialRules.Add(new SeaDragonCloak());
        SpecialRules.Add(new Swiftstride());
    }

    protected ScourgerunnerChariotTowModel(int? m, int? ws, int? bs, int s, int t, int w, int? i, int? a, int? ld) 
        : base(DarkElfTowModelType.ScourgerunnerChariots, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.LightChariot, new DarkElvesTowFaction(), 50, 100, 1, 3, 5)
    {
    }
}
