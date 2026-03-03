import { Empty } from 'antd';
import { useArmy } from '../contexts/ArmyContext';
import CharacterEditor from './CharacterEditor';
import UnitEditor from './UnitEditor';
import UnitPicker from './UnitPicker';

export default function EditorPanel() {
  const { state, activeArmy } = useArmy();

  if (!activeArmy) {
    return (
      <Empty
        description="Select or create an army to start building"
        style={{ marginTop: 80 }}
      />
    );
  }

  // Show the inline unit/character picker when a slot is selected
  if (state.addSlot) {
    return <UnitPicker slot={state.addSlot} />;
  }

  if (!state.selectedItemId) {
    return (
      <Empty
        description="Select a character or unit to edit"
        style={{ marginTop: 80 }}
      />
    );
  }

  if (state.selectedItemType === 'character') {
    const ch = activeArmy.characters.find((c) => c.id === state.selectedItemId);
    if (!ch) return <Empty description="Character not found" />;
    return <CharacterEditor character={ch} />;
  }

  if (state.selectedItemType === 'unit') {
    const u = activeArmy.units.find((u) => u.id === state.selectedItemId);
    if (!u) return <Empty description="Unit not found" />;
    return <UnitEditor unit={u} />;
  }

  return null;
}

