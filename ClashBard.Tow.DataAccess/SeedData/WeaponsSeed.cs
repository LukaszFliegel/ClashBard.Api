//using ClashBard.Tow.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClashBard.Tow.DataAccess.SeedData;
//internal class WeaponsSeed
//{
//    public static void SeedWeapons(ModelBuilder modelBuilder, List<TowSpecialRule> specialRules)
//    {
//        var requiresTwoHands = specialRules.Where(p => p.Name == "Requires Two Hands").Single();
//        var extraAttacksPlusOne = specialRules.Where(p => p.Name == "Extra Attacks (+1)").Single();
//        var strikeLast = specialRules.Where(p => p.Name == "Strike Last").Single();
//        var armourBane1 = specialRules.Where(p => p.Name == "Armour Bane (1)").Single();
//        var armourBane2 = specialRules.Where(p => p.Name == "Armour Bane (2)").Single();
//        var fightInExtraRank = specialRules.Where(p => p.Name == "Fight in Extra Rank").Single();
//        var strikeFirst = specialRules.Where(p => p.Name == "Strike First").Single();
//        var S2FirstRoundOfCombat = specialRules.Where(p => p.Name == "S+2 first round of combat only").Single();
//        var S1FirstRoundOfCombat = specialRules.Where(p => p.Name == "S+1 first round of combat only").Single();
//        var turnUserChargedOnly = specialRules.Where(p => p.Name == "Turn user charged only").Single();
//        var sAndApOnlyOnChargeTurn = specialRules.Where(p => p.Name == "S and AP only on turn user charged").Single();
//        var fightInExtraRankOnNoChargeTurn = specialRules.Where(p => p.Name == "Fight in Extra Rank any turn they did not charge").Single();
//        var fightInExtraRankOnChargeTurn = specialRules.Where(p => p.Name == "Fight in Extra Rank on turn user charged").Single();

//        var quickShot = specialRules.Where(p => p.Name == "Quick Shot").Single();
//        var volleyFire = specialRules.Where(p => p.Name == "Volley Fire").Single();
//        var multipleShots2 = specialRules.Where(p => p.Name == "Multiple Shots (2)").Single();
//        var multipleShots3 = specialRules.Where(p => p.Name == "Multiple Shots (3)").Single();
//        var multipleShots4 = specialRules.Where(p => p.Name == "Multiple Shots (4)").Single();
//        var ponderous = specialRules.Where(p => p.Name == "Ponderous").Single();
//        var moveAndShoot = specialRules.Where(p => p.Name == "Move & Shoot").Single();

//        modelBuilder.Entity<TowWeapon>().HasData(
//            TowGlobals.HandWeapon,
//            new TowWeapon { Id = 2,  Name = "Additional hand weapon",       Range = 0,  Strength = TowWeponsStrength.S,         ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { requiresTwoHands, extraAttacksPlusOne } },
//            new TowWeapon { Id = 3,  Name = "Great Weapon",                 Range = 0,  Strength = TowWeponsStrength.Splus2,    ArmorPiercing = -2, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, strikeLast, armourBane1 } },
//            new TowWeapon { Id = 4,  Name = "Flail",                        Range = 0,  Strength = TowWeponsStrength.Splus2,    ArmorPiercing = -2, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, S2FirstRoundOfCombat } },
//            new TowWeapon { Id = 5,  Name = "Morningstar",                  Range = 0,  Strength = TowWeponsStrength.Splus1,    ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { S1FirstRoundOfCombat } },
//            new TowWeapon { Id = 6,  Name = "Halberd",                      Range = 0,  Strength = TowWeponsStrength.Splus1,    ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { requiresTwoHands, armourBane1 } },
//            new TowWeapon { Id = 7,  Name = "Whip",                         Range = 0,  Strength = TowWeponsStrength.S,         ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { fightInExtraRank, strikeFirst } },
//            new TowWeapon { Id = 8,  Name = "Lance",                        Range = 0,  Strength = TowWeponsStrength.Splus2,    ArmorPiercing = -2, SpecialRules = new List<TowSpecialRule> { armourBane1, turnUserChargedOnly } },
//            new TowWeapon { Id = 9,  Name = "Cavalry Spear",                Range = 0,  Strength = TowWeponsStrength.Splus1,    ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { fightInExtraRankOnNoChargeTurn, sAndApOnlyOnChargeTurn } },
//            new TowWeapon { Id = 10, Name = "Throwing Spear",               Range = 0,  Strength = TowWeponsStrength.S,         ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { fightInExtraRankOnChargeTurn } },
//            new TowWeapon { Id = 11, Name = "Thrusting Spear",              Range = 0,  Strength = TowWeponsStrength.S,         ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { fightInExtraRankOnNoChargeTurn } },

//            new TowWeapon { Id = 12, Name = "Shortbow",                     Range = 18, Strength = TowWeponsStrength.Three,     ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { quickShot, volleyFire } },
//            new TowWeapon { Id = 13, Name = "Warbow",                       Range = 24, Strength = TowWeponsStrength.S,         ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { volleyFire } },
//            new TowWeapon { Id = 14, Name = "Longbow",                      Range = 30, Strength = TowWeponsStrength.Three,     ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { armourBane1, volleyFire } },
//            new TowWeapon { Id = 15, Name = "Repeater Handbow",             Range = 12, Strength = TowWeponsStrength.Three,     ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { multipleShots2, quickShot } },
//            new TowWeapon { Id = 16, Name = "Brace of Repeater Handbows",   Range = 12, Strength = TowWeponsStrength.Three,     ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { multipleShots4, quickShot } },
//            new TowWeapon { Id = 17, Name = "Crossbow",                     Range = 30, Strength = TowWeponsStrength.Four,      ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { armourBane2, ponderous } },
//            new TowWeapon { Id = 18, Name = "Repeater Crossbow",            Range = 24, Strength = TowWeponsStrength.Three,     ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots2 } },
//            new TowWeapon { Id = 19, Name = "Pistol",                       Range = 12, Strength = TowWeponsStrength.Four,      ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1 } },
//            new TowWeapon { Id = 20, Name = "Brace of Pistols",             Range = 12, Strength = TowWeponsStrength.Four,      ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots2, quickShot } },
//            new TowWeapon { Id = 21, Name = "Repeater Pistol",              Range = 12, Strength = TowWeponsStrength.Four,      ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots3, quickShot } },
//            new TowWeapon { Id = 22, Name = "Handgun",                      Range = 24, Strength = TowWeponsStrength.Four,      ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, ponderous } },
//            new TowWeapon { Id = 23, Name = "Repeater Handgun",             Range = 24, Strength = TowWeponsStrength.Four,      ArmorPiercing = -1, SpecialRules = new List<TowSpecialRule> { armourBane1, multipleShots3, ponderous } },
//            new TowWeapon { Id = 24, Name = "Throwing Weapon",              Range = 9,  Strength = TowWeponsStrength.S,         ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { multipleShots2, moveAndShoot, quickShot } },
//            new TowWeapon { Id = 25, Name = "Throwing Axe",                 Range = 9,  Strength = TowWeponsStrength.Splus1,    ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { quickShot } },
//            new TowWeapon { Id = 26, Name = "Javelin",                      Range = 12, Strength = TowWeponsStrength.S,         ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { moveAndShoot, quickShot } },
//            new TowWeapon { Id = 27, Name = "Sling",                        Range = 18, Strength = TowWeponsStrength.Three,     ArmorPiercing = 0,  SpecialRules = new List<TowSpecialRule> { multipleShots2 } }
//        );
//    }
//}
