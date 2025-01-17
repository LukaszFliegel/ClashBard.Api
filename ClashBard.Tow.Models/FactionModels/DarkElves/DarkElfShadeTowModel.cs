﻿using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class DarkElfShadeTowModel : TowModel
{
    private static int pointsCost = 15;

    public DarkElfShadeTowModel() : this(m: 5, ws: 5, bs: 5, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
        SetCommandGroup(new DarkElfShadeChampionTowModel(), 6, null, null, null, "Bloodshade", 25);

        AvailableArmors.Add((TowArmorType.LightArmor, 1));

        Weapons.Add(new RepeaterCrossbowTowWeapon());
        OptionalWeapons.Add(new TowOptionalOneOfTwoOption<TowWeaponType>(this, TowWeaponType.AdditionalHandWeapon, 1, TowWeaponType.GreatWeapon, 2));

        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new Evasive());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new MoveThroughCover());
        SpecialRules.Add(new Scouts());
        SpecialRules.Add(new Skirmishers());

        AvailableSpecialRules.Add((TowSpecialRuleType.Ambushers, 1));
        AvailableSpecialRules.Add((TowSpecialRuleType.ChariotRunners, 1));
        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));
    }

    protected DarkElfShadeTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.DarkElfShades, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 5)
    {
    }
}

public class DarkElfShadeChampionTowModel : DarkElfShadeTowModel
{
    public DarkElfShadeChampionTowModel()
        : base(m: 5, ws: 5, bs: 6, s: 3, t: 3, w: 1, i: 5, a: 1, ld: 8)
    {
        
    }
}
