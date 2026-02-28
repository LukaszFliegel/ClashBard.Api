import { ConfigProvider, theme } from 'antd';
import { CatalogProvider } from './contexts/CatalogContext';
import { ArmyProvider } from './contexts/ArmyContext';
import { useTheme } from './contexts/ThemeContext';
import AppLayout from './components/AppLayout';

export default function App() {
  const { mode } = useTheme();

  return (
    <ConfigProvider
      theme={{
        algorithm:
          mode === 'dark' ? theme.darkAlgorithm : theme.defaultAlgorithm,
        token: {
          colorPrimary: '#722ed1',
        },
      }}
    >
      <CatalogProvider>
        <ArmyProvider>
          <AppLayout />
        </ArmyProvider>
      </CatalogProvider>
    </ConfigProvider>
  );
}
