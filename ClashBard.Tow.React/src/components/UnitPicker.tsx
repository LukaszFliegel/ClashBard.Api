import { Button, Flex, List, Typography } from 'antd';
import { CloseOutlined } from '@ant-design/icons';
import { v4 as uuidv4 } from 'uuid';
import { useCatalog } from '../contexts/CatalogContext';
import { useArmy } from '../contexts/ArmyContext';
import type { AddSlot } from '../contexts/ArmyContext';
import type { ArmyCharacterConfigDto, ArmyUnitConfigDto } from '../types/army';

interface Props {
  slot: AddSlot;
}

export default function UnitPicker({ slot }: Props) {
  const { catalog } = useCatalog();
  const { dispatch, activeArmy } = useArmy();

  if (!catalog || !activeArmy) return null;

  const title =
    slot === 'character'
      ? 'Add Character'
      : `Add ${slot} Unit`;

  function close() {
    dispatch({ type: 'SET_ADD_SLOT', payload: null });
  }

  function addCharacter(modelTypeId: string) {
    const cat = catalog!.characters.find((c) => c.modelTypeId === modelTypeId);
    if (!cat) return;

    const character: ArmyCharacterConfigDto = {
      id: uuidv4(),
      modelTypeId,
      mountId: null,
      equippedWeapons: cat.defaultWeapons.map((w) => w.id),
      equippedArmours: cat.defaultArmours.map((a) => a.id),
      equippedSpecialRules: [],
      magicItemIds: [],
      magicLevel: null,
      magicLore: null,
      isBsb: false,
      magicStandardId: null,
    };
    dispatch({ type: 'ADD_CHARACTER', payload: { armyId: activeArmy!.id, character } });
    dispatch({ type: 'SELECT_ITEM', payload: { id: character.id, itemType: 'character' } });
  }

  function addUnit(modelTypeId: string) {
    const cat = catalog!.units.find((u) => u.modelTypeId === modelTypeId);
    if (!cat) return;

    const unit: ArmyUnitConfigDto = {
      id: uuidv4(),
      modelTypeId,
      amount: cat.minUnitSize,
      hasStandard: false,
      hasMusician: false,
      hasChampion: false,
      equippedWeapons: cat.defaultWeapons.map((w) => w.id),
      equippedArmours: cat.defaultArmours.map((a) => a.id),
      equippedSpecialRules: [],
      magicStandardId: null,
      championMagicItemIds: [],
    };
    dispatch({ type: 'ADD_UNIT', payload: { armyId: activeArmy!.id, unit } });
    dispatch({ type: 'SELECT_ITEM', payload: { id: unit.id, itemType: 'unit' } });
  }

  if (slot === 'character') {
    return (
      <div>
        <Flex justify="space-between" align="center" style={{ marginBottom: 12 }}>
          <Typography.Title level={4} style={{ margin: 0 }}>
            {title}
          </Typography.Title>
          <Button type="text" icon={<CloseOutlined />} onClick={close} />
        </Flex>
        <List
          size="small"
          dataSource={catalog.characters}
          renderItem={(ch) => (
            <List.Item
              style={{ cursor: 'pointer' }}
              onClick={() => addCharacter(ch.modelTypeId)}
            >
              <List.Item.Meta
                title={ch.name}
                description={`${ch.basePoints} pts – ${ch.troopType.replace(/([a-z])([A-Z])/g, '$1 $2')}`}
              />
            </List.Item>
          )}
        />
      </div>
    );
  }

  const units = catalog.units.filter((u) => u.slotType === slot);

  return (
    <div>
      <Flex justify="space-between" align="center" style={{ marginBottom: 12 }}>
        <Typography.Title level={4} style={{ margin: 0 }}>
          {title}
        </Typography.Title>
        <Button type="text" icon={<CloseOutlined />} onClick={close} />
      </Flex>
      <List
        size="small"
        dataSource={units}
        locale={{ emptyText: `No ${slot} units available` }}
        renderItem={(u) => (
          <List.Item
            style={{ cursor: 'pointer' }}
            onClick={() => addUnit(u.modelTypeId)}
          >
            <List.Item.Meta
              title={u.name}
              description={`${u.pointsPerModel} pts/model – min ${u.minUnitSize} – ${u.troopType.replace(/([a-z])([A-Z])/g, '$1 $2')}`}
            />
          </List.Item>
        )}
      />
    </div>
  );
}
