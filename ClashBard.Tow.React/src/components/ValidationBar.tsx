import { Alert, Space, Spin, Tag, Typography } from 'antd';
import {
  CheckCircleOutlined,
  CloseCircleOutlined,
  LoadingOutlined,
} from '@ant-design/icons';
import { useArmy } from '../contexts/ArmyContext';

export default function ValidationBar() {
  const { state, activeArmy } = useArmy();
  const { validation, validating } = state;

  if (!activeArmy) return null;

  return (
    <div
      style={{
        padding: '8px 24px',
        borderBottom: '1px solid rgba(255,255,255,0.08)',
        display: 'flex',
        alignItems: 'center',
        gap: 16,
        flexWrap: 'wrap',
      }}
    >
      {validating && (
        <Space>
          <Spin indicator={<LoadingOutlined />} size="small" />
          <Typography.Text type="secondary">Validating…</Typography.Text>
        </Space>
      )}

      {validation && !validating && (
        <>
          <Tag
            icon={
              validation.isValid ? (
                <CheckCircleOutlined />
              ) : (
                <CloseCircleOutlined />
              )
            }
            color={validation.isValid ? 'success' : 'error'}
          >
            {validation.isValid ? 'Valid' : 'Invalid'}
          </Tag>

          <Typography.Text strong>
            {validation.totalPoints} / {activeArmy.pointsLimit} pts
          </Typography.Text>

          <Space size="small">
            <Tag>Characters: {validation.pointsBreakdown.characters}</Tag>
            <Tag>Core: {validation.pointsBreakdown.core}</Tag>
            <Tag>Special: {validation.pointsBreakdown.special}</Tag>
            <Tag>Rare: {validation.pointsBreakdown.rare}</Tag>
          </Space>

          {validation.errors.length > 0 && (
            <div style={{ width: '100%', marginTop: 4 }}>
              {validation.errors.map((e, i) => (
                <Alert
                  key={i}
                  type="warning"
                  showIcon
                  message={e.message}
                  style={{ marginBottom: 4 }}
                  closable
                />
              ))}
            </div>
          )}
        </>
      )}

      {!validation && !validating && (
        <Typography.Text type="secondary">
          Add models to see points & validation
        </Typography.Text>
      )}
    </div>
  );
}
