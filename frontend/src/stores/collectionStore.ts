import { create } from 'zustand';
import type { Character } from '../features/characters/character.types';

interface CollectionState {
  collected: Character[];
  add: (char: Character) => void;
}

export const useCollectionStore = create<CollectionState>((set) => ({
  collected: [],
  add: (char) =>
    set((state) => ({
      collected: state.collected.find((c) => c.id === char.id)
        ? state.collected
        : [...state.collected, char],
    })),
}));
