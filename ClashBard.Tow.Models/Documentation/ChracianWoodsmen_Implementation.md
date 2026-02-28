# Chracian Woodsmen Implementation

## Overview
The Chracian Woodsmen unit has been successfully implemented for High Elf Realms faction.

## Official Rules Reference
- **Source**: https://tow.whfb.app/unit/chracian-woodsmen
- **Points Cost**: 12 points per model
- **Unit Category**: Infantry (Special Units in Chracian Warhost army composition)
- **Troop Type**: Regular Infantry
- **Base Size**: 25x25mm
- **Unit Size**: 5+ models

## Statistics
| Model | M | WS | BS | S | T | W | I | A | Ld |
|-------|---|----|----|---|---|---|---|---|----| 
| Chracian Woodsman | 5 | 4 | 4 | 4 | 3 | 1 | 4 | 1 | 8 |
| Chracian Captain | 5 | 4 | 4 | 4 | 3 | 1 | 4 | 2 | 8 |

## Equipment
- Hand weapons (included)
- Chracian great blades (included)
- Light armour (included)

## Special Rules
- Elven Reflexes
- Move Through Cover
- Skirmishers
- Valour of Ages
- Vanguard (default)

## Equipment Options
- Warbows (+1 pt per model)
- Heavy armour (+1 pt per model) - replaces light armour

## Deployment Options (Mutually Exclusive)
- **Vanguard** (0 pts, default) - Unit deploys using Vanguard special rule
- **Scouts** (0 pts) - Unit gains Scouts special rule (0-1 unit limit)
- **Ambushers** (+1 pt per model) - Unit gains Ambushers special rule (0-1 unit limit)

## Special Rule Options
- **Lion Cloak** (+1 pt per model) - Grants additional protection

## Command Group
- **Chracian Captain (Champion)**: +7 pts, A+1
- **Standard Bearer**: +7 pts
- **Musician**: +7 pts

## Army Composition
- **The Chracian Warhost**: Core choice
- Can take Scouts (0-1 unit) or Ambushers (0-1 unit) variants per army

## Implementation Details

### Files Created/Modified
1. **TowModelType.cs**: Added `ChracianWoodsmen` enum entry
2. **ChracianWoodsmenTowModel.cs**: Created main unit class with champion

### Unit Class Implementation
- Inherits from `TowModel` (Regular Infantry)
- Stats: M5 WS4 BS4 S4 T3 W1 I4 A1 Ld8 (12 points)
- Champion stats: A+1 (additional attack)
- Minimum unit size: 5
- Base size: 25x25mm
- Command group: Chracian Captain (+7 pts), Standard Bearer (+7 pts), Musician (+7 pts)

### Special Rules Implementation
- **Core special rules**: Elven Reflexes, Move Through Cover, Skirmishers, Valour of Ages
- **Default deployment**: Vanguard (always active)
- **Optional deployment**: Scouts or Ambushers (mutually exclusive)
- **Enhancement**: Lion Cloak (optional)

### Equipment Implementation
- **Default weapons**: Hand weapons, Chracian great blades
- **Default armor**: Light armour
- **Optional weapons**: Warbows (+1 pt)
- **Optional armor**: Heavy armour (+1 pt, replaces light armour)

### Special Features
- **Skirmishers formation** - Unit uses skirmish deployment and rules
- **Move Through Cover** - Can move through difficult terrain without penalty
- **Vanguard deployment** - Can deploy forward before battle begins
- **Alternative deployment options** - Scouts or Ambushers for different tactical roles
- **Chracian great blades** - Specialized two-handed weapons from Chrace

## Validation
- ✅ Build successful
- ✅ All required enums exist
- ✅ Special rules implemented and validated
- ✅ Unit class follows established patterns
- ✅ Stats match official rules (M5 WS4 BS4 S4 T3 W1 I4 A1 Ld8)
- ✅ Points costs match official data (12 pts base, command +7 each)
- ✅ Equipment options implemented correctly
- ✅ Optional special rules available
- ✅ Champion variant with enhanced attacks

## Notes
- Chracian Woodsmen are specialized infantry from the realm of Chrace
- They are elite forest fighters with access to the unique Chracian great blades
- The unit can be configured for different tactical roles via deployment options:
  - **Vanguard**: Fast forward deployment for early positioning
  - **Scouts**: Infiltration and forward reconnaissance
  - **Ambushers**: Hidden deployment for surprise attacks
- Lion Cloak option represents the traditional protective cloaks of Chracian hunters
- Only available as Core choice in The Chracian Warhost army composition
