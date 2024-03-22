using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData.FactionRepositories;
using ClashBard.Tow.StaticData.Factions;
using ClashBard.Tow.StaticData.Repositories.Interfaces;

namespace ClashBard.Tow.Pdf.Console;

public class SampleArmyList
{
    private readonly DarkElvesRepository _darkElvesRepository;
    private readonly IWeaponsRepository _weaponsRepository;
    private readonly IArmorsRepository _armorsRepository;
    private readonly IFactionsListRepository _factionsListRepository;

    public SampleArmyList(DarkElvesRepository darkElvesRepository, IWeaponsRepository weaponsRepository, IArmorsRepository armorsRepository, IFactionsListRepository factionsListRepository)
    {
        _darkElvesRepository = darkElvesRepository;
        _weaponsRepository = weaponsRepository;
        _armorsRepository = armorsRepository;
        _factionsListRepository = factionsListRepository;
    }

    public TowArmy GetSampleDarkElfArmy()
    {
        //var dreadlord = _darkElvesRepository.GetModelByName("Dark Elf Dreadlord");

        TowFaction faction = new DarkElvesTowFaction();// _factionsListRepository.GetByName("Dark Elves");

        //var dreadlord = _darkElvesRepository.GetCharacterByName("Dark Elf Dreadlord");

        //dreadlord.Weapons.Add(_weaponsRepository.GetByName("Repeater Crossbow"));
        //dreadlord.Armors.Add(_armorsRepository.GetArmor(TowArmorType.FullPlateArmour));

        return new TowArmy
        {
            Faction = faction,
            Name = "Dark Elves default",
            Points = 2000,
            //General = dreadlord,
            Models = new List<TowModel>
            {
                
            }
        };
    }
}
