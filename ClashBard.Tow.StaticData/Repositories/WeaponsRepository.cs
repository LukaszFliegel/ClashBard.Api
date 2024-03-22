using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClashBard.Tow.StaticData.Repositories;

public class WeaponsRepository : IWeaponsRepository
{
    private readonly ISpecialRulesRepository _specialRulesRepository;
    private List<TowWeapon> Weapons = new List<TowWeapon>();

    public WeaponsRepository(ISpecialRulesRepository specialRulesRepository)
    {
        _specialRulesRepository = specialRulesRepository;

        SeedData();
    }

    public TowWeapon GetByType(TowWeaponType type)
    {
        var weapon = Weapons.Single(p => p.WeaponType == type);
        return weapon;
    }

    //public TowWeapon GetByName(string name)
    //{
    //    var weapon = Weapons.Where(p => p.Name.ToLower().Equals(name.ToLower())).Single();
    //    return weapon;
    //}

    private void SeedData()
    {
        var requiresTwoHands = _specialRulesRepository.GetByType(TowSpecialRuleType.RequiresTwoHands);
        var extraAttacksPlusOne = _specialRulesRepository.GetByType(TowSpecialRuleType.ExtraAttacksPlus1);
        var strikeLast = _specialRulesRepository.GetByType(TowSpecialRuleType.StrikeLast);
        var armourBane1 = _specialRulesRepository.GetByType(TowSpecialRuleType.ArmourBane1);
        var armourBane2 = _specialRulesRepository.GetByType(TowSpecialRuleType.ArmourBane2);
        var fightInExtraRank = _specialRulesRepository.GetByType(TowSpecialRuleType.FightInExtraRank);
        var strikeFirst = _specialRulesRepository.GetByType(TowSpecialRuleType.StrikeFirst);
        var S2FirstRoundOfCombat = _specialRulesRepository.GetByType(TowSpecialRuleType.SPlus2FirstRoundOfCombat);
        var S1FirstRoundOfCombat = _specialRulesRepository.GetByType(TowSpecialRuleType.SPlus1FirstRoundOfCombat);
        var turnUserChargedOnly = _specialRulesRepository.GetByType(TowSpecialRuleType.TurnUserCharged);
        var sAndApOnlyOnChargeTurn = _specialRulesRepository.GetByType(TowSpecialRuleType.SandAPTurnUserCharged);
        var fightInExtraRankOnNoChargeTurn = _specialRulesRepository.GetByType(TowSpecialRuleType.FightinExtraRankanyturntheydidnotcharge);
        var fightInExtraRankOnChargeTurn = _specialRulesRepository.GetByType(TowSpecialRuleType.FightinExtraRankonturnusercharged);

        var quickShot = _specialRulesRepository.GetByType(TowSpecialRuleType.QuickShot);
        var volleyFire = _specialRulesRepository.GetByType(TowSpecialRuleType.VolleyFire);
        var multipleShots2 = _specialRulesRepository.GetByType(TowSpecialRuleType.MultipleShots2);
        var multipleShots3 = _specialRulesRepository.GetByType(TowSpecialRuleType.MultipleShots3);
        var multipleShots4 = _specialRulesRepository.GetByType(TowSpecialRuleType.MultipleShots4);
        var ponderous = _specialRulesRepository.GetByType(TowSpecialRuleType.Ponderous);
        var moveAndShoot = _specialRulesRepository.GetByType(TowSpecialRuleType.MoveAndShoot);

        var weaponsTemp = new List<TowWeapon> {
            TowGlobals.HandWeapon,
            //new TowWeapon { Id = 2, Name = "Additional hand weapon", Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, extraAttacksPlusOne } },
            //new TowWeapon { Id = 3, Name = "Great Weapon", Range = 0, Strength = TowWeaponStrength.Splus2, ArmorPiercing = -2, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, strikeLast, armourBane1 } },
            //new TowWeapon { Id = 4, Name = "Flail", Range = 0, Strength = TowWeaponStrength.Splus2, ArmorPiercing = -2, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, S2FirstRoundOfCombat } },
            //new TowWeapon { Id = 5, Name = "Morningstar", Range = 0, Strength = TowWeaponStrength.Splus1, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { S1FirstRoundOfCombat } },
            //new TowWeapon { Id = 6, Name = "Halberd", Range = 0, Strength = TowWeaponStrength.Splus1, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, armourBane1 } },
            //new TowWeapon { Id = 7, Name = "Whip", Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { fightInExtraRank, strikeFirst } },
            //new TowWeapon { Id = 8, Name = "Lance", Range = 0, Strength = TowWeaponStrength.Splus2, ArmorPiercing = -2, SpecialRules = new List<TowSpecialRule> { armourBane1, turnUserChargedOnly } },
            //new TowWeapon { Id = 9, Name = "Cavalry Spear", Range = 0, Strength = TowWeaponStrength.Splus1, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { fightInExtraRankOnNoChargeTurn, sAndApOnlyOnChargeTurn } },
            //new TowWeapon { Id = 10, Name = "Throwing Spear", Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { fightInExtraRankOnChargeTurn } },
            //new TowWeapon { Id = 11, Name = "Thrusting Spear", Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { fightInExtraRankOnNoChargeTurn } },

            //new TowWeapon { Id = 12, Name = "Shortbow", Range = 18, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { quickShot, volleyFire } },
            //new TowWeapon { Id = 13, Name = "Warbow", Range = 24, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { volleyFire } },
            //new TowWeapon { Id = 14, Name = "Longbow", Range = 30, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { armourBane1, volleyFire } },
            //new TowWeapon { Id = 15, Name = "Repeater Handbow", Range = 12, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { multipleShots2, quickShot } },
            //new TowWeapon { Id = 16, Name = "Brace of Repeater Handbows", Range = 12, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { multipleShots4, quickShot } },
            //new TowWeapon { Id = 17, Name = "Crossbow", Range = 30, Strength = TowWeaponStrength.Four, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { armourBane2, ponderous } },
            //new TowWeapon { Id = 18, Name = "Repeater Crossbow", Range = 24, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots2 } },
            //new TowWeapon { Id = 19, Name = "Pistol", Range = 12, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1 } },
            //new TowWeapon { Id = 20, Name = "Brace of Pistols", Range = 12, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots2, quickShot } },
            //new TowWeapon { Id = 21, Name = "Repeater Pistol", Range = 12, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots3, quickShot } },
            //new TowWeapon { Id = 22, Name = "Handgun", Range = 24, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, ponderous } },
            //new TowWeapon { Id = 23, Name = "Repeater Handgun", Range = 24, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots3, ponderous } },
            //new TowWeapon { Id = 24, Name = "Throwing Weapon", Range = 9, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { multipleShots2, moveAndShoot, quickShot } },
            //new TowWeapon { Id = 25, Name = "Throwing Axe", Range = 9, Strength = TowWeaponStrength.Splus1, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { quickShot } },
            //new TowWeapon { Id = 26, Name = "Javelin", Range = 12, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { moveAndShoot, quickShot } },
            //new TowWeapon { Id = 27, Name = "Sling", Range = 18, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { multipleShots2 } }


            new TowWeapon { WeaponType = TowWeaponType.AdditionalHandWeapon, Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, extraAttacksPlusOne } },
            new TowWeapon { WeaponType = TowWeaponType.GreatWeapon, Range = 0, Strength = TowWeaponStrength.Splus2, ArmorPiercing = -2, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, strikeLast, armourBane1 } },
            new TowWeapon { WeaponType = TowWeaponType.Flail, Range = 0, Strength = TowWeaponStrength.Splus2, ArmorPiercing = -2, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, S2FirstRoundOfCombat } },
            new TowWeapon { WeaponType = TowWeaponType.Morningstar, Range = 0, Strength = TowWeaponStrength.Splus1, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { S1FirstRoundOfCombat } },
            new TowWeapon { WeaponType = TowWeaponType.Halberd, Range = 0, Strength = TowWeaponStrength.Splus1, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, armourBane1 } },
            new TowWeapon { WeaponType = TowWeaponType.Whip, Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { fightInExtraRank, strikeFirst } },
            new TowWeapon { WeaponType = TowWeaponType.Lance, Range = 0, Strength = TowWeaponStrength.Splus2, ArmorPiercing = -2, SpecialRules = new List<TowSpecialRule> { armourBane1, turnUserChargedOnly } },
            new TowWeapon { WeaponType = TowWeaponType.CavalrySpear, Range = 0, Strength = TowWeaponStrength.Splus1, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { fightInExtraRankOnNoChargeTurn, sAndApOnlyOnChargeTurn } },
            new TowWeapon { WeaponType = TowWeaponType.ThrowingSpear, Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { fightInExtraRankOnChargeTurn } },
            new TowWeapon { WeaponType = TowWeaponType.ThrustingSpear, Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { fightInExtraRankOnNoChargeTurn } },

            new TowWeapon { WeaponType = TowWeaponType.Shortbow, Range = 18, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { quickShot, volleyFire } },
            new TowWeapon { WeaponType = TowWeaponType.Warbow, Range = 24, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { volleyFire } },
            new TowWeapon { WeaponType = TowWeaponType.Longbow, Range = 30, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { armourBane1, volleyFire } },
            new TowWeapon { WeaponType = TowWeaponType.RepeaterHandbow, Range = 12, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { multipleShots2, quickShot } },
            new TowWeapon { WeaponType = TowWeaponType.BraceOfRepeaterHandbows, Range = 12, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { multipleShots4, quickShot } },
            new TowWeapon { WeaponType = TowWeaponType.Crossbow, Range = 30, Strength = TowWeaponStrength.Four, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { armourBane2, ponderous } },
            new TowWeapon { WeaponType = TowWeaponType.RepeaterCrossbow, Range = 24, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots2 } },
            new TowWeapon { WeaponType = TowWeaponType.Pistol, Range = 12, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1 } },
            new TowWeapon { WeaponType = TowWeaponType.BraceOfPistols, Range = 12, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots2, quickShot } },
            new TowWeapon { WeaponType = TowWeaponType.RepeaterPistol, Range = 12, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots3, quickShot } },
            new TowWeapon { WeaponType = TowWeaponType.Handgun, Range = 24, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, ponderous } },
            new TowWeapon { WeaponType = TowWeaponType.RepeaterHandgun, Range = 24, Strength = TowWeaponStrength.Four, ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots3, ponderous } },
            new TowWeapon { WeaponType = TowWeaponType.ThrowingWeapon, Range = 9, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { multipleShots2, moveAndShoot, quickShot } },
            new TowWeapon { WeaponType = TowWeaponType.ThrowingAxe, Range = 9, Strength = TowWeaponStrength.Splus1, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { quickShot } },
            new TowWeapon { WeaponType = TowWeaponType.Javelin, Range = 12, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { moveAndShoot, quickShot } },
            new TowWeapon { WeaponType = TowWeaponType.Sling, Range = 18, Strength = TowWeaponStrength.Three, ArmorPiercing = 0, SpecialRules = new List<TowSpecialRule> { multipleShots2 } }

        };

        Weapons.AddRange(weaponsTemp);
    }
}
