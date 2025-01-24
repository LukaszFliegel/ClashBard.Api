using ClashBard.Tow.Models;
using ClashBard.Tow.Models.FactionModels.DarkElves;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.MagicItems.MagicBanners;
using ClashBard.Tow.Models.MagicItems.MagicWeapons;
using ClashBard.Tow.Models.MagicItems.Talismans;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.Weapons;

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

        TowArmy army = new();

        //var dreadlord = _darkElvesRepository.GetCharacterByName("Dark Elf Dreadlord");

        //dreadlord.Assign(_weaponsRepository.GetByName("Repeater Crossbow"));
        //dreadlord.Armors.Add(_armorsRepository.GetArmor(TowArmorType.FullPlateArmour));


        var dreadlord = new DarkElfDreadlordTowCharacter(army);

        dreadlord.Assign(new FullPlateArmourTowArmour(dreadlord));
        dreadlord.Assign(new ShieldTowArmour(dreadlord));
        dreadlord.Assign(new SeaDragonCloakTowArmour(dreadlord));

        dreadlord.Assign(new BlackDragonTowMount(dreadlord));

        //dreadlord.SetMagicItem(new OgreBladeTowMagicWeapon());
        dreadlord.SetMagicItem(new TalismanOfProtectionTowTalisman(dreadlord));
        //dreadlord.Assign(new FullPlateArmourTowArmour(dreadlord));

        //var deWarriors = new TowUnit(
        //            new DarkElfWarriorTowModel(), 37, faction, true, true, true
        //            );

        //deWarriors.SetMagicBanner(new WarBannerTowMagicBanner()); // for test
        //deWarriors.SetWeapon(new ThrustingSpearTowWeapon());

        //var deCrossbowmen = new TowUnit(
        //            new RepeaterCrossbowmanTowModel(), 12, faction, false, true, true
        //            );

        //deCrossbowmen.SetArmor(new ShieldTowArmour());

        //var blackGuards = new TowUnit(
        //    new BlackGuardOfNaggarondTowModel(), 20, faction, true, false, true
        //    );

        //blackGuards.SetSpecialRule(new Drilled());

        army.Faction = faction;
        army.Name = "Dark Elves default";
        army.Points = 2000;
        //army.General = dreadlord;
        army.Characters = new List<TowCharacter>
        {
            dreadlord,
        };

        army.Units = new List<TowUnit>
        {
            //deWarriors,
            //deCrossbowmen,
            //blackGuards,
        };

        return army;
    }
}
