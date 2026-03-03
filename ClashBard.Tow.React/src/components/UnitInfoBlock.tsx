import { Descriptions, Flex, Tag, Typography } from 'antd';
import type { CatalogOptionDto } from '../types/catalog';

interface Props {
  troopType: string;
  baseSizeWidth: number | null;
  baseSizeLength: number | null;
  minUnitSize?: number;
  defaultWeapons: CatalogOptionDto[];
  defaultArmours: CatalogOptionDto[];
  defaultSpecialRules: CatalogOptionDto[];
}

const CATEGORY_MAP: Record<string, string> = {
  RegularInfantry: 'Infantry',
  HeavyInfantry: 'Infantry',
  RegularInfantryCharacter: 'Infantry',
  MonstrousInfantry: 'Monstrous Infantry',
  Swarm: 'Swarm',
  LightCavalry: 'Cavalry',
  HeavyCavalry: 'Cavalry',
  MonstrousCavalry: 'Monstrous Cavalry',
  MonstrousCreature: 'Monstrous Creature',
  WarMachine: 'War Machine',
  HeavyChariot: 'Chariot',
  LightChariot: 'Chariot',
  Behemoth: 'Behemoth',
  WarBeast: 'War Beast',
};

function formatTroopType(troopType: string): string {
  // PascalCase → spaced: "RegularInfantry" → "Regular Infantry"
  return troopType.replace(/([a-z])([A-Z])/g, '$1 $2');
}

export default function UnitInfoBlock({
  troopType,
  baseSizeWidth,
  baseSizeLength,
  minUnitSize,
  defaultWeapons,
  defaultArmours,
  defaultSpecialRules,
}: Props) {
  const category = CATEGORY_MAP[troopType] ?? formatTroopType(troopType);
  const formattedTroopType = formatTroopType(troopType);

  const baseSizeStr =
    baseSizeWidth != null && baseSizeLength != null
      ? `${baseSizeWidth} × ${baseSizeLength} mm`
      : '—';

  const descItems = [
    { key: 'cat', label: 'Unit Category', children: category },
    { key: 'troop', label: 'Troop Type', children: formattedTroopType },
    { key: 'base', label: 'Base Size', children: baseSizeStr },
    ...(minUnitSize != null
      ? [{ key: 'size', label: 'Unit Size', children: `${minUnitSize}+` }]
      : []),
  ];

  const hasEquipment = defaultWeapons.length > 0 || defaultArmours.length > 0;
  const hasRules = defaultSpecialRules.length > 0;

  return (
    <div>
      <Descriptions
        size="small"
        bordered
        column={2}
        items={descItems}
        style={{ marginBottom: hasEquipment || hasRules ? 8 : 0 }}
      />

      {hasEquipment && (
        <div style={{ marginBottom: hasRules ? 6 : 0 }}>
          <Typography.Text type="secondary" style={{ fontSize: 12, marginRight: 6 }}>
            Equipment:
          </Typography.Text>
          <Flex gap={4} wrap="wrap" style={{ display: 'inline-flex' }}>
            {defaultWeapons.map((w) => (
              <Tag key={w.id} color="blue">
                {w.name}
              </Tag>
            ))}
            {defaultArmours.map((a) => (
              <Tag key={a.id} color="cyan">
                {a.name}
              </Tag>
            ))}
          </Flex>
        </div>
      )}

      {hasRules && (
        <div>
          <Typography.Text type="secondary" style={{ fontSize: 12, marginRight: 6 }}>
            Special Rules:
          </Typography.Text>
          <Flex gap={4} wrap="wrap" style={{ display: 'inline-flex' }}>
            {defaultSpecialRules.map((r) => (
              <Tag key={r.id} color="purple">
                {r.name}
              </Tag>
            ))}
          </Flex>
        </div>
      )}
    </div>
  );
}
