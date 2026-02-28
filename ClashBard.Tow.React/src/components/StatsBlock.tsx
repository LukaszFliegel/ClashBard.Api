import { Descriptions } from 'antd';
import type { ModelStatsDto } from '../types/catalog';

interface Props {
  stats: ModelStatsDto;
  troopType: string;
}

export default function StatsBlock({ stats, troopType }: Props) {
  const items = [
    { key: 'M', label: 'M', children: stats.movement ?? '-' },
    { key: 'WS', label: 'WS', children: stats.weaponSkill ?? '-' },
    { key: 'BS', label: 'BS', children: stats.ballisticSkill ?? '-' },
    { key: 'S', label: 'S', children: stats.strength ?? '-' },
    { key: 'T', label: 'T', children: stats.toughness ?? '-' },
    { key: 'W', label: 'W', children: stats.wounds ?? '-' },
    { key: 'I', label: 'I', children: stats.initiative ?? '-' },
    { key: 'A', label: 'A', children: stats.attacks ?? '-' },
    { key: 'Ld', label: 'Ld', children: stats.leadership ?? '-' },
  ];

  return (
    <Descriptions
      bordered
      size="small"
      column={9}
      title={troopType}
      items={items}
    />
  );
}
