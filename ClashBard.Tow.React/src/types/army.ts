/* ===== Army Configuration DTOs (sent to API) ===== */

export interface ArmyConfigurationDto {
  factionId: string;
  pointsLimit: number;
  generalId: string | null;
  bsbId: string | null;
  characters: ArmyCharacterConfigDto[];
  units: ArmyUnitConfigDto[];
}

export interface ArmyCharacterConfigDto {
  id: string;
  modelTypeId: string;
  mountId: string | null;
  equippedWeapons: string[];
  equippedArmours: string[];
  equippedSpecialRules: string[];
  magicItemIds: string[];
  magicLevel: string | null;
  magicLore: string | null;
  isBsb: boolean;
  magicStandardId: string | null;
}

export interface ArmyUnitConfigDto {
  id: string;
  modelTypeId: string;
  amount: number;
  hasStandard: boolean;
  hasMusician: boolean;
  hasChampion: boolean;
  equippedWeapons: string[];
  equippedArmours: string[];
  equippedSpecialRules: string[];
  magicStandardId: string | null;
  championMagicItemIds: string[];
}

/* ===== Validation Response DTOs (from API) ===== */

export interface ArmyValidationResponseDto {
  isValid: boolean;
  totalPoints: number;
  pointsBreakdown: PointsBreakdownDto;
  errors: ValidationErrorDto[];
}

export interface PointsBreakdownDto {
  characters: number;
  core: number;
  special: number;
  rare: number;
  total: number;
}

export interface ValidationErrorDto {
  message: string;
  owner: string | null;
}

/* ===== Local Army State (stored in localStorage) ===== */

export interface StoredArmy {
  id: string;
  name: string;
  factionId: string;
  pointsLimit: number;
  generalId: string | null;
  bsbId: string | null;
  characters: ArmyCharacterConfigDto[];
  units: ArmyUnitConfigDto[];
  createdAt: string;
  updatedAt: string;
}
