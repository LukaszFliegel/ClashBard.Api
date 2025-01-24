using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.Xml;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class BeastmasterHandlersTowModelAdditional : TowModelAdditional
{
    public BeastmasterHandlersTowModelAdditional(TowObject owner) : this(owner, m: 6, ws: 4, bs: null, s: 3, t: null, w: null, i: 4, a: 1, ld: 8)
    {
        Assign(new WhipTowWeapon(this));
        
        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ImmuneToPsychology());
        SpecialRules.Add(new MonsterHandlers());
    }

    protected BeastmasterHandlersTowModelAdditional(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int ld)
        : base(owner, DarkElfTowModelAdditionalType.BeastmasterCrew, m, ws, bs, s, t, w, i, a, ld, new DarkElvesTowFaction())
    {
    }
}

