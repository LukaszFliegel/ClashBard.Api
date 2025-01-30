using ClashBard.Tow.Models;
using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.FactionModels.DarkElves;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.Factions.ArmyCompositions;
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

        TowArmy army = new(faction, 1000, "Dark Elves default");

        army.SetArmyComposition(new DarkElvesArmyComposition(army));


        //var dreadlord = new DarkElfDreadlordTowCharacter(army);

        //dreadlord.Assign(new FullPlateArmourTowArmour(dreadlord));
        //dreadlord.Assign(new ShieldTowArmour(dreadlord));
        ////dreadlord.SpecialRules

        //dreadlord.Assign(new LanceTowWeapon(dreadlord));

        //dreadlord.Assign(new BlackDragonTowMount(dreadlord));

        //dreadlord.SetMagicItem(new OgreBladeTowMagicWeapon(dreadlord));
        //dreadlord.SetMagicItem(new TalismanOfProtectionTowTalisman(dreadlord));

        var deathHag = new DeathHagTowCharacter(army);
        deathHag.SetGiftOfKhaine(new RuneOfKhaineRuneOfKhaine(deathHag));
        deathHag.Assign(new CauldronOfBloodTowCharacterMount(deathHag));

        //var deathHag2 = new DeathHagTowCharacter(army);
        //deathHag2.SetGiftOfKhaine(new WitchbrewRuneOfKhaine(deathHag2));
        //deathHag2.Assign(new CauldronOfBloodTowCharacterMount(deathHag2));

        //var deWarriors = new TowUnit(
        //            new DarkElfWarriorTowModel(army), 37, faction, true, true, true
        //            );

        //deWarriors.SetMagicStandard(new WarBannerTowMagicBanner(deWarriors));
        //deWarriors.SetWeapon(new ThrustingSpearTowWeapon(deWarriors));

        //var deCrossbowmen = new TowUnit(
        //            new RepeaterCrossbowmanTowModel(army), 12, faction, false, true, true
        //            );

        //deCrossbowmen.SetArmor(new ShieldTowArmour(deCrossbowmen));

        //var blackGuards = new TowUnit(
        //    new BlackGuardOfNaggarondTowModel(army), 20, faction, true, false, true
        //    );

        //blackGuards.SetSpecialRule(new Drilled());

        //var blackGuards2 = new TowUnit(
        //    new BlackGuardOfNaggarondTowModel(army), 20, faction, true, false, true
        //    );

        //blackGuards2.SetSpecialRule(new Drilled());

        //var scourgerunnerChariot = new TowUnit(
        //    new ScourgerunnerChariotTowModel(army), 1, faction, false, false, false
        //    );

        //var scourgerunnerChariot2 = new TowUnit(
        //   new ScourgerunnerChariotTowModel(army), 1, faction, false, false, false
        //   );



        //var coldOneKnights2 = new TowUnit(
        //    new ColdOneKnightTowModel(army), 6, faction, true, true, true
        //    );

        //coldOneKnights2.SetArmor(new FullPlateArmourTowArmour(coldOneKnights));

        //var coldOneKnights3 = new TowUnit(
        //    new ColdOneKnightTowModel(army), 6, faction, true, true, true
        //    );

        //coldOneKnights3.SetArmor(new FullPlateArmourTowArmour(coldOneKnights));

        //var hydra = new TowUnit(
        //    new WarHydraTowModel(army), 1, faction
        //    );

        //var hydra2 = new TowUnit(
        //    new WarHydraTowModel(army), 1, faction
        //    );

        //var hydra3 = new TowUnit(
        //    new WarHydraTowModel(army), 1, faction
        //    );

        //var darkRiders = new TowUnit(
        //    new DarkRiderTowModel(army), 6, faction, false, true, false
        //    );

        //darkRiders.SetSpecialRule(new Scouts());

        //var darkRiders2 = new TowUnit(
        //    new DarkRiderTowModel(army), 6, faction, false, true, false
        //    );

        //darkRiders2.SetSpecialRule(new Scouts());


        //var sorceress = new SorceressTowCharacter(army);
        //sorceress.SetMagicLevel(Models.TowTypes.TowMagicLevelType.Level2);
        //sorceress.SetArcaneItem(new PowerScrollTowArcaneItem(sorceress));

        //var sorceress2 = new SorceressTowCharacter(army);
        //sorceress2.SetMagicLevel(Models.TowTypes.TowMagicLevelType.Level2);
        //sorceress2.SetArcaneItem(new DispelScrollTowArcaneItem(sorceress2));

        //var sorceress3 = new SorceressTowCharacter(army);
        //sorceress3.SetMagicLevel(Models.TowTypes.TowMagicLevelType.Level2);
        //sorceress3.SetArcaneItem(new WandOfJetTowArcaneItem(sorceress3));
        //sorceress3.SetEnchantedItem(new RubyRingOfRuinTowEnchantedItem(sorceress3));

        //var supremeSorceress = new SupremeSorceressTowCharacter(army);
        //supremeSorceress.SetMagicLevel(Models.TowTypes.TowMagicLevelType.Level4);
        //supremeSorceress.SetArcaneItem(new DispelScrollTowArcaneItem(supremeSorceress));

        //var beastmaster = new HighBeastmasterTowCharacter(army);
        //beastmaster.SetWeapon(new CavalrySpearTowWeapon(beastmaster));

        var master = new DarkElfMasterTowCharacter(army);
        master.Assign(new ColdOneTowCharacterMount(master));



        var coldOneKnights = new TowUnit(
            new ColdOneKnightTowModel(army), 6, faction, true, true, true
            );

        coldOneKnights.SetArmor(new FullPlateArmourTowArmour(coldOneKnights));
        coldOneKnights.SetMagicStandard(new WarBannerTowMagicBanner(coldOneKnights));


        var doomfireWarlocks = new TowUnit(
            new DoomfireWarlockTowModel(army), 5, faction, false, false, true
            );


        //army.Faction = faction;
        //army.Name = "Dark Elves default";
        //army.Points = 2000;
        //army.General = dreadlord;
        //army.AddCharacter(dreadlord);
        army.AddCharacter(deathHag);
        //army.AddCharacter(deathHag2);
        //army.AddCharacter(sorceress);
        //army.AddCharacter(sorceress2);
        //army.AddCharacter(sorceress3);
        //army.AddCharacter(supremeSorceress);
        army.AddCharacter(master);

        //army.AddUnit(hydra);
        //army.AddUnit(hydra2);
        //army.AddUnit(hydra3);
        //army.AddUnit(deWarriors);
        //army.AddUnit(deCrossbowmen);
        //army.AddUnit(blackGuards);
        //army.AddUnit(blackGuards2);
        //army.AddUnit(scourgerunnerChariot);
        army.AddUnit(coldOneKnights);
        army.AddUnit(doomfireWarlocks);
        //army.AddUnit(coldOneKnights2);
        //army.AddUnit(coldOneKnights3);
        //army.AddUnit(scourgerunnerChariot2);

        //army.AddUnit(darkRiders);
        //army.AddUnit(darkRiders2);

        return army;
    }
}
