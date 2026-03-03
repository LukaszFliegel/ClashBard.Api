import { useState } from 'react';
import { Button, Card, Flex, List, Popconfirm, Typography } from 'antd';
import { DeleteOutlined, PlusOutlined } from '@ant-design/icons';
import { useArmy } from '../contexts/ArmyContext';
import CreateArmyModal from './CreateArmyModal';

export default function ArmyListPanel() {
  const { state, dispatch } = useArmy();
  const [modalOpen, setModalOpen] = useState(false);

  return (
    <>
      <Flex vertical gap="small" className="army-list">
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
              className={`army-card-content${army.id === state.activeArmyId ? ' army-card-active' : ''}`}
              onClick={() => dispatch({ type: 'SET_ACTIVE_ARMY', payload: army.id })}
            >
              <Flex justify="space-between" align="center">
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
              </Flex>
            </Card>
          )}
        />
      </Flex>

      <CreateArmyModal open={modalOpen} onClose={() => setModalOpen(false)} />
    </>
  );
}
