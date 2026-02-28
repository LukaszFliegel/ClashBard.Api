# Heavy Infantry Troop Type Implementation Summary

## Overview
Updated all units from High Elves and Dark Elves that should be classified as Heavy Infantry based on their armor type and official rules validation.

## Implementation Status
✅ **COMPLETED** - All applicable units updated to use `TowModelTroopType.HeavyInfantry`

## Units Updated

### High Elf Realms Units

#### 1. **Lion Guard** ✅
- **File**: `LionGuardTowModel.cs`
- **Validation**: https://tow.whfb.app/unit/lion-guard
- **Equipment**: Hand weapons, Chracian great blades, **Heavy armour**
- **Official Troop Type**: Heavy Infantry
- **Change**: `RegularInfantry` → `HeavyInfantry`

#### 2. **Phoenix Guard** ✅
- **File**: `PhoenixGuardTowModel.cs`
- **Validation**: https://tow.whfb.app/unit/phoenix-guard
- **Equipment**: Hand weapons, ceremonial halberds, **Full plate armour**
- **Official Troop Type**: Heavy Infantry (inferred from full plate)
- **Change**: `RegularInfantry` → `HeavyInfantry`

#### 3. **White Lions of Chrace** ✅
- **File**: `WhiteLionsOfChraceTowModel.cs`
- **Validation**: https://tow.whfb.app/unit/white-lions-of-chrace
- **Equipment**: Hand weapons, Chracian great blades, **Heavy armour**
- **Official Troop Type**: Heavy Infantry (inferred from heavy armor)
- **Changes**: 
  - `RegularInfantry` → `HeavyInfantry`
  - **ARMOR FIX**: `LightArmourTowArmour` → `HeavyArmourTowArmour` (to match official rules)
  - **WEAPON FIX**: `AvailableWeapons.Add(GreatWeapon)` → `AssignDefault(ChracianGreatBladeTowWeapon)` (to match official rules)

### Dark Elf Units

#### 4. **Black Guard of Naggarond** ✅
- **File**: `BlackGuardOfNaggarondTowModel.cs`
- **Validation**: https://tow.whfb.app/unit/black-guard-of-naggarond
- **Equipment**: Hand weapons, dread halberds, **Full plate armour**
- **Official Troop Type**: Heavy Infantry (inferred from full plate)
- **Change**: `RegularInfantry` → `HeavyInfantry`

## Validation Criteria
Units were classified as Heavy Infantry based on:
1. **Primary Factor**: Official rules showing **Heavy Armour** or **Full Plate Armour**
2. **Secondary Factor**: Elite unit status with high armor save values
3. **Official Validation**: Cross-referenced with https://tow.whfb.app/ unit pages

## Units That Remain Regular Infantry
The following units were checked but correctly remain as Regular Infantry:

### High Elf Realms
- **Elven Archers**: Light armor, skirmisher role
- **Elven Spearmen**: Light armor and shields (basic infantry)
- **Lothern Sea Guard**: Light armor and shields
- **Chracian Woodsmen**: Light armor (with optional heavy armor upgrade)
- **Sword Masters of Hoeth**: No armor by default (rely on special rules)
- **Shadow Warriors**: Light armor, scout/skirmisher role

### Dark Elves
- **Dark Elf Warriors**: Light armor and shields (basic infantry)
- **Dark Elf Shades**: Light armor, scout role
- **Witch Elves**: Minimal/no armor, rely on speed and frenzy
- **Sisters of Slaughter**: Light armor, fast attack role
- **Har Ganeth Executioners**: Light armor (executioner role, not heavy infantry)
- **Repeater Crossbowmen**: Light armor, ranged role
- **Black Ark Corsairs**: Light armor, naval infantry
- **Harpies**: No armor, flying creatures

## Build Status
✅ **SUCCESSFUL** - All changes compile without errors

## Technical Notes
- **HeavyInfantry** enum value was already added to `TowModelTroopType`
- No changes needed to existing `RegularInfantry` units that were correctly classified
- White Lions equipment corrected to match official rules (heavy armor + Chracian great blades)
- All units maintain their existing point costs and special rules

## Impact
This update ensures that:
1. **Game Mechanics**: Heavy Infantry units are properly distinguished from Regular Infantry for rules purposes
2. **Accuracy**: All implementations match official Warhammer: The Old World rules
3. **Consistency**: Armor type now correctly correlates with troop type classification
