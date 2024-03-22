using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models;
public static class TowGlobals
{
    //public static string EmpireOfManName = "Empire of Man";
    //public static string OrcAndGoblinTribesName = "Orc & Goblin Tribes";
    //public static string DwarfenMountainHoldsName = "Dwarfen Mountain Holds";
    //public static string WarriorsOfChaosName = "Warriors of Chaos";
    //public static string KingdomOfBretonniaName = "Kingdom of Bretonnia";
    //public static string BeastmenBrayherdsName = "Beastmen Brayherds";
    //public static string WoodElvesName = "Wood Elves";
    //public static string TombKingsOfKhemriName = "Tomb Kings of Khemri";
    //public static string HighElvesName = "High Elves";
    //public static string DarkElvesName = "Dark Elves";
    //public static string SkavenName = "Skaven";
    //public static string VampireCountsName = "Vampire Counts";
    //public static string DaemonsOfChaosName = "Daemons of Chaos";
    //public static string OgreKingdomsName = "Ogre Kingdoms";
    //public static string LizardmenName = "Lizardmen";
    //public static string ChaosDwarfsName = "Chaos Dwarfs";

    public static TowWeapon HandWeapon = new TowWeapon { WeaponType = TowWeaponType.AdditionalHandWeapon, Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = null };
    //new TowWeapon { Id = 1, Name = "Hand Weapon", Range = 0, Strength = TowWeaponStrength.S, ArmorPiercing = 0, SpecialRules = null };
}
