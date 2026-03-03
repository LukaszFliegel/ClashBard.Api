import { Modal, List, Typography, Tabs } from 'antd';
import { v4 as uuidv4 } from 'uuid';
import { useCatalog } from '../contexts/CatalogContext';
import { useArmy } from '../contexts/ArmyContext';
import type { ArmyCharacterConfigDto, ArmyUnitConfigDto } from '../types/army';

interface Props {
  modelType: 'character' | 'unit' | null;
  onClose: () => void;
}

export default function AddModelModal({ modelType, onClose }: Props) {
  const { catalog } = useCatalog();
  const { dispatch, activeArmy } = useArmy();

  if (!activeArmy || !catalog) return null;

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
    dispatch({
      type: 'ADD_CHARACTER',
      payload: { armyId: activeArmy!.id, character },
    });
    dispatch({
      type: 'SELECT_ITEM',
      payload: { id: character.id, itemType: 'character' },
    });
    onClose();
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
    dispatch({
      type: 'ADD_UNIT',
      payload: { armyId: activeArmy!.id, unit },
    });
    dispatch({
      type: 'SELECT_ITEM',
      payload: { id: unit.id, itemType: 'unit' },
    });
    onClose();
  }

  if (modelType === 'character') {
    return (
      <Modal
        title="Add Character"
        open
        onCancel={onClose}
        footer={null}
        width={480}
      >
        <List
          dataSource={catalog.characters}
          renderItem={(ch) => (
            <List.Item
              style={{ cursor: 'pointer' }}
              onClick={() => addCharacter(ch.modelTypeId)}
            >
              <List.Item.Meta
                title={ch.name}
                description={`${ch.basePoints} pts – ${ch.troopType}`}
              />
            </List.Item>
          )}
        />
      </Modal>
    );
  }

  if (modelType === 'unit') {
    const core = catalog.units.filter((u) => u.slotType === 'Core');
    const special = catalog.units.filter((u) => u.slotType === 'Special');
    const rare = catalog.units.filter((u) => u.slotType === 'Rare');

    const tabItems = [
      {
        key: 'core',
        label: 'Core',
        children: (
          <UnitPickList units={core} onSelect={addUnit} />
        ),
      },
      {
        key: 'special',
        label: 'Special',
        children: (
          <UnitPickList units={special} onSelect={addUnit} />
        ),
      },
      {
        key: 'rare',
        label: 'Rare',
        children: (
          <UnitPickList units={rare} onSelect={addUnit} />
        ),
      },
    ];

    return (
      <Modal
        title="Add Unit"
        open
        onCancel={onClose}
        footer={null}
        width={480}
      >
        <Tabs items={tabItems} />
      </Modal>
    );
  }

  return null;
}

import type { UnitModelCatalogDto } from '../types/catalog';

function UnitPickList({
  units,
  onSelect,
}: {
  units: UnitModelCatalogDto[];
  onSelect: (id: string) => void;
}) {
  return (
    <List
      dataSource={units}
      renderItem={(u) => (
        <List.Item
          style={{ cursor: 'pointer' }}
          onClick={() => onSelect(u.modelTypeId)}
        >
          <List.Item.Meta
            title={u.name}
            description={`${u.pointsPerModel} pts/model – min ${u.minUnitSize}`}
          />
        </List.Item>
      )}
    />
  );
}
