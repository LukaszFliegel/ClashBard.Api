import { useState } from 'react';
import {
  Button,
  Card,
  List,
  Typography,
  Popconfirm,
  Space,
} from 'antd';
import {
  PlusOutlined,
  DeleteOutlined,
} from '@ant-design/icons';
import { useArmy } from '../contexts/ArmyContext';
import CreateArmyModal from './CreateArmyModal';

export default function ArmyListPanel() {
  const { state, dispatch } = useArmy();
  const [modalOpen, setModalOpen] = useState(false);

  return (
    <>
      <Space direction="vertical" style={{ width: '100%' }}>
        <Button
          type="primary"
          icon={<PlusOutlined />}
          block
          onClick={() => setModalOpen(true)}
        >
          New Army
        </Button>

        <List
          dataSource={state.armies}
          locale={{ emptyText: 'No armies yet' }}
          renderItem={(army) => (
            <Card
              size="small"
              hoverable
              className={army.id === state.activeArmyId ? 'army-card-active' : ''}
              style={{
                marginBottom: 8,
                borderColor:
                  army.id === state.activeArmyId ? '#722ed1' : undefined,
              }}
              onClick={() => dispatch({ type: 'SET_ACTIVE_ARMY', payload: army.id })}
            >
              <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                <div>
                  <Typography.Text strong>{army.name}</Typography.Text>
                  <br />
                  <Typography.Text type="secondary">
                    {army.pointsLimit} pts
                  </Typography.Text>
                </div>
                <Popconfirm
                  title="Delete this army?"
                  onConfirm={(e) => {
                    e?.stopPropagation();
                    dispatch({ type: 'DELETE_ARMY', payload: army.id });
                  }}
                  onCancel={(e) => e?.stopPropagation()}
                >
                  <Button
                    type="text"
                    danger
                    size="small"
                    icon={<DeleteOutlined />}
                    onClick={(e) => e.stopPropagation()}
                  />
                </Popconfirm>
              </div>
            </Card>
          )}
        />
      </Space>

      <CreateArmyModal open={modalOpen} onClose={() => setModalOpen(false)} />
    </>
  );
}
