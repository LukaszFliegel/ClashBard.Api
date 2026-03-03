import { useEffect, useState } from 'react';
import { Flex, Form, Input, InputNumber, Modal, Select, Tag } from 'antd';
import { useArmy } from '../contexts/ArmyContext';
import { getFactions } from '../api/catalogApi';
import type { FactionSummaryDto } from '../types/catalog';
import './CreateArmyModal.css';

const POINTS_PRESETS = [750, 1000, 1200, 1500, 2000, 2200];

interface Props {
  open: boolean;
  onClose: () => void;
}

export default function CreateArmyModal({ open, onClose }: Props) {
  const [form] = Form.useForm();
  const { dispatch } = useArmy();
  const [factions, setFactions] = useState<FactionSummaryDto[]>([]);
  const [loadingFactions, setLoadingFactions] = useState(false);
  const currentPoints = Form.useWatch('pointsLimit', form);

  useEffect(() => {
    if (!open) return;
    setLoadingFactions(true);
    getFactions()
      .then(setFactions)
      .catch(() => setFactions([]))
      .finally(() => setLoadingFactions(false));
  }, [open]);

  function handleOk() {
    form.validateFields().then((values) => {
      dispatch({
        type: 'CREATE_ARMY',
        payload: {
          name: values.name,
          factionId: values.factionId,
          pointsLimit: values.pointsLimit,
        },
      });
      form.resetFields();
      onClose();
    });
  }

  return (
    <Modal
      title="Create New Army"
      open={open}
      onOk={handleOk}
      onCancel={onClose}
      destroyOnClose
    >
      <Form form={form} layout="vertical" initialValues={{ pointsLimit: 2000 }}>
        <Form.Item
          name="factionId"
          label="Faction"
          rules={[{ required: true, message: 'Select a faction' }]}
        >
          <Select
            showSearch
            placeholder="Select a faction"
            loading={loadingFactions}
            filterOption={(input, option) =>
              (option?.label as string ?? '').toLowerCase().includes(input.toLowerCase())
            }
            options={factions.map((f) => ({ value: f.id, label: f.name }))}
          />
        </Form.Item>
        <Form.Item
          name="name"
          label="Army Name"
          rules={[{ required: true, message: 'Enter a name' }]}
        >
          <Input placeholder="My Army" />
        </Form.Item>
        <Form.Item
          name="pointsLimit"
          label="Points Limit"
          rules={[{ required: true, message: 'Enter points limit' }]}
          extra={
            <Flex gap={4} wrap className="points-presets">
              {POINTS_PRESETS.map((pts) => (
                <Tag.CheckableTag
                  key={pts}
                  checked={currentPoints === pts}
                  onChange={() => form.setFieldValue('pointsLimit', pts)}
                >
                  {pts}
                </Tag.CheckableTag>
              ))}
            </Flex>
          }
        >
          <InputNumber min={500} max={20000} step={250} style={{ width: '100%' }} />
        </Form.Item>
      </Form>
    </Modal>
  );
}
