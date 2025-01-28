using ClashBard.Tow.Models;
using ClashBard.Tow.Models.FactionModels.DarkElves;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.MagicItems.ArcaneItems;
using ClashBard.Tow.Models.MagicItems.EnchantedItems;
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

        TowArmy army = new()
        {
            Faction = faction,
            Name = "Dark Elves default",
            General = null,
            Points = 2000,
            Characters = new List<TowCharacter> {  },
            Units = new List<TowUnit>()
        };



        var dreadlord = new DarkElfDreadlordTowCharacter(army);

        dreadlord.Assign(new FullPlateArmourTowArmour(dreadlord));
        dreadlord.Assign(new ShieldTowArmour(dreadlord));
        //dreadlord.SpecialRules

        dreadlord.Assign(new LanceTowWeapon(dreadlord));

        dreadlord.Assign(new BlackDragonTowMount(dreadlord));

        dreadlord.SetMagicItem(new OgreBladeTowMagicWeapon(dreadlord));
        dreadlord.SetMagicItem(new TalismanOfProtectionTowTalisman(dreadlord));

        var deWarriors = new TowUnit(
                    new DarkElfWarriorTowModel(army), 37, faction, true, true, true
                    );

        deWarriors.SetMagicStandard(new WarBannerTowMagicBanner(deWarriors));
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
        coldOneKnights.SetMagicStandard(new WarBannerTowMagicBanner(coldOneKnights));

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


        var sorceress = new SorceressTowCharacter(army);
        sorceress.SetMagicLevel(Models.TowTypes.TowMagicLevelType.Level2);
        sorceress.SetArcaneItem(new PowerScrollTowArcaneItem(sorceress));

        var sorceress2 = new SorceressTowCharacter(army);
        sorceress2.SetMagicLevel(Models.TowTypes.TowMagicLevelType.Level2);
        sorceress2.SetArcaneItem(new DispelScrollTowArcaneItem(sorceress2));

        var sorceress3 = new SorceressTowCharacter(army);
        sorceress3.SetMagicLevel(Models.TowTypes.TowMagicLevelType.Level2);
        sorceress3.SetArcaneItem(new WandOfJetTowArcaneItem(sorceress3));
        sorceress3.SetEnchantedItem(new RubyRingOfRuinTowEnchantedItem(sorceress3));

        var supremeSorceress = new SupremeSorceressTowCharacter(army);
        supremeSorceress.SetMagicLevel(Models.TowTypes.TowMagicLevelType.Level4);
        supremeSorceress.SetArcaneItem(new DispelScrollTowArcaneItem(supremeSorceress));

        var beastmaster = new HighBeastmasterTowCharacter(army);
        beastmaster.SetWeapon(new CavalrySpearTowWeapon(beastmaster));

        army.Faction = faction;
        army.Name = "Dark Elves default";
        army.Points = 2000;
        //army.General = dreadlord;
        army.Characters.Add(dreadlord);
        army.Characters.Add(beastmaster);
        army.Characters.Add(sorceress);
        army.Characters.Add(sorceress2);
        army.Characters.Add(sorceress3);
        army.Characters.Add(supremeSorceress);        

        army.Units.Add(hydra);
        army.Units.Add(hydra2);
        army.Units.Add(hydra3);
        army.Units.Add(deWarriors);
        army.Units.Add(deCrossbowmen);
        army.Units.Add(blackGuards);
        army.Units.Add(scourgerunnerChariot);
        army.Units.Add(coldOneKnights);
        army.Units.Add(scourgerunnerChariot2);
        
        army.Units.Add(darkRiders);
        army.Units.Add(darkRiders2);

        return army;
    }
}
