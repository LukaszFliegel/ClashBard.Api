using ClashBard.Tow.Models;
using ClashBard.Tow.Models.Armors.DarkElvesArmors;
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
        TowFaction faction = new DarkElvesTowFaction();

        TowArmy army = new();



        var dreadlord = new DarkElfDreadlordTowCharacter(army);

        dreadlord.Assign(new FullPlateArmourTowArmour(dreadlord));
        dreadlord.Assign(new ShieldTowArmour(dreadlord));
        dreadlord.Assign(new SeaDragonCloakTowArmour(dreadlord));

        dreadlord.Assign(new LanceTowWeapon(dreadlord));

        dreadlord.Assign(new BlackDragonTowMount(dreadlord));

        dreadlord.SetMagicItem(new OgreBladeTowMagicWeapon(dreadlord));
        dreadlord.SetMagicItem(new TalismanOfProtectionTowTalisman(dreadlord));

        var deWarriors = new TowUnit(
                    new DarkElfWarriorTowModel(army), 37, faction, true, true, true
                    );

        deWarriors.SetMagicBanner(new WarBannerTowMagicBanner(deWarriors)); // for test
        deWarriors.SetWeapon(new ThrustingSpearTowWeapon(deWarriors));

        var deCrossbowmen = new TowUnit(
                    new RepeaterCrossbowmanTowModel(army), 12, faction, false, true, true
                    );

        deCrossbowmen.SetArmor(new ShieldTowArmour(deCrossbowmen));

        var blackGuards = new TowUnit(
            new BlackGuardOfNaggarondTowModel(army), 20, faction, true, false, true
            );

        blackGuards.SetSpecialRule(new Drilled());

        var scourgerunnerChariot = new TowUnit(
            new ScourgerunnerChariotTowModel(army), 1, faction, false, false, false
            );

        var scourgerunnerChariot2 = new TowUnit(
           new ScourgerunnerChariotTowModel(army), 1, faction, false, false, false
           );

        var coldOneKnights = new TowUnit(
            new ColdOneKnightTowModel(army), 6, faction, true, true, true
            );

        coldOneKnights.SetArmor(new FullPlateArmourTowArmour(coldOneKnights));
        coldOneKnights.SetMagicBanner(new WarBannerTowMagicBanner(coldOneKnights));

        var hydra = new TowUnit(
            new WarHydraTowModel(army), 1, faction
            );

        var hydra2 = new TowUnit(
            new WarHydraTowModel(army), 1, faction
            );

        var hydra3 = new TowUnit(
            new WarHydraTowModel(army), 1, faction
            );

        var darkRiders = new TowUnit(
            new DarkRiderTowModel(army), 6, faction, false, true, false
            );

        darkRiders.SetSpecialRule(new Scouts());

        var darkRiders2 = new TowUnit(
            new DarkRiderTowModel(army), 6, faction, false, true, false
            );

        darkRiders2.SetSpecialRule(new Scouts());

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
            deWarriors,
            deCrossbowmen,
            blackGuards,
            scourgerunnerChariot,
            coldOneKnights,
            scourgerunnerChariot2,
            hydra,
            hydra2,
            hydra3,
            darkRiders,
            darkRiders2,
        };

        return army;
    }
}
