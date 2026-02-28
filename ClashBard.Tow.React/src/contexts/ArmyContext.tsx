import {
  createContext,
  useCallback,
  useContext,
  useEffect,
  useReducer,
  type ReactNode,
} from 'react';
import { v4 as uuidv4 } from 'uuid';
import type {
  ArmyCharacterConfigDto,
  ArmyUnitConfigDto,
  ArmyValidationResponseDto,
  StoredArmy,
} from '../types/army';
import { validateArmy } from '../api/catalogApi';

/* ─── helpers ──────────────────────────────────────── */

const STORAGE_KEY = 'clashbard_armies';

function loadArmies(): StoredArmy[] {
  try {
    const raw = localStorage.getItem(STORAGE_KEY);
    return raw ? (JSON.parse(raw) as StoredArmy[]) : [];
  } catch {
    return [];
  }
}

function saveArmies(armies: StoredArmy[]) {
  localStorage.setItem(STORAGE_KEY, JSON.stringify(armies));
}

/* ─── state ────────────────────────────────────────── */

export interface ArmyState {
  armies: StoredArmy[];
  activeArmyId: string | null;
  selectedItemId: string | null;
  selectedItemType: 'character' | 'unit' | null;
  validation: ArmyValidationResponseDto | null;
  validating: boolean;
}

const initialState: ArmyState = {
  armies: loadArmies(),
  activeArmyId: null,
  selectedItemId: null,
  selectedItemType: null,
  validation: null,
  validating: false,
};

/* ─── actions ──────────────────────────────────────── */

type Action =
  | { type: 'CREATE_ARMY'; payload: { name: string; factionId: string; pointsLimit: number } }
  | { type: 'DELETE_ARMY'; payload: string }
  | { type: 'SET_ACTIVE_ARMY'; payload: string | null }
  | { type: 'SELECT_ITEM'; payload: { id: string; itemType: 'character' | 'unit' } | null }
  | { type: 'UPDATE_ARMY_NAME'; payload: { armyId: string; name: string } }
  | { type: 'UPDATE_POINTS_LIMIT'; payload: { armyId: string; pointsLimit: number } }
  | { type: 'SET_GENERAL'; payload: { armyId: string; characterId: string | null } }
  | { type: 'SET_BSB'; payload: { armyId: string; characterId: string | null } }
  | { type: 'ADD_CHARACTER'; payload: { armyId: string; character: ArmyCharacterConfigDto } }
  | { type: 'UPDATE_CHARACTER'; payload: { armyId: string; character: ArmyCharacterConfigDto } }
  | { type: 'REMOVE_CHARACTER'; payload: { armyId: string; characterId: string } }
  | { type: 'ADD_UNIT'; payload: { armyId: string; unit: ArmyUnitConfigDto } }
  | { type: 'UPDATE_UNIT'; payload: { armyId: string; unit: ArmyUnitConfigDto } }
  | { type: 'REMOVE_UNIT'; payload: { armyId: string; unitId: string } }
  | { type: 'SET_VALIDATION'; payload: ArmyValidationResponseDto | null }
  | { type: 'SET_VALIDATING'; payload: boolean };

