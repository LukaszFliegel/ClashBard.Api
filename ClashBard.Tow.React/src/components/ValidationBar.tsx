import { Alert, Flex, Space, Tag, Typography, theme } from 'antd';
import {
  CheckCircleOutlined,
  CloseCircleOutlined,
} from '@ant-design/icons';
import { useArmy } from '../contexts/ArmyContext';

export default function ValidationBar() {
  const { state, activeArmy } = useArmy();
  const { validation } = state;
  const { token } = theme.useToken();

  return (
    <Flex
      className="validation-bar"
      align="center"
      gap={16}
      wrap
      style={{ borderBottomColor: token.colorBorderSecondary, minHeight: 45 }}
    >
      {activeArmy && validation && (
        <>
          <Tag
            icon={validation.isValid ? <CheckCircleOutlined /> : <CloseCircleOutlined />}
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
            <Flex vertical style={{ width: '100%', marginTop: 4 }} gap={4}>
              {validation.errors.map((e, i) => (
                <Alert key={i} type="warning" showIcon message={e.message} closable />
              ))}
            </Flex>
          )}
        </>
      )}
    </Flex>
  );
}
