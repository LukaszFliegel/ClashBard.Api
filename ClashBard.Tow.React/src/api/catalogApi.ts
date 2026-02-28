import type { FactionSummaryDto, FactionCatalogDto } from '../types/catalog';
import type {
  ArmyConfigurationDto,
  ArmyValidationResponseDto,
} from '../types/army';

const BASE = '/api';

async function fetchJson<T>(url: string, init?: RequestInit): Promise<T> {
  const res = await fetch(url, init);
  if (!res.ok) {
    const text = await res.text();
    throw new Error(`API ${res.status}: ${text}`);
  }
  return res.json() as Promise<T>;
}

export async function getFactions(): Promise<FactionSummaryDto[]> {
  return fetchJson<FactionSummaryDto[]>(`${BASE}/catalog/factions`);
}

export async function getFactionCatalog(
  factionId: string,
): Promise<FactionCatalogDto> {
  return fetchJson<FactionCatalogDto>(
    `${BASE}/catalog/factions/${encodeURIComponent(factionId)}`,
  );
}

export async function validateArmy(
  config: ArmyConfigurationDto,
): Promise<ArmyValidationResponseDto> {
  return fetchJson<ArmyValidationResponseDto>(`${BASE}/armies/validate`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(config),
  });
}

export async function calculatePoints(
  config: ArmyConfigurationDto,
): Promise<ArmyValidationResponseDto> {
  return fetchJson<ArmyValidationResponseDto>(
    `${BASE}/armies/calculate-points`,
    {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(config),
    },
  );
}