function reducer(state: ArmyState, action: Action): ArmyState {
  switch (action.type) {
    case 'CREATE_ARMY': {
      const now = new Date().toISOString();
      const army: StoredArmy = {
        id: uuidv4(),
        name: action.payload.name,
        factionId: action.payload.factionId,
        pointsLimit: action.payload.pointsLimit,
        generalId: null,
        bsbId: null,
        characters: [],
        units: [],
        createdAt: now,
        updatedAt: now,
      };
      const armies = [...state.armies, army];
      saveArmies(armies);
      return { ...state, armies, activeArmyId: army.id, validation: null };
    }

    case 'DELETE_ARMY': {
      const armies = state.armies.filter((a) => a.id !== action.payload);
      saveArmies(armies);
      return {
        ...state,
        armies,
        activeArmyId: state.activeArmyId === action.payload ? null : state.activeArmyId,
        selectedItemId: null,
        selectedItemType: null,
        validation: null,
      };
    }

    case 'SET_ACTIVE_ARMY':
      return {
        ...state,
        activeArmyId: action.payload,
        selectedItemId: null,
        selectedItemType: null,
        validation: null,
      };

    case 'SELECT_ITEM':
      return {
        ...state,
        selectedItemId: action.payload?.id ?? null,
        selectedItemType: action.payload?.itemType ?? null,
      };

    case 'UPDATE_ARMY_NAME':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        name: action.payload.name,
      }));

    case 'UPDATE_POINTS_LIMIT':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        pointsLimit: action.payload.pointsLimit,
      }));

    case 'SET_GENERAL':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        generalId: action.payload.characterId,
      }));

    case 'SET_BSB':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        bsbId: action.payload.characterId,
      }));

    case 'ADD_CHARACTER':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        characters: [...a.characters, action.payload.character],
      }));

    case 'UPDATE_CHARACTER':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        characters: a.characters.map((c) =>
          c.id === action.payload.character.id ? action.payload.character : c,
        ),
      }));

    case 'REMOVE_CHARACTER':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        characters: a.characters.filter((c) => c.id !== action.payload.characterId),
        generalId: a.generalId === action.payload.characterId ? null : a.generalId,
        bsbId: a.bsbId === action.payload.characterId ? null : a.bsbId,
      }));

    case 'ADD_UNIT':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        units: [...a.units, action.payload.unit],
      }));

    case 'UPDATE_UNIT':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        units: a.units.map((u) =>
          u.id === action.payload.unit.id ? action.payload.unit : u,
        ),
      }));

    case 'REMOVE_UNIT':
      return updateArmy(state, action.payload.armyId, (a) => ({
        ...a,
        units: a.units.filter((u) => u.id !== action.payload.unitId),
      }));

    case 'SET_VALIDATION':
      return { ...state, validation: action.payload, validating: false };

    case 'SET_VALIDATING':
      return { ...state, validating: action.payload };

    default:
      return state;
  }
}

function updateArmy(
  state: ArmyState,
  armyId: string,
  updater: (a: StoredArmy) => StoredArmy,
): ArmyState {
  const armies = state.armies.map((a) => {
    if (a.id !== armyId) return a;
    return { ...updater(a), updatedAt: new Date().toISOString() };
  });
  saveArmies(armies);
  return { ...state, armies, validation: null };
}

/* ─── context ──────────────────────────────────────── */

interface ArmyContextValue {
  state: ArmyState;
  dispatch: React.Dispatch<Action>;
  activeArmy: StoredArmy | null;
  requestValidation: () => void;
}

const ArmyContext = createContext<ArmyContextValue | undefined>(undefined);

export function ArmyProvider({ children }: { children: ReactNode }) {
  const [state, dispatch] = useReducer(reducer, initialState);

  const activeArmy =
    state.armies.find((a) => a.id === state.activeArmyId) ?? null;

  const requestValidation = useCallback(() => {
    if (!activeArmy) return;
    dispatch({ type: 'SET_VALIDATING', payload: true });
    validateArmy({
      factionId: activeArmy.factionId,
      pointsLimit: activeArmy.pointsLimit,
      generalId: activeArmy.generalId,
      bsbId: activeArmy.bsbId,
      characters: activeArmy.characters,
      units: activeArmy.units,
    })
      .then((v) => dispatch({ type: 'SET_VALIDATION', payload: v }))
      .catch(() => dispatch({ type: 'SET_VALIDATING', payload: false }));
  }, [activeArmy]);

  // Auto-validate when army changes
  useEffect(() => {
    if (!activeArmy) return;
    if (activeArmy.characters.length === 0 && activeArmy.units.length === 0) {
      dispatch({ type: 'SET_VALIDATION', payload: null });
      return;
    }
    const timeout = setTimeout(requestValidation, 600);
    return () => clearTimeout(timeout);
  }, [activeArmy?.updatedAt, requestValidation]);

  return (
    <ArmyContext.Provider
      value={{ state, dispatch, activeArmy, requestValidation }}
    >
      {children}
    </ArmyContext.Provider>
  );
}

export function useArmy(): ArmyContextValue {
  const ctx = useContext(ArmyContext);
  if (!ctx) throw new Error('useArmy must be used within ArmyProvider');
  return ctx;
}
