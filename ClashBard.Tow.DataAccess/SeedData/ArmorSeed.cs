//using ClashBard.Tow.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClashBard.Tow.DataAccess.SeedData;
//internal class ArmorSeed
//{
//    public static void SeedArmors(ModelBuilder modelBuilder, List<TowSpecialRule> specialRules, List<TowFaction> factions)
//    {
//        var darkElves = factions.Where(f => f.Name == "Dark Elves").Single();

//        modelBuilder.Entity<TowArmor>().HasData(
//            new TowArmor { Id = 1,  Name = "Light Armor",           MeleeSaveBaseline = 6, RangedSaveBaseline = 6, MagicMeleeSaveBaseline = 6, MagicRangedSaveBaseline = 6 },
//            new TowArmor { Id = 2,  Name = "Heavy Armor",           MeleeSaveBaseline = 5, RangedSaveBaseline = 5, MagicMeleeSaveBaseline = 5, MagicRangedSaveBaseline = 5 },
//            new TowArmor { Id = 3,  Name = "Full plate armour",     MeleeSaveBaseline = 4, RangedSaveBaseline = 4, MagicMeleeSaveBaseline = 4, MagicRangedSaveBaseline = 4 },
//            new TowArmor { Id = 4,  Name = "Shield",                MeleeSaveImprovement = 1, RangedSaveImprovement = 1, MagicMeleeSaveImprovement = 1, MagicRangedSaveImprovement = 1 },
//            new TowArmor { Id = 5,  Name = "Sea Dragon Cloak",      MeleeSaveImprovement = 0, RangedSaveImprovement = 1, MagicMeleeSaveImprovement = 0, MagicRangedSaveImprovement = 0, Faction = darkElves }
//        );
//    }
//}
