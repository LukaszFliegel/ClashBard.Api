# Lion Guard Implementation Summary

## Unit Overview
**Name**: Lion Guard  
**Type**: Rare Unit (Chracian Warhost only)  
**Points**: 18 per model  
**Unit Size**: 5+ models  
**Unit Restriction**: 0-1 unit per army (Chracian Warhost composition)

## Implementation Status
✅ **IMPLEMENTED** - Newly created from scratch to match official rules and JSON data

## Model Statistics
| Profile | M | WS | BS | S | T | W | I | A | Ld |
|---------|---|----|----|---|---|---|---|---|---- |
| Lion Guard | 5 | 6 | 4 | 4 | 3 | 1 | 5 | 1 | 9 |
| Lion Guard Captain | 5 | 6 | 4 | 4 | 3 | 1 | 5 | 2 | 9 |

## Equipment
- **Default**: Hand weapon (inherited from TowModel)
- **Default**: Chracian great blades
- **Default**: Heavy armour

## Special Rules (All Default)
- **Champions of Chrace** (NEW - newly implemented special rule)
- **Close Order**
- **Elven Reflexes**
- **Furious Charge**
- **Lion Cloak**
- **Stubborn**
- **Veteran**

## Unit Options
- **Champion**: May upgrade one model to Lion Guard Captain for +7 points
  - Captain has up to 50 points of magic items (weapon, armor, talisman, enchanted item)
- **Standard Bearer**: +7 points (up to 50 points of magic banners)
- **Musician**: +7 points

## Implementation Details
- **Enum**: `HighElvesTowModelType.LionGuard` (NEW - added to enum)
- **Model Class**: `LionGuardTowModel.cs` (NEW - created from scratch)
- **Champion Class**: `LionGuardCaptainTowModel.cs` (NEW - correct 2 attacks vs 1)
- **Special Rule**: `ChampionsOfChrace.cs` (NEW - created special rule class)
- **Troop Type**: RegularInfantry (25x25mm bases)
- **Command Group**: Properly configured with magic item allowances

## New Components Created

### 1. Special Rule Enum Addition
- Added `ChampionsOfChrace` to `TowSpecialRuleType` enum

### 2. Special Rule Class
- Created `ChampionsOfChrace.cs` in HighElvesSpecialRules namespace
- Follows established pattern with proper constructor

### 3. Model Enum Addition
- Added `LionGuard` to `HighElvesTowModelType` enum in Rare Units section

### 4. Model Class
- Created `LionGuardTowModel.cs` with all required statistics, equipment, and special rules
- Created champion subclass with correct attack increase

## Validation Sources
- **Official Rules**: https://tow.whfb.app/unit/lion-guard
- **JSON Data**: ClashBard.Tow.StaticData/high-elf-realms.json
- **Build Status**: ✅ Successful compilation

## Technical Notes
- **Base Size**: 25x25mm (Infantry)
- **Troop Type**: RegularInfantry (no HeavyInfantry type exists in enum)
- **Army Category**: Rare (The Chracian Warhost composition only)
- **Unit Restriction**: 0-1 per army
- **Command Costs**: Champion, Standard, Musician all cost +7 points each
- **Magic Item Limits**: Champion 50 points, Standard Bearer 50 points (banners only)

## Dependencies Used
- All required weapons: ChracianGreatBladeTowWeapon (existing)
- All required armors: HeavyArmourTowArmour (existing)
- All special rules: Existing except ChampionsOfChrace (newly created)

The Lion Guard unit represents elite warriors of Chrace who serve as bodyguards to the Phoenix King, wielding their signature Chracian great blades and protected by heavy armor and lion cloaks.
