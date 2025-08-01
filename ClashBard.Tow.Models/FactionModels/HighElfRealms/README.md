# High Elf Realms Faction Implementation

This implementation adds full support for the High Elf Realms faction to the Warhammer The Old World project, following the same structure as the Dark Elves faction.

## Created Components

### 1. Core Structure
- **HighElvesTowModelType** - Enum defining all High Elf unit types
- **HighElvesTowModelMountType** - Enum defining High Elf mount types
- **TowHighElvesMagicItemType** - Enum defining High Elf magic items
- **HighElvesTowFaction** - Main faction class with army composition validation
- **HighElvesArmyComposition** - Army composition rules and restrictions

### 2. Special Rules (HighElvesSpecialRules namespace)
- **AlwaysStrikesFirst** - Always strikes first in combat
- **ValourOfAges** - Immunity to Fear and Terror
- **HatredDarkElves** - Hatred against Dark Elves
- **AttunedToMagic** - +1 to cast, dispel and channel
- **WardSave4Plus** - 4+ ward save

### 3. Core Units
- **LothernSeaGuardTowModel** - Core infantry with ranged capability
- **SpearmenTowModel** - Basic spear-armed infantry
- **ArchersTowModel** - Basic archer unit
- **SilverHelmsTowModel** - Heavy cavalry unit

### 4. Special Units
- **PhoenixGuardTowModel** - Elite halberd-armed infantry with 4+ ward save
- **WhiteLionsOfChraceTowModel** - Elite great weapon infantry, Stubborn
- **SwordMastersOfHoethTowModel** - Elite sword masters, Always Strikes First
- **ShadowWarriorsTowModel** - Skirmish archers with Scout and Forest Strider

### 5. Characters

#### Lords
- **PrinceTowCharacter** - Lord-level combat character with martial prowess
- **ArchmageTowCharacter** - Lord-level wizard character (Level 4)
- **EltharionTheGrimTowCharacter** - Named character, Lord of Yvresse

#### Heroes  
- **NobleTowCharacter** - Hero-level combat character
- **MageTowCharacter** - Hero-level wizard character (Level 1, can upgrade to Level 2)
- **LoremasterOfHoethTowCharacter** - Scholar-warrior with magical abilities and Magic Resistance

### 6. Character Mounts
- **ElvenSteedTowMount** - Fast cavalry mount
- **BardedElvenSteedTowMount** - Heavy cavalry mount
- **GreatEagleTowCharacterMount** - Flying mount with Terror
- **GriffonTowCharacterMount** - Large flying mount 
- **StarDragonTowCharacterMount** - Most powerful dragon mount
- **SunDragonTowCharacterMount** - Powerful dragon mount
- **MoonDragonTowCharacterMount** - Dragon mount
- **FlamesphyrePhoenixTowCharacterMount** - Phoenix mount with fire abilities
- **FrostheartPhoenixTowCharacterMount** - Phoenix mount with ice abilities

### 7. Rare Units
- **GreatEagleTowModel** - Flying monster with Terror
- **EagleClawBoltThrowerTowModel** - War machine with crew

### 8. Mounts (for regular units)
- **ElvenSteedTowMount** - Fast cavalry mount
- **BardedElvenSteedTowMount** - Heavy cavalry mount

### 9. Magic Items Structure
- Created directory structure for all magic item categories
- Defined magic item types for weapons, armor, talismans, arcane items, enchanted items, and standards

## Features Implemented

### Faction Characteristics
- **Elven Reflexes** - +1 Initiative in first round of combat
- **Valour of Ages** - Immunity to Fear and Terror
- **Martial Prowess** - Supporting attacks to flank/rear
- **Always Strikes First** - Elite units strike first regardless of Initiative
- **Attuned to Magic** - Magical affinity bonuses

### Army Composition Rules
- 0-1 Prince or Archmage per 1,000 points
- 0-1 Great Eagle per 1,000 points  
- 0-1 Dragon mount per 1,000 points
- Additional special rules for veteran units and magic standards

### Equipment Options
- Full range of weapons: longbows, spears, halberds, great weapons
- Appropriate armor options for each unit type
- Mount options from basic steeds to mighty dragons
- Magic item support across all categories

## Usage

The High Elf Realms faction can now be used in army construction with:
- Proper unit restrictions and army composition validation
- Balanced point costs based on unit capabilities
- Faction-specific special rules and equipment
- Magic item support for character customization

All models follow the established patterns from the Dark Elves implementation and integrate seamlessly with the existing codebase.
