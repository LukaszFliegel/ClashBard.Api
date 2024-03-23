using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClashBard.Tow.Models.Deprecated.Repositories;

public class ArmorsRepository : IArmorsRepository
{
    //private readonly IFactionsListRepository _factionsRepository;
    private List<TowArmor> Armors = new List<TowArmor>();

    //public ArmorsRepository(IFactionsListRepository factionsRepository)
    //{
    //    _factionsRepository = factionsRepository;

    //    SeedData();
    //}

    public TowArmor GetByType(TowArmorType type)
    {
        var armor = Armors.Single(a => a.ArmorType == type);
        return armor;
    }

    private void SeedData()
    {
        //var darkElves = _factionsRepository.GetByType(TowFactionType.DarkElves);

        //var armorsTemp = new List<TowArmor>
        //{
        //    new TowArmor { ArmorType = TowArmorType.LightArmor, MeleeSaveBaseline = 6, RangedSaveBaseline = 6, MagicMeleeSaveBaseline = 6, MagicRangedSaveBaseline = 6 },
        //    new TowArmor { ArmorType = TowArmorType.HeavyArmor, MeleeSaveBaseline = 5, RangedSaveBaseline = 5, MagicMeleeSaveBaseline = 5, MagicRangedSaveBaseline = 5 },
        //    new TowArmor { ArmorType = TowArmorType.FullPlateArmour, MeleeSaveBaseline = 4, RangedSaveBaseline = 4, MagicMeleeSaveBaseline = 4, MagicRangedSaveBaseline = 4 },
        //    new TowArmor { ArmorType = TowArmorType.Shield, MeleeSaveImprovement = 1, RangedSaveImprovement = 1, MagicMeleeSaveImprovement = 1, MagicRangedSaveImprovement = 1 },
        //    new TowArmor { ArmorType = TowArmorType.SeaDragonCloak, MeleeSaveImprovement = 0, RangedSaveImprovement = 1, MagicMeleeSaveImprovement = 0, MagicRangedSaveImprovement = 0, Faction = darkElves }
        //};

        //Armors.AddRange(armorsTemp);
    }
}

