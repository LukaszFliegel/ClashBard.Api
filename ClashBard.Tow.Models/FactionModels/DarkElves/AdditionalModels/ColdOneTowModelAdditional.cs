using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class ColdOneTowModelAdditional : TowModelAdditional
{
    public ColdOneTowModelAdditional(TowObject owner) : this(owner, m: 7, ws: 3, bs: null, s: 4, t: null, w: null, i: 2, a: 2, ld: null)
    {
        AssignSpecialRule(new ArmourBane1());
        //AssignSpecialRule(new ElvenReflexes()); // "A model with this special rule (but not its mount) ..."
        AssignSpecialRule(new Fear());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new Stupidity());
    }

    protected ColdOneTowModelAdditional(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int? ld)
        : base(owner, DarkElfTowModelAdditionalType.ColdOne, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

