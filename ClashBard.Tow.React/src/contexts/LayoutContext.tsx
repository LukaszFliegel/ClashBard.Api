import {
  createContext,
  useContext,
  useEffect,
  useState,
  type ReactNode,
} from 'react';

const STORAGE_KEY = 'clashbard_layout';

export interface LayoutState {
  leftPanelPercent: number;
  rightPanelPercent: number;
}

const DEFAULTS: LayoutState = {
  leftPanelPercent: 18,
  rightPanelPercent: 32,
};

function loadLayout(): LayoutState {
  try {
    const raw = localStorage.getItem(STORAGE_KEY);
    if (!raw) return DEFAULTS;
    const parsed = JSON.parse(raw) as Partial<LayoutState>;
    return {
      leftPanelPercent: parsed.leftPanelPercent ?? DEFAULTS.leftPanelPercent,
      rightPanelPercent: parsed.rightPanelPercent ?? DEFAULTS.rightPanelPercent,
    };
  } catch {
    return DEFAULTS;
  }
}

interface LayoutContextValue {
  layout: LayoutState;
  setLayout: (next: LayoutState) => void;
}

const LayoutContext = createContext<LayoutContextValue | undefined>(undefined);

export function LayoutProvider({ children }: { children: ReactNode }) {
  const [layout, setLayoutState] = useState<LayoutState>(loadLayout);

  useEffect(() => {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(layout));
  }, [layout]);

  function setLayout(next: LayoutState) {
    setLayoutState(next);
  }

  return (
    <LayoutContext.Provider value={{ layout, setLayout }}>
      {children}
    </LayoutContext.Provider>
  );
}

export function useLayout(): LayoutContextValue {
  const ctx = useContext(LayoutContext);
  if (!ctx) throw new Error('useLayout must be used within LayoutProvider');
  return ctx;
}
