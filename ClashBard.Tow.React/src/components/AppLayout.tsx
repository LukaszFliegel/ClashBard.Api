import { Button, Layout, Typography, Spin, Alert, Tooltip } from 'antd';
import { SunOutlined, MoonOutlined } from '@ant-design/icons';
import { useCatalog } from '../contexts/CatalogContext';
import { useTheme } from '../contexts/ThemeContext';
import ArmyListPanel from './ArmyListPanel';
import CompositionPanel from './CompositionPanel';
import EditorPanel from './EditorPanel';
import ResizeDivider from './ResizeDivider';
import ValidationBar from './ValidationBar';
import './AppLayout.css';

const { Header, Content } = Layout;

export default function AppLayout() {
  const { loading, error } = useCatalog();
  const { mode, toggle } = useTheme();

  if (loading) {
    return (
      <Layout className="app-layout">
        <div className="app-loading">
          <Spin size="large" tip="Loading faction catalog…" />
        </div>
      </Layout>
    );
  }

  if (error) {
    return (
      <Layout className="app-layout">
        <div className="app-loading">
          <Alert type="error" message="Failed to load catalog" description={error} />
        </div>
      </Layout>
    );
  }

  return (
    <Layout className="app-layout">
      <Header className="app-header">
        <Typography.Title level={3} className="app-title">
          ClashBard – Army Builder
        </Typography.Title>
        <Tooltip title={mode === 'dark' ? 'Switch to light theme' : 'Switch to dark theme'}>
          <Button
            type="text"
            icon={mode === 'dark' ? <SunOutlined /> : <MoonOutlined />}
            onClick={toggle}
            className="theme-toggle"
          />
        </Tooltip>
      </Header>
      <ValidationBar />
      <Content className="app-content">
        <div className="panel panel-left">
          <ArmyListPanel />
        </div>
        <ResizeDivider />
        <div className="panel panel-center">
          <CompositionPanel />
        </div>
        <ResizeDivider />
        <div className="panel panel-right">
          <EditorPanel />
        </div>
      </Content>
    </Layout>
  );
}
