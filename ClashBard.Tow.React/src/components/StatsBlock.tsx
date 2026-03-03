import { Table } from 'antd';
import type { ModelStatsDto } from '../types/catalog';

interface Props {
  stats: ModelStatsDto;
}

const COLUMNS = [
  { key: 'M', title: 'M', dataIndex: 'M' },
  { key: 'WS', title: 'WS', dataIndex: 'WS' },
  { key: 'BS', title: 'BS', dataIndex: 'BS' },
  { key: 'S', title: 'S', dataIndex: 'S' },
  { key: 'T', title: 'T', dataIndex: 'T' },
  { key: 'W', title: 'W', dataIndex: 'W' },
  { key: 'I', title: 'I', dataIndex: 'I' },
  { key: 'A', title: 'A', dataIndex: 'A' },
  { key: 'Ld', title: 'Ld', dataIndex: 'Ld' },
].map((col) => ({
  ...col,
  width: 48,
  align: 'center' as const,
  onHeaderCell: () => ({ style: { textAlign: 'center' as const, fontWeight: 600, padding: '4px 2px' } }),
  onCell: () => ({ style: { textAlign: 'center' as const, padding: '4px 2px' } }),
}));

export default function StatsBlock({ stats }: Props) {
  const dataSource = [
    {
      key: 'stats',
      M: stats.movement ?? '-',
      WS: stats.weaponSkill ?? '-',
      BS: stats.ballisticSkill ?? '-',
      S: stats.strength ?? '-',
      T: stats.toughness ?? '-',
      W: stats.wounds ?? '-',
      I: stats.initiative ?? '-',
      A: stats.attacks ?? '-',
      Ld: stats.leadership ?? '-',
    },
  ];

  return (
    <Table
      columns={COLUMNS}
      dataSource={dataSource}
      pagination={false}
      size="small"
      bordered
      showHeader
    />
  );
}

