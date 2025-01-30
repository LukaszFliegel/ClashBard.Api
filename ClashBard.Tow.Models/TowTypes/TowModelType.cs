using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.TowTypes;


public enum DarkElfTowModelType
{
    [Description("Dark Elf Dreadlord")]
    DarkElfDreadlord,
    [Description("Dark Elf Master")]
    DarkElfMaster,
    [Description("Supreme Sorceress")]
    SupremeSorceress,
    [Description("Sorceress")]
    Sorceress,
    [Description("High Beastmaster")]
    HighBeastmaster,
    [Description("Death Hag")]
    DeathHag,
    [Description("Khainite Assassin")]
    KhainiteAssassin,
    //[Description("Dark Steed")]
    //DarkSteed,
    //[Description("Cold One")]
    //ColdOne,
    [Description("Dark Pegasus")]
    DarkPegasus,
    [Description("Dark Elf Warriors")]
    DarkElfWarriors,
    [Description("Repeater Crossbowmen")]
    RepeaterCrossbowmen,
    [Description("Black Ark Corsairs")]
    BlackArkCorsairs,
    [Description("Black Guard Of Naggarond")]
    BlackGuardOfNaggarond,
    [Description("Har Ganeth Executioners")]
    HarGanethExecutioners,
    [Description("Dark Elf Shades")]
    DarkElfShades,
    [Description("Witch Elves")]
    WitchElves,
    [Description("Sisters Of Slaughter")]
    SistersOfSlaughter,
    [Description("Harpies")]
    Harpies,
    [Description("Cold One Knights")]
    ColdOneKnights,
    [Description("Dark Riders")]
    DarkRiders,
    [Description("Doomfire Warlocks")]
    DoomfireWarlocks,
    //[Description("Cauldron Of Blood")]
    //CauldronOfBlood,
    [Description("Scourgerunner Chariots")]
    ScourgerunnerChariots,
    [Description("Cold One Chariots")]
    ColdOneChariots,
    [Description("Bloodwrack Shrine")]
    BloodwrackShrine,
    //[Description("Black Dragon")]
    //BlackDragon,
    //[Description("Manticore")]
    //Manticore,
    [Description("War Hydra")]
    WarHydra,
    [Description("Bloodwrack Medusa")]
    BloodwrackMedusa,
    [Description("Kharibdyss")]
    Kharibdyss,
    [Description("Reaper Bolt Thrower")]
    ReaperBoltThrower,
}

