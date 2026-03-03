import {
  Card,
  Checkbox,
  Flex,
  Radio,
  Select,
  Space,
  Switch,
  Tag,
  Typography,
} from 'antd';
import { useCatalog } from '../contexts/CatalogContext';
import { useArmy } from '../contexts/ArmyContext';
import type { ArmyCharacterConfigDto } from '../types/army';
import MagicItemSelector from './MagicItemSelector';
import StatsBlock from './StatsBlock';
import UnitInfoBlock from './UnitInfoBlock';

interface Props {
  character: ArmyCharacterConfigDto;
}

export default function CharacterEditor({ character }: Props) {
  const { catalog } = useCatalog();
  const { dispatch, activeArmy } = useArmy();

  if (!catalog || !activeArmy) return null;

  const cat = catalog.characters.find(
    (c) => c.modelTypeId === character.modelTypeId,
  );
  if (!cat) return null;

  function update(partial: Partial<ArmyCharacterConfigDto>) {
    dispatch({
      type: 'UPDATE_CHARACTER',
      payload: {
        armyId: activeArmy!.id,
        character: { ...character, ...partial },
      },
    });
  }

  const isBsbEligible = catalog!.compositionRules.bsbEligibleModelTypes.includes(
    character.modelTypeId,
  );

  return (
    <Space direction="vertical" style={{ width: '100%' }} size="middle">
      <Typography.Title level={4} style={{ margin: 0 }}>
        {cat.name}
      </Typography.Title>

      <UnitInfoBlock
        troopType={cat.troopType}
        baseSizeWidth={cat.baseSizeWidth}
        baseSizeLength={cat.baseSizeLength}
        defaultWeapons={cat.defaultWeapons}
        defaultArmours={cat.defaultArmours}
        defaultSpecialRules={cat.defaultSpecialRules}
      />

      <StatsBlock stats={cat.stats} />

      {/* General / BSB toggles */}
      <Card size="small" title="Roles">
        <Flex vertical gap="small">
          <Flex align="center" gap={8}>
            <Switch
              checked={activeArmy.generalId === character.id}
              onChange={(checked) =>
                dispatch({
                  type: 'SET_GENERAL',
                  payload: { armyId: activeArmy!.id, characterId: checked ? character.id : null },
                })
              }
            />
            <Typography.Text>General</Typography.Text>
          </Flex>
          {isBsbEligible && (
            <Flex align="center" gap={8}>
              <Switch
                checked={character.isBsb}
                onChange={(checked) => {
                  update({ isBsb: checked, magicStandardId: checked ? character.magicStandardId : null });
                  dispatch({
                    type: 'SET_BSB',
                    payload: { armyId: activeArmy!.id, characterId: checked ? character.id : null },
                  });
                }}
              />
              <Typography.Text>Battle Standard Bearer</Typography.Text>
            </Flex>
          )}
        </Flex>
      </Card>

      {/* Weapons */}
      {cat.availableWeapons.length > 0 && (
        <Card size="small" title="Weapons">
          <Checkbox.Group
            value={character.equippedWeapons}
            onChange={(vals) => update({ equippedWeapons: vals as string[] })}
          >
            <Space direction="vertical">
              {cat.availableWeapons.map((w) => (
                <Checkbox key={w.id} value={w.id}>
                  {w.name} {w.cost > 0 && <Tag>{w.cost} pts</Tag>}
                </Checkbox>
              ))}
            </Space>
          </Checkbox.Group>
        </Card>
      )}

      {/* Armours */}
      {cat.availableArmours.length > 0 && (
        <Card size="small" title="Armour">
          <Checkbox.Group
            value={character.equippedArmours}
            onChange={(vals) => update({ equippedArmours: vals as string[] })}
          >
            <Space direction="vertical">
              {cat.availableArmours.map((a) => (
                <Checkbox key={a.id} value={a.id}>
                  {a.name} {a.cost > 0 && <Tag>{a.cost} pts</Tag>}
                </Checkbox>
              ))}
            </Space>
          </Checkbox.Group>
        </Card>
      )}

      {/* Special Rules (purchasable) */}
      {cat.availableSpecialRules.length > 0 && (
        <Card size="small" title="Special Rules">
          <Checkbox.Group
            value={character.equippedSpecialRules}
            onChange={(vals) => update({ equippedSpecialRules: vals as string[] })}
          >
            <Space direction="vertical">
              {cat.availableSpecialRules.map((r) => (
                <Checkbox key={r.id} value={r.id}>
                  {r.name} {r.cost > 0 && <Tag>{r.cost} pts</Tag>}
                </Checkbox>
              ))}
            </Space>
          </Checkbox.Group>
        </Card>
      )}

      {/* Mount */}
      {cat.availableMounts.length > 0 && (
        <Card size="small" title="Mount">
          <Select
            allowClear
            placeholder="No mount"
            style={{ width: '100%' }}
            value={character.mountId}
            onChange={(val) => update({ mountId: val ?? null })}
            options={cat.availableMounts.map((m) => ({
              value: m.id,
              label: `${m.name} (${m.cost} pts)`,
            }))}
          />
        </Card>
      )}

      {/* Magic Level / Lore */}
      {cat.mageInfo && (
        <Card size="small" title="Magic">
          <Space direction="vertical" style={{ width: '100%' }}>
            <div>
              <Typography.Text type="secondary" style={{ display: 'block', marginBottom: 6 }}>
                Level
              </Typography.Text>
              <Radio.Group
                value={character.magicLevel ?? '__base__'}
                optionType="button"
                buttonStyle="solid"
                onChange={(e) => {
                  const val = e.target.value;
                  update({ magicLevel: val === '__base__' ? null : val });
                }}
              >
                <Radio.Button value="__base__">
                  Level {cat.mageInfo!.baseLevel} (Base)
                </Radio.Button>
                {cat.mageInfo!.availableLevelUpgrades.map((l) => (
                  <Radio.Button key={l.id} value={l.id}>
                    {l.name} (+{l.cost} pts)
                  </Radio.Button>
                ))}
              </Radio.Group>
            </div>
            <div>
              <Typography.Text type="secondary">Lore</Typography.Text>
              <Select
                style={{ width: '100%' }}
                value={character.magicLore}
                onChange={(val) => update({ magicLore: val ?? null })}
                allowClear
                placeholder="Select lore"
                options={cat.mageInfo!.availableLores.map((l) => ({
                  value: l.id,
                  label: l.name,
                }))}
              />
            </div>
          </Space>
        </Card>
      )}

      {/* BSB Magic Standard */}
      {character.isBsb && cat.bsbInfo && (
        <Card size="small" title="Magic Standard (BSB)">
          <Select
            allowClear
            placeholder="No magic standard"
            style={{ width: '100%' }}
            value={character.magicStandardId}
            onChange={(val) => update({ magicStandardId: val ?? null })}
            options={catalog.magicItems
              .filter((mi) => mi.category === 'MagicStandard' && mi.points <= cat.bsbInfo!.magicStandardAllowance)
              .map((mi) => ({
                value: mi.id,
                label: `${mi.name} (${mi.points} pts)`,
              }))}
          />
        </Card>
      )}

      {/* Magic Items */}
      {cat.magicItemAllowance > 0 && (
        <MagicItemSelector
          selectedIds={character.magicItemIds}
          allowance={cat.magicItemAllowance}
          categories={cat.availableMagicItemCategories}
          onChange={(ids) => update({ magicItemIds: ids })}
        />
      )}
    </Space>
  );
}
