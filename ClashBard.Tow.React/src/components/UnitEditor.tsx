import {
  Card,
  Checkbox,
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

      <StatsBlock stats={cat.stats} troopType={cat.troopType} />

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
          <Space direction="vertical">
            {cmd.championName && cmd.championCost != null && (
              <Switch
                checkedChildren={`${cmd.championName} (${cmd.championCost} pts)`}
                unCheckedChildren={cmd.championName}
                checked={unit.hasChampion}
                onChange={(val) => update({ hasChampion: val })}
              />
            )}
            {cmd.standardCost != null && (
              <Switch
                checkedChildren={`Standard Bearer (${cmd.standardCost} pts)`}
                unCheckedChildren="Standard Bearer"
                checked={unit.hasStandard}
                onChange={(val) =>
                  update({
                    hasStandard: val,
                    magicStandardId: val ? unit.magicStandardId : null,
                  })
                }
              />
            )}
            {cmd.musicianCost != null && (
              <Switch
                checkedChildren={`Musician (${cmd.musicianCost} pts)`}
                unCheckedChildren="Musician"
                checked={unit.hasMusician}
                onChange={(val) => update({ hasMusician: val })}
              />
            )}
          </Space>
        </Card>
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
                  mi.category === 'MagicBanners' &&
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
