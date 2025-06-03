import { useEffect, useState } from 'react';
import { getCharacters } from '../../../features/characters/character.api.ts';
import type { Character } from '../../../features/characters/character.types.ts';
import CharacterCard from '../../molecules/CharacterCard/CharacterCard.tsx';
import FilterControls from '../../molecules/FilterControls/FilterControls.tsx';
import Text from '../../atoms/Text/Text.tsx';
import { useCollectionStore } from '../../../stores/collectionStore.ts';

export default function GamePage() {
  const [characters, setCharacters] = useState<Character[]>([]);
  const [search, setSearch] = useState('');
  const collected = useCollectionStore((s) => s.collected);

  useEffect(() => {
    getCharacters().then(setCharacters);
  }, []);

  const filtered = characters.filter((c) =>
    c.name.toLowerCase().includes(search.toLowerCase()),
  );

  return (
    <div className="game-page">
      <Text as="h1">🎮 Character Collector</Text>
      <FilterControls search={search} onSearchChange={setSearch} />
      <div className="character-grid">
        {filtered.map((char) => (
          <CharacterCard key={char.id} character={char} />
        ))}
      </div>

      {collected.length > 0 && (
        <section className="my-collection">
          <Text as="h2">🏆 My Collection</Text>
          <div className="character-grid">
            {collected.map((c) => (
              <CharacterCard key={c.id} character={c} />
            ))}
          </div>
        </section>
      )}
    </div>
  );
}
