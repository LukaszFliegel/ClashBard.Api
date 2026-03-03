import {
  Card,
  Checkbox,
  Flex,
  InputNumber,
  Select,
  Space,
  Switch,
  Tag,
  Typography,
} from 'antd';
import { useCatalog } from '../contexts/CatalogContext';
import { useArmy } from '../contexts/ArmyContext';
import type { ArmyUnitConfigDto } from '../types/army';
import StatsBlock from './StatsBlock';
import UnitInfoBlock from './UnitInfoBlock';
import MagicItemSelector from './MagicItemSelector';

interface Props {
  unit: ArmyUnitConfigDto;
}

export default function UnitEditor({ unit }: Props) {
  const { catalog } = useCatalog();
  const { dispatch, activeArmy } = useArmy();

  if (!catalog || !activeArmy) return null;

  const cat = catalog.units.find((u) => u.modelTypeId === unit.modelTypeId);
  if (!cat) return null;

  function update(partial: Partial<ArmyUnitConfigDto>) {
    dispatch({
      type: 'UPDATE_UNIT',
      payload: {
        armyId: activeArmy!.id,
        unit: { ...unit, ...partial },
      },
    });
  }

  const cmd = cat.commandGroup;

  return (
    <Space direction="vertical" style={{ width: '100%' }} size="middle">
      <Typography.Title level={4} style={{ margin: 0 }}>
        {cat.name}
      </Typography.Title>

      <UnitInfoBlock
        troopType={cat.troopType}
        baseSizeWidth={cat.baseSizeWidth}
        baseSizeLength={cat.baseSizeLength}
        minUnitSize={cat.minUnitSize}
        defaultWeapons={cat.defaultWeapons}
        defaultArmours={cat.defaultArmours}
        defaultSpecialRules={cat.defaultSpecialRules}
      />

      <StatsBlock stats={cat.stats} />

      {/* Unit Size */}
      <Card size="small" title="Unit Size">
        <InputNumber
          min={cat.minUnitSize}
          max={cat.maxUnitSize ?? 99}
          value={unit.amount}
          onChange={(val) => val && update({ amount: val })}
          style={{ width: 120 }}
        />
        <Typography.Text type="secondary" style={{ marginLeft: 8 }}>
          ({cat.pointsPerModel} pts/model)
        </Typography.Text>
      </Card>

      {/* Command Group */}
      {cmd && (
        <Card size="small" title="Command Group">
          <Flex vertical gap="small">
            {cmd.championName && cmd.championCost != null && (
              <Flex align="center" gap={8}>
                <Switch
                  checked={unit.hasChampion}
                  onChange={(val) => update({ hasChampion: val, championMagicItemIds: val ? unit.championMagicItemIds : [] })}
                />
                <Typography.Text>
                  {cmd.championName}{unit.hasChampion ? ` (${cmd.championCost} pts)` : ''}
                </Typography.Text>
              </Flex>
            )}
            {cmd.standardCost != null && (
              <Flex align="center" gap={8}>
                <Switch
                  checked={unit.hasStandard}
                  onChange={(val) =>
                    update({
                      hasStandard: val,
                      magicStandardId: val ? unit.magicStandardId : null,
                    })
                  }
                />
                <Typography.Text>
                  Standard Bearer{unit.hasStandard ? ` (${cmd.standardCost} pts)` : ''}
                </Typography.Text>
              </Flex>
            )}
            {cmd.musicianCost != null && (
              <Flex align="center" gap={8}>
                <Switch
                  checked={unit.hasMusician}
                  onChange={(val) => update({ hasMusician: val })}
                />
                <Typography.Text>
                  Musician{unit.hasMusician ? ` (${cmd.musicianCost} pts)` : ''}
                </Typography.Text>
              </Flex>
            )}
          </Flex>
        </Card>
      )}

      {/* Champion Magic Items */}
      {unit.hasChampion && cmd?.championMagicItemAllowance != null && cmd.championMagicItemAllowance > 0 && cmd.championMagicItemCategories && (
        <MagicItemSelector
          title={`${cmd.championName ?? 'Champion'} Magic Items`}
          selectedIds={unit.championMagicItemIds}
          allowance={cmd.championMagicItemAllowance}
          categories={cmd.championMagicItemCategories}
          onChange={(ids) => update({ championMagicItemIds: ids })}
        />
      )}

      {/* Magic Standard for unit */}
      {unit.hasStandard && cmd?.magicStandardAllowance != null && cmd.magicStandardAllowance > 0 && (
        <Card size="small" title="Magic Standard">
          <Select
            allowClear
            placeholder="No magic standard"
            style={{ width: '100%' }}
            value={unit.magicStandardId}
            onChange={(val) => update({ magicStandardId: val ?? null })}
            options={catalog.magicItems
              .filter(
                (mi) =>
                  mi.category === 'MagicStandard' &&
                  mi.points <= cmd.magicStandardAllowance!,
              )
              .map((mi) => ({
                value: mi.id,
                label: `${mi.name} (${mi.points} pts)`,
              }))}
          />
        </Card>
      )}

      {/* Weapons */}
      {cat.availableWeapons.length > 0 && (
        <Card size="small" title="Weapons">
          <Checkbox.Group
            value={unit.equippedWeapons}
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
            value={unit.equippedArmours}
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

      {/* Special Rules */}
      {cat.availableSpecialRules.length > 0 && (
        <Card size="small" title="Special Rules">
          <Checkbox.Group
            value={unit.equippedSpecialRules}
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
    </Space>
  );
}