/*
 * Lords of Bretonnia (Foot)
Lords of Bretonnia (Bretonnian Warhorse)
Lords of Bretonnia (Royal Pegasus)
Lords of Bretonnia (Hippogryph)
Handmaidens of the Lady (Foot)
Handmaidens of the Lady (Unicorn)
Sergeants-at-arms
Knights of the Realm (Foot)
Knights of the Realm (Bretonnian Warhorse)
Squires
Men-at-arms
Peasant Bowmen
Battle Pilgrims
Grail Reliquae
Knights Errant (Bretonnian Warhorse)
Questing Knights (Bretonnian Warhorse)
Grail Knights (Bretonnian Warhorse)
Pegasus Knights (Barded Pegasus)
Mounted Yeoman (Warhorse)
Hippogryph
Field Trebuchet
Field Trebuchet - Crewmen
Black Orc Bosses
Orc Bosses
Orc Shamans
Goblin Bosses
Goblin Shamans
Night Goblin Bosses
Night Goblin Shamans
Black Orc Mobs
Orc Mobs
Goblin Mobs
Nasty Skulkers
Night Goblin Mobs
Fanatics
Night Goblin Squig Herds
Troll Mobs
Orc Boar Boy Mobs
Goblin Spider Rider Mobs
Goblin Wolf Rider Mobs
Night Goblin Squig Hopper Mobs
Orc Boar Chariots
Goblin Wolf Chariots (2 wolves)
Goblin Wolf Chariots (3 wolves)
Snotling Pump Wagons
Wyverns
Arachnarok Spider
Mangler Squigs
Giants
Goblin Bolt Throwas
Goblin Bolt Throwas - Crew -
Doom Diver Catapults
Doom Diver Catapults - Crew -
Goblin Rock Lobbers
Goblin Rock Lobbers - Crew -
Orc Bullies
Monarchs Of Nehekhara
Royal Heralds
Liche Priests
Necrotect
Tomb Guard
Skeleton Warriors
Skeleton Archers
Skeleton Skirmishers
Ushabti
Tomb Swarms
Carrion
Skeleton Horsemen
Skeleton Horse Archers
Necropolis Knights
Sepulchral Stalkers
Skeleton Chariots
Necrolith Bone Dragon
Khemrian Warsphinx
Tomb Scorpion
Necrolith Colossus
Necrosphinx
Screaming Skull Catapult
Casket of Souls
Tomb Kings Mounts
Skeletal Steed
Skeleton Chariot
Standard ogres
Gnoblars
Ogre Lords
Butchers
Butchers with cauldron
Hunters
Maneaters
Yheties
Gorgers
Gors
Bestigors
Beastman Lords
Beastman Shaman
Minotaurs
Ghorgon/Cygor
Dragon Ogre Shaggoth
Jabberslythe
Cockatrice
All beastman chariots
Chaos warhounds
Razorgor herd
Centigor
Dragon Ogres
Dwarf Lords
Shield Bearers
Anvil o
Dwarf Runesmiths
Slayers of Legend
Dwarf Engineers
Dwarf Warriors
Longbeards
Quarrellers and Thunderers
Rangers
Hammerers
Ironbreakers
Irondrakes
Miners
Slayers
Gyrocopters
Gyrobombers
Bolt Throwers
Grudge Throwers
Cannon
Organ Guns
Flame Cannon
Vampire
Necromancers
Strigoi Ghoul Kings
Cairn Wraiths
Wights
Tomb Banshees
Grave Guard
Skeleton Warriors
Zombies
Crypt Ghouls
Crypt Horrors
Bat Swarms
Vargheists
Fell Bats
Spirit Hosts
Blood Knights
Black Knights
Dire Wolves
Hexwraiths
Coven Throne
Mortis Engine
Corpse Cart
Black Coach
Zombie Dragon
Terrorgheist
Abyssal Terror
Varghulf
Skeletal Steed
Nightmare
Commanders Of The Warlord Clans
Grey Seers
Clan Skryre Warlock Engineers
Clan Eshin Master Assassins
Clan Pestilens Plague Priests
Stormvermin
Clanrats
Weapon Teams
Warplock Jezzails
Poisoned Wind Globadiers
Rat Swarms
Packmasters & Master Moulders
Rat Ogres
Giant Rats
Night Runners
Gutter Runners
Plague Monks
Plague Censer Bearers
Screaming Bell
Plague Furnace
Doomwheel
Hell Pit Abomination
Warp Lightning Cannon
Plagueclaw Catapult
Wood Elf Nobles
Wood Elf Mages
Shadowdancers
Waystalkers
Treemen Ancients
Branchwraiths
Wood Elf Archers
Eternal Guard
Wildwood Rangers
Wardancers
Waywatchers
Dryads
Tree Kin
Glade Riders
Sisters of the Thorn
Wild Riders
Warhawk Riders
Forest Dragons
Great Eagles
Treemen
Elven Steed
Great Stag
Unicorn
Warhawk
Commanders of the Empire
Empire Wizards
Witch hunters
Warrior Priests Of Sigmar
Priests Of Ulric
Engineers
Empire State Troops
Crossbowmen
Handgunners
Free Company Militia
Empire Greatswords
Flagellants
Pistoliers
Outriders
Empire Knights
Inner Circle Knights
Demigryph Knights
War Altar of Sigmar
Empire Steam Tank
Griffons
Great Cannon
Mortars
Helblaster Volley Guns
Helstorm Rocket Batteries
Barded Warhorse
Empire Warhorse
Pegasus
Demigryph
Champions of Chaos
Daemon Princes
Sorcerers of Chaos
Chaos Warriors
Chosen Chaos Warriors
Chaos Marauders
Forsaken
Chaos Ogres
Chaos Trolls
Chaos Spawn
Chaos Knights
Chosen Chaos Knights
Marauder Horsemen
Chaos Warhounds
Chaos Warhound Handler
Chaos Chariots
Gorebeast Chariots
Manticore
Chaos Dragon
Chimera
Hellcannon
Warriors of Chaos Mounts
Chaos Steed
Daemonic Mount
All Saurus
All skinks
Slann
Cold Ones
All aerial cav
Kroxigor
Jungle Swarm
Stegadon
Bastiladon
Salamander
Razordon
Carnosaur
Troglodon
High elf standard infantry
Dragons
All High Elf Cavalry
All High Elf ground Chariots
Skycutter Chariot
Griffon
Pheonixs
Great Eagle
Eagle-Claw Bolt Thrower
*/