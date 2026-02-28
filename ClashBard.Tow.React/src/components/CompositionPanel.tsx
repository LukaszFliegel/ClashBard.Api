import { useState } from 'react';
import {
  Button,
  Collapse,
  Empty,
  List,
  Popconfirm,
  Space,
  Tag,
  Typography,
} from 'antd';
import {
  PlusOutlined,
  DeleteOutlined,
  StarOutlined,
  FlagOutlined,
} from '@ant-design/icons';
import { useArmy } from '../contexts/ArmyContext';
import { useCatalog } from '../contexts/CatalogContext';
import AddModelModal from './AddModelModal';

export default function CompositionPanel() {
  const { state, dispatch, activeArmy } = useArmy();
  const { catalog } = useCatalog();
  const [addType, setAddType] = useState<'character' | 'unit' | null>(null);

  if (!activeArmy) {
    return (
      <Empty
        description="Select or create an army to start building"
        style={{ marginTop: 80 }}
      />
    );
  }

  const charCatalog = catalog?.characters ?? [];
  const unitCatalog = catalog?.units ?? [];

  // Group units by slot
  const coreUnits = activeArmy.units.filter((u) => {
    const cat = unitCatalog.find((c) => c.modelTypeId === u.modelTypeId);
    return cat?.slotType === 'Core';
  });
  const specialUnits = activeArmy.units.filter((u) => {
    const cat = unitCatalog.find((c) => c.modelTypeId === u.modelTypeId);
    return cat?.slotType === 'Special';
  });
  const rareUnits = activeArmy.units.filter((u) => {
    const cat = unitCatalog.find((c) => c.modelTypeId === u.modelTypeId);
    return cat?.slotType === 'Rare';
  });

  function nameOf(modelTypeId: string): string {
    return (
      charCatalog.find((c) => c.modelTypeId === modelTypeId)?.name ??
      unitCatalog.find((u) => u.modelTypeId === modelTypeId)?.name ??
      modelTypeId
    );
  }

  const items = [
    {
      key: 'characters',
      label: `Characters (${activeArmy.characters.length})`,
      extra: (
        <Button
          size="small"
          type="link"
          icon={<PlusOutlined />}
          onClick={(e) => {
            e.stopPropagation();
            setAddType('character');
          }}
        >
          Add
        </Button>
      ),
      children: (
        <List
          size="small"
          dataSource={activeArmy.characters}
          locale={{ emptyText: 'No characters' }}
          renderItem={(ch) => {
            const isSelected =
              state.selectedItemId === ch.id && state.selectedItemType === 'character';
            return (
              <List.Item
                style={{
                  cursor: 'pointer',
                  background: isSelected ? 'rgba(114,46,209,0.15)' : undefined,
                }}
                onClick={() =>
                  dispatch({
                    type: 'SELECT_ITEM',
                    payload: { id: ch.id, itemType: 'character' },
                  })
                }
                actions={[
                  <Popconfirm
                    key="del"
                    title="Remove?"
                    onConfirm={(e) => {
                      e?.stopPropagation();
                      dispatch({
                        type: 'REMOVE_CHARACTER',
                        payload: { armyId: activeArmy.id, characterId: ch.id },
                      });
                    }}
                  >
                    <Button
                      type="text"
                      danger
                      size="small"
                      icon={<DeleteOutlined />}
                      onClick={(e) => e.stopPropagation()}
                    />
                  </Popconfirm>,
                ]}
              >
                <Space>
                  <Typography.Text>{nameOf(ch.modelTypeId)}</Typography.Text>
                  {activeArmy.generalId === ch.id && (
                    <Tag color="gold" icon={<StarOutlined />}>
                      General
                    </Tag>
                  )}
                  {activeArmy.bsbId === ch.id && (
                    <Tag color="blue" icon={<FlagOutlined />}>
                      BSB
                    </Tag>
                  )}
                </Space>
              </List.Item>
            );
          }}
        />
      ),
    },
    {
      key: 'core',
      label: `Core (${coreUnits.length})`,
      extra: (
        <Button
          size="small"
          type="link"
          icon={<PlusOutlined />}
          onClick={(e) => {
            e.stopPropagation();
            setAddType('unit');
          }}
        >
          Add
        </Button>
      ),
      children: <UnitSlotList units={coreUnits} nameOf={nameOf} />,
    },
    {
      key: 'special',
      label: `Special (${specialUnits.length})`,
      extra: (
        <Button
          size="small"
          type="link"
          icon={<PlusOutlined />}
          onClick={(e) => {
            e.stopPropagation();
            setAddType('unit');
          }}
        >
          Add
        </Button>
      ),
      children: <UnitSlotList units={specialUnits} nameOf={nameOf} />,
    },
    {
      key: 'rare',
      label: `Rare (${rareUnits.length})`,
      extra: (
        <Button
          size="small"
          type="link"
          icon={<PlusOutlined />}
          onClick={(e) => {
            e.stopPropagation();
            setAddType('unit');
          }}
        >
          Add
        </Button>
      ),
      children: <UnitSlotList units={rareUnits} nameOf={nameOf} />,
    },
  ];

  return (
    <>
      <Typography.Title level={4} style={{ marginTop: 0 }}>
        {activeArmy.name} – {activeArmy.pointsLimit} pts
      </Typography.Title>
      <Collapse
        defaultActiveKey={['characters', 'core', 'special', 'rare']}
        items={items}
      />
      <AddModelModal
        modelType={addType}
        onClose={() => setAddType(null)}
      />
    </>
  );
}

/* ─── sub-component for unit slots ─── */

import type { ArmyUnitConfigDto } from '../types/army';

function UnitSlotList({
  units,
  nameOf,
}: {
  units: ArmyUnitConfigDto[];
  nameOf: (id: string) => string;
}) {
  const { state, dispatch, activeArmy } = useArmy();

  if (!activeArmy) return null;

  return (
    <List
      size="small"
      dataSource={units}
      locale={{ emptyText: 'None' }}
      renderItem={(u) => {
        const isSelected =
          state.selectedItemId === u.id && state.selectedItemType === 'unit';
        return (
          <List.Item
            style={{
              cursor: 'pointer',
              background: isSelected ? 'rgba(114,46,209,0.15)' : undefined,
            }}
            onClick={() =>
              dispatch({
                type: 'SELECT_ITEM',
                payload: { id: u.id, itemType: 'unit' },
              })
            }
            actions={[
              <Popconfirm
                key="del"
                title="Remove?"
                onConfirm={(e) => {
                  e?.stopPropagation();
                  dispatch({
                    type: 'REMOVE_UNIT',
                    payload: { armyId: activeArmy.id, unitId: u.id },
                  });
                }}
              >
                <Button
                  type="text"
                  danger
                  size="small"
                  icon={<DeleteOutlined />}
                  onClick={(e) => e.stopPropagation()}
                />
              </Popconfirm>,
            ]}
          >
            <Typography.Text>
              {nameOf(u.modelTypeId)} × {u.amount}
            </Typography.Text>
          </List.Item>
        );
      }}
    />
  );
}
