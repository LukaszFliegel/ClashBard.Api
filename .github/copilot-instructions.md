You are working on Windows machine.
Use context7 for coding practices whenever creating new code.

Goal of this project is to be able to build an army list for game Warhammer The Old World.
List of all rules is available at https://tow.whfb.app/

Army supported by producer right now are:
Beastmen Brayherds
Chaos Dwarfs
Daemons of Chaos
Dark Elves
Dwarfen Mountain Holds
Empire of Man
Grand Cathay
High Elf Realms
Kingdom of Bretonnia
Lizardmen
Ogre Kingdoms
Orc & Goblin Tribes
Skaven
Tomb Kings of Khemri
Vampire Counts
Warriors of Chaos
Wood Elf Realms

Index of rules for each army is available at https://tow.whfb.app/army/{army} (ex: https://tow.whfb.app/army/orc-and-goblin-tribes, https://tow.whfb.app/army/beastmen-brayherds)

Projects and their goals (with some structure explanation):
ClashBard.Api - ignore this project
ClashBard.Tow.ClassProducer.Console - ignore this project
ClashBard.Tow.DataAccess - ignore this project
ClashBard.Tow.Domain - ignore this project
ClashBard.Tow.Models - main project, contains all models for units and rules
    ClashBard.Tow.Models\SpecialRules - contains all special rules that can be applied to models and units
    ClashBard.Tow.Models\SpecialRules\DarkElvesSpecialRules - contains all special rules that are specific to Dark Elves faction
    ClashBard.Tow.Models\MagicItems - contains all magic items that can be used by models and units
    ClashBard.Tow.Models\MagicItems\DarkElves - contains all magic items that are specific to Dark Elves faction
    etc. - each faction has its own folder with specific rules and magic items
ClashBard.Tow.Pdf - ignore this project
ClashBard.Tow.Pdf.Console - ignore this project
ClashBard.Tow.StaticData - use if some static data needed across all projects, also contains json data with all faction units (huge files)

If you create .md file with applied changes, place it into {project}/Documentation folder.
Do not create .md files in other projects.

Whenever you implement a new model, use:
https://tow.whfb.app/unit/{unit}
/ClashBard.Tow.StaticData/{faction}.json
Not all information is listed in 1st link (like points), so wheneve implementin model search also in faction json for that unit.

So if you implementing/validating model "Eellyrian Reavers" from faction "High Elf Realms" use links:
https://tow.whfb.app/unit/ellyrian-reavers
/ClashBard.Tow.StaticData/high-elf-realms.json

Useful naming conventions:
- model - plastic model represnting an entity in the game
- unit - group of models that can be used in the game
- rule - rule that can be applied to a model or unit
- army - collection of units and models that can be used in the game
- army composition - the defined way of build an army (some factions have many, some have just one - Grand Army)
- magic item - item that can be used by a model or unit to enhance its abilities (like a weapon, armor, talisman, etc.)

Naming convention used in the project:
- additianal models - models that is part of another mdoel (like a chariot driver or monster handler)
- mount - model or an option to upgrade for a model to be mounted on a mount (like a horse, chariot, monster)
- if model has a weapon by itself, weapons shall be AssignDefault in constructor
- if model has an option to buy a weapon, it shall be added to AvailableWeapons list
- same for armors
- base class for models - TowModel in it's constructor assignes Hand Weapon (every model has hand weapon by default)