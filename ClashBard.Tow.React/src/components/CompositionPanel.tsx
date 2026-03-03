import {
  Button,
  Empty,
  Flex,
  List,
  Popconfirm,
  Tag,
  Typography,
  theme,
} from 'antd';
import {
  PlusOutlined,
  DeleteOutlined,
  StarOutlined,
  FlagOutlined,
} from '@ant-design/icons';
import { useArmy } from '../contexts/ArmyContext';
import { useCatalog } from '../contexts/CatalogContext';

export default function CompositionPanel() {
  const { state, dispatch, activeArmy } = useArmy();
  const { catalog } = useCatalog();
  const { token } = theme.useToken();

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

  function SectionHeader({ label, onAdd }: { label: string; onAdd: () => void }) {
    return (
      <div className="army-section-header">
        <Typography.Text strong>{label}</Typography.Text>
        <Button size="small" type="link" icon={<PlusOutlined />} onClick={onAdd}>
          Add
        </Button>
      </div>
    );
  }

  return (
    <>
      <Typography.Title level={4} style={{ marginTop: 0 }}>
        {activeArmy.name} – {activeArmy.pointsLimit} pts
      </Typography.Title>

      <div className="army-section">
        <SectionHeader
          label={`Characters (${activeArmy.characters.length})`}
          onAdd={() => dispatch({ type: 'SET_ADD_SLOT', payload: 'character' })}
        />
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
                  background: isSelected ? token.colorPrimaryBg : undefined,
                  borderLeft: isSelected ? `3px solid ${token.colorPrimary}` : '3px solid transparent',
                }}
                onClick={() =>
                  dispatch({ type: 'SELECT_ITEM', payload: { id: ch.id, itemType: 'character' } })
                }
                actions={[
                  <Popconfirm
                    key="del"
                    title="Remove?"
                    onConfirm={(e) => {
                      e?.stopPropagation();
                      dispatch({ type: 'REMOVE_CHARACTER', payload: { armyId: activeArmy.id, characterId: ch.id } });
                    }}
                  >
                    <Button type="text" danger size="small" icon={<DeleteOutlined />} onClick={(e) => e.stopPropagation()} />
                  </Popconfirm>,
                ]}
              >
                <Flex gap="small" align="center">
                  <Typography.Text>{nameOf(ch.modelTypeId)}</Typography.Text>
                  {activeArmy.generalId === ch.id && (
                    <Tag color="gold" icon={<StarOutlined />}>General</Tag>
                  )}
                  {activeArmy.bsbId === ch.id && (
                    <Tag color="blue" icon={<FlagOutlined />}>BSB</Tag>
                  )}
                </Flex>
              </List.Item>
            );
          }}
        />
      </div>

      <div className="army-section">
        <SectionHeader label={`Core (${coreUnits.length})`} onAdd={() => dispatch({ type: 'SET_ADD_SLOT', payload: 'Core' })} />
        <UnitSlotList units={coreUnits} nameOf={nameOf} token={token} />
      </div>

      <div className="army-section">
        <SectionHeader label={`Special (${specialUnits.length})`} onAdd={() => dispatch({ type: 'SET_ADD_SLOT', payload: 'Special' })} />
        <UnitSlotList units={specialUnits} nameOf={nameOf} token={token} />
      </div>

      <div className="army-section">
        <SectionHeader label={`Rare (${rareUnits.length})`} onAdd={() => dispatch({ type: 'SET_ADD_SLOT', payload: 'Rare' })} />
        <UnitSlotList units={rareUnits} nameOf={nameOf} token={token} />
      </div>
    </>
  );
}

/* ─── sub-component for unit slots ─── */

import type { ArmyUnitConfigDto } from '../types/army';
import type { GlobalToken } from 'antd';

function UnitSlotList({
  units,
  nameOf,
  token,
}: {
  units: ArmyUnitConfigDto[];
  nameOf: (id: string) => string;
  token: GlobalToken;
}) {
  const { state, dispatch, activeArmy } = useArmy();
  const { catalog } = useCatalog();

  if (!activeArmy) return null;

  function pointsOf(modelTypeId: string, amount: number): number {
    const cat = catalog?.units.find((u) => u.modelTypeId === modelTypeId);
    return cat ? cat.pointsPerModel * amount : 0;
  }

  return (
    <List
      size="small"
      dataSource={units}
      locale={{ emptyText: 'None' }}
      renderItem={(u) => {
        const isSelected =
          state.selectedItemId === u.id && state.selectedItemType === 'unit';
        const pts = pointsOf(u.modelTypeId, u.amount);
        return (
          <List.Item
            style={{
              cursor: 'pointer',
              background: isSelected ? token.colorPrimaryBg : undefined,
              borderLeft: isSelected ? `3px solid ${token.colorPrimary}` : '3px solid transparent',
            }}
            onClick={() =>
              dispatch({ type: 'SELECT_ITEM', payload: { id: u.id, itemType: 'unit' } })
            }
            actions={[
              <Popconfirm
                key="del"
                title="Remove?"
                onConfirm={(e) => {
                  e?.stopPropagation();
                  dispatch({ type: 'REMOVE_UNIT', payload: { armyId: activeArmy.id, unitId: u.id } });
                }}
              >
                <Button type="text" danger size="small" icon={<DeleteOutlined />} onClick={(e) => e.stopPropagation()} />
              </Popconfirm>,
            ]}
          >
            <Flex justify="space-between" align="center" style={{ flex: 1, paddingRight: 8 }}>
              <Typography.Text>
                {nameOf(u.modelTypeId)} × {u.amount}
              </Typography.Text>
              {pts > 0 && (
                <Typography.Text type="secondary">{pts} pts</Typography.Text>
              )}
            </Flex>
          </List.Item>
        );
      }}
    />
  );
}
