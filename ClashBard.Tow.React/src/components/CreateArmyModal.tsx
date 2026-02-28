import { Form, Input, InputNumber, Modal } from 'antd';
import { useArmy } from '../contexts/ArmyContext';
import { useCatalog } from '../contexts/CatalogContext';

interface Props {
  open: boolean;
  onClose: () => void;
}

export default function CreateArmyModal({ open, onClose }: Props) {
  const [form] = Form.useForm();
  const { dispatch } = useArmy();
  const { catalog } = useCatalog();

  function handleOk() {
    form.validateFields().then((values) => {
      dispatch({
        type: 'CREATE_ARMY',
        payload: {
          name: values.name,
          factionId: catalog?.factionId ?? 'dark-elves',
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
          name="name"
          label="Army Name"
          rules={[{ required: true, message: 'Enter a name' }]}
        >
          <Input placeholder="My Dark Elves" />
        </Form.Item>
        <Form.Item
          name="pointsLimit"
          label="Points Limit"
          rules={[{ required: true, message: 'Enter points limit' }]}
        >
          <InputNumber min={500} max={20000} step={250} style={{ width: '100%' }} />
        </Form.Item>
      </Form>
    </Modal>
  );
}
