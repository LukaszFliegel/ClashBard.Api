# Elven Spearmen Validation Summary

## Unit Overview
**Name**: Elven Spearmen  
**Type**: Core Unit  
**Points**: 9 per model  
**Unit Size**: 5+ models  

## Validation Status
✅ **VALIDATED AND ENHANCED** - Implementation matches official rules and JSON data, with optional rules added

## Model Statistics
| Profile | M | WS | BS | S | T | W | I | A | Ld |
|---------|---|----|----|---|---|---|---|---|---- |
| Elven Spearman | 5 | 4 | 4 | 3 | 3 | 1 | 4 | 1 | 8 |
| Sentinel (Champion) | 5 | 4 | 4 | 3 | 3 | 1 | 4 | 2 | 8 |

## Equipment
- **Default**: Hand weapon (inherited from TowModel)
- **Default**: Thrusting spears
- **Default**: Light armour
- **Default**: Shields

## Special Rules (Default)
- **Close Order**
- **Elven Reflexes**
- **Martial Prowess**
- **Regimental Unit**
- **Valour of Ages**

## Unit Options (NEW - Added)
- **Champion**: May upgrade one model to Sentinel for +5 points
- **Standard Bearer**: +5 points (up to 50 points of magic banners)
- **Musician**: +5 points

### Optional Special Rules (NEW - Added)
- **Shieldwall**: +10 points for the unit
- **Veteran**: +1 point per model
- **Move Through Cover**: +1 point per model (Chracian Warhost composition only)
- **Lion Cloak**: +10 points (Chracian Warhost composition only)

## Implementation Details
- **Enum**: `HighElvesTowModelType.Spearmen` (existing, correct)
- **Model Class**: `ElvenSpearmenTowModel.cs` (validated and enhanced)
- **Champion Class**: `SpearmenChampionTowModel.cs` (correct - 2 attacks vs 1)
- **Constructor**: Properly assigns hand weapon, thrusting spear, light armour, shields
- **Unit Options**: Added command group setup and optional special rules

## Changes Made
1. ✅ **Added Optional Special Rules**: Implemented Shieldwall, Veteran, Move Through Cover, and Lion Cloak as available options
2. ✅ **Verified Champion Stats**: Confirmed champion correctly has 2 attacks (A:2 vs A:1)
3. ✅ **Verified Equipment**: All default equipment matches official rules
4. ✅ **Verified Special Rules**: All mandatory special rules properly assigned

## Validation Sources
- **Official Rules**: https://tow.whfb.app/unit/elven-spearmen
- **JSON Data**: ClashBard.Tow.StaticData/high-elf-realms.json
- **Build Status**: ✅ Successful compilation

## Notes
- All statistics match official sources exactly
- Optional special rules properly implemented with correct point costs
- Unit follows established High Elf Realms pattern
- Champion upgrade properly configured with +1 attack
- Base size and troop type correctly set (25x25mm, Regular Infantry)
- Minimum unit size of 5 correctly implemented
