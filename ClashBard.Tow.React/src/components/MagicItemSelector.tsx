import { useMemo } from 'react';
import { Card, Checkbox, Space, Tag, Typography } from 'antd';
import { useCatalog } from '../contexts/CatalogContext';

interface Props {
  selectedIds: string[];
  allowance: number;
  categories: string[];
  onChange: (ids: string[]) => void;
  title?: string;
}

export default function MagicItemSelector({
  selectedIds,
  allowance,
  categories,
  onChange,
  title = 'Magic Items',
}: Props) {
  const { catalog } = useCatalog();

  const availableItems = useMemo(() => {
    if (!catalog) return [];
    return catalog.magicItems.filter(
      (mi) =>
        categories.includes(mi.category) &&
        mi.category !== 'MagicStandard', // banners handled separately
    );
  }, [catalog, categories]);

  const totalSpent = useMemo(() => {
    if (!catalog) return 0;
    return selectedIds.reduce((sum, id) => {
      const item = catalog.magicItems.find((mi) => mi.id === id);
      return sum + (item?.points ?? 0);
    }, 0);
  }, [catalog, selectedIds]);

  // Group by category
  const grouped = useMemo(() => {
    const map = new Map<string, typeof availableItems>();
    for (const item of availableItems) {
      const list = map.get(item.category) ?? [];
      list.push(item);
      map.set(item.category, list);
    }
    return map;
  }, [availableItems]);

  return (
    <Card
      size="small"
      title={
        <Space>
          {title}
          <Tag color={totalSpent > allowance ? 'red' : 'green'}>
            {totalSpent} / {allowance} pts
          </Tag>
        </Space>
      }
    >
      <Checkbox.Group
        value={selectedIds}
        onChange={(vals) => onChange(vals as string[])}
      >
        <Space direction="vertical" style={{ width: '100%' }}>
          {[...grouped.entries()].map(([category, items]) => (
            <div key={category}>
              <Typography.Text strong type="secondary">
                {formatCategory(category)}
              </Typography.Text>
              <div style={{ marginLeft: 8, marginTop: 4 }}>
                {items.map((mi) => (
                  <div key={mi.id}>
                    <Checkbox value={mi.id}>
                      {mi.name}{' '}
                      <Tag>{mi.points} pts</Tag>
                      {mi.isFactionSpecific && (
                        <Tag color="purple">
                          DE
                        </Tag>
                      )}
                    </Checkbox>
                  </div>
                ))}
              </div>
            </div>
          ))}
        </Space>
      </Checkbox.Group>
    </Card>
  );
}

function formatCategory(cat: string): string {
  // Convert PascalCase to spaced: "MagicWeapons" → "Magic Weapons"
  return cat.replace(/([a-z])([A-Z])/g, '$1 $2');
}
