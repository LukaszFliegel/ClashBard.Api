﻿using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class BlackArkCorsairTowModel : TowModel
{
    private static int pointsCost = 11;

    public BlackArkCorsairTowModel() : this(m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        SetCommandGroup(new BlackArkCorsairChampionTowModel(), 6, 6, 6, 50, "Reaver");

        Armors.Add(new LightArmorTowArmor());

        OptionalWeapons.Add(new TowMandatoryOneOfTwoOption<TowWeaponType>(this, TowWeaponType.AdditionalHandWeapon, 0, TowWeaponType.RepeaterHandbow, 0));
        
        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ElvenReflexes());
        SpecialRules.Add(new HatredHighElves());
        SpecialRules.Add(new MartialProwess());

        AvailableSpecialRules.Add((TowSpecialRuleType.Veteran, 1));
    }

    protected BlackArkCorsairTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(DarkElfTowModelType.BlackArkCorsairs, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, TowModelTroopType.RegularInfantry, new DarkElvesTowFaction(), 25, 25, minUnitSize: 10)
    {
    }
}

public class BlackArkCorsairChampionTowModel : BlackArkCorsairTowModel
{
    public BlackArkCorsairChampionTowModel()
        : base(m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 2, ld: 8)
    {
        
    }
}
