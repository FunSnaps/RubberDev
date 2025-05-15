import { useEffect, useState } from 'react';
import { getCharacters } from '../../features/characters/character.api';
import type { Character } from '../../features/characters/character.types';
import CharacterCard from '../molecules/CharacterCard';
import FilterControls from '../molecules/FilterControls';
import Text from '../atoms/Text';
import { useCollectionStore } from '../../stores/collectionStore';

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
