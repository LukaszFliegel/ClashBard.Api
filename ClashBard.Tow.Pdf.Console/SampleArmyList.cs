using ClashBard.Tow.Models;
using ClashBard.Tow.Models.FactionModels.DarkElves;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.Interfaces;

namespace ClashBard.Tow.Pdf.Console;

public class SampleArmyList
{
    public SampleArmyList()
    {

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
            Units = new List<TowUnit>
            {
                new TowUnit(
                    new DarkElfWarriorTowModel(), 37, faction, true, true, true
                    )
            }
        };
    }
}
