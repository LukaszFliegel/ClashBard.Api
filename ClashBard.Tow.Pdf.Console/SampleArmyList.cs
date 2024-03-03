using ClashBard.Tow.DataAccess;
using ClashBard.Tow.DataAccess.FactionRepositories;
using ClashBard.Tow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Pdf.Console;

public class SampleArmyList
{
    private readonly DarkElvesRepository _darkElvesRepository;

    public SampleArmyList(DarkElvesRepository darkElvesRepository)
    {
        _darkElvesRepository = darkElvesRepository;
    }

    public TowArmy GetSampleDarkElfArmy()
    {
        return new TowArmy
        {
            Faction = new TowFaction
            {
                Name = "Dark Elves",
            },
            Name = "Dark Elf Inny Wymiar vol 1",
            Points = 1400,
            Models = new List<TowModel>
            {
                //new TowModel
                //{
                //    Name = "Dreadlord",
                //    Movement = 5,
                //    WeaponSkill = 7,
                //    BallisticSkill = 5,
                //    Strength = 4,
                //    Toughness = 4,
                //    Wounds = 3,
                //    Initiative = 8,
                //    Attacks = 4,
                //    Leadership = 10,
                //    SpecialRules = new List<TowModelSpecialRule>
                //    {
                //        new TowModelSpecialRule
                //        {
                //            Name = "Cold One",
                //            ShortDescription = "Rides a Cold One",
                //            LongDescription = "Rides a Cold One"
                //        },
                //        new TowModelSpecialRule
                //        {
                //            Name = "Sea Dragon Cloak",
                //            ShortDescription = "Sea Dragon Cloak",
                //            LongDescription = "Sea Dragon Cloak"
                //        }
                //    }
                //},
            }
        };
    }
}
