/* ===== Catalog DTOs (read-only, from API) ===== */

export interface FactionSummaryDto {
  id: string;
  name: string;
}

export interface ModelStatsDto {
  movement: number | null;
  weaponSkill: number | null;
  ballisticSkill: number | null;
  strength: number | null;
  toughness: number | null;
  wounds: number | null;
  initiative: number | null;
  attacks: number | null;
  leadership: number | null;
}

export interface CatalogOptionDto {
  id: string;
  name: string;
  cost: number;
}

export interface MountCatalogDto {
  id: string;
  name: string;
  cost: number;
  stats: ModelStatsDto | null;
  troopType: string;
  armorValue: number | null;
  toughnessAdded: number | null;
  woundsAdded: number | null;
}

export interface MageInfoDto {
  baseLevel: number;
  availableLevelUpgrades: CatalogOptionDto[];
  availableLores: CatalogOptionDto[];
}

export interface BsbInfoDto {
  upgradeCost: number;
  magicStandardAllowance: number;
}

export interface CharacterCatalogDto {
  modelTypeId: string;
  name: string;
  basePoints: number;
  stats: ModelStatsDto;
  troopType: string;
  baseSizeWidth: number | null;
  baseSizeLength: number | null;
  defaultWeapons: CatalogOptionDto[];
  availableWeapons: CatalogOptionDto[];
  defaultArmours: CatalogOptionDto[];
  availableArmours: CatalogOptionDto[];
  defaultSpecialRules: CatalogOptionDto[];
  availableSpecialRules: CatalogOptionDto[];
  availableMounts: MountCatalogDto[];
  availableMagicItemCategories: string[];
  magicItemAllowance: number;
  mageInfo: MageInfoDto | null;
  bsbInfo: BsbInfoDto | null;
}

export interface CommandGroupDto {
  championName: string | null;
  championCost: number | null;
  standardCost: number | null;
  musicianCost: number | null;
  magicStandardAllowance: number | null;
  championMagicItemAllowance: number | null;
  championMagicItemCategories: string[] | null;
}

export interface UnitModelCatalogDto {
  modelTypeId: string;
  name: string;
  slotType: string;
  pointsPerModel: number;
  stats: ModelStatsDto;
  troopType: string;
  minUnitSize: number;
  maxUnitSize: number | null;
  baseSizeWidth: number | null;
  baseSizeLength: number | null;
  defaultWeapons: CatalogOptionDto[];
  availableWeapons: CatalogOptionDto[];
  defaultArmours: CatalogOptionDto[];
  availableArmours: CatalogOptionDto[];
  defaultSpecialRules: CatalogOptionDto[];
  availableSpecialRules: CatalogOptionDto[];
  commandGroup: CommandGroupDto | null;
}

export interface MagicItemCatalogDto {
  id: string;
  name: string;
  points: number;
  category: string;
  isFactionSpecific: boolean;
}

export interface SlotPercentageRuleDto {
  slotType: string;
  minPercent: number | null;
  maxPercent: number | null;
}

export interface CompositionRulesDto {
  slotPercentages: SlotPercentageRuleDto[];
  bsbEligibleModelTypes: string[];
}

export interface FactionCatalogDto {
  factionId: string;
  factionName: string;
  characters: CharacterCatalogDto[];
  units: UnitModelCatalogDto[];
  magicItems: MagicItemCatalogDto[];
  compositionRules: CompositionRulesDto;
}
