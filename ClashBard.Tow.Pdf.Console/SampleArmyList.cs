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

        //var dreadlord = _darkElvesRepository.GetCharacterByName("Dark Elf Dreadlord");

        //dreadlord.Weapons.Add(_weaponsRepository.GetByName("Repeater Crossbow"));
        //dreadlord.Armors.Add(_armorsRepository.GetArmor(TowArmorType.FullPlateArmour));


        var dreadlord = new DarkElfDreadlordTowCharacter();

        dreadlord.SetArmor(new FullPlateArmourTowArmour());
        dreadlord.SetArmor(new ShieldTowArmour());
        dreadlord.SetArmor(new SeaDragonCloakTowArmour());

        dreadlord.SetMount(new BlackDragonTowMount());

        dreadlord.SetMagicItem(new OgreBladeTowMagicWeapon());
        dreadlord.SetMagicItem(new TalismanOfProtectionTowTalisman());

        var deWarriors = new TowUnit(
                    new DarkElfWarriorTowModel(), 37, faction, true, true, true
                    );
        
        deWarriors.SetMagicBanner(new WarBannerTowMagicBanner()); // for test
        deWarriors.SetWeapon(new ThrustingSpearTowWeapon());

        var deCrossbowmen = new TowUnit(
                    new RepeaterCrossbowmanTowModel(), 12, faction, false, true, true
                    );

        deCrossbowmen.SetArmor(new ShieldTowArmour());

        var blackGuards = new TowUnit(
            new BlackGuardOfNaggarondTowModel(), 20, faction, true, false, true
            );

        blackGuards.SetSpecialRule(new Drilled());

        return new TowArmy
        {
            Faction = faction,
            Name = "Dark Elves default ",
            Points = 2000,
            //General = dreadlord,
            Characters = new List<TowCharacter>
            {
                dreadlord,
            },
            Units = new List<TowUnit>
            {
                deWarriors,
                deCrossbowmen,
                blackGuards,
            }
        };
    }
}
