import {
  createContext,
  useContext,
  useEffect,
  useState,
  type ReactNode,
} from 'react';
import type { FactionCatalogDto } from '../types/catalog';
import { getFactionCatalog } from '../api/catalogApi';

interface CatalogState {
  catalog: FactionCatalogDto | null;
  loading: boolean;
  error: string | null;
  loadCatalog: (factionId: string) => void;
}

const CatalogContext = createContext<CatalogState | undefined>(undefined);

export function CatalogProvider({ children }: { children: ReactNode }) {
  const [catalog, setCatalog] = useState<FactionCatalogDto | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  function loadCatalog(factionId: string) {
    setLoading(true);
    setError(null);
    getFactionCatalog(factionId)
      .then(setCatalog)
      .catch((e) => setError(String(e)))
      .finally(() => setLoading(false));
  }

  // Auto-load dark-elves on mount
  useEffect(() => {
    loadCatalog('dark-elves');
  }, []);

  return (
    <CatalogContext.Provider value={{ catalog, loading, error, loadCatalog }}>
      {children}
    </CatalogContext.Provider>
  );
}

export function useCatalog(): CatalogState {
  const ctx = useContext(CatalogContext);
  if (!ctx) throw new Error('useCatalog must be used within CatalogProvider');
  return ctx;
}
