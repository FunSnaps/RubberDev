import type { Character } from '../../../features/characters/character.types.ts';
import Text from '../../atoms/Text/Text.tsx';
import Image from '../../atoms/Image/Image.tsx';
import { useCollectionStore } from '../../../stores/collectionStore.ts';

type Props = {
  character: Character;
};

export default function CharacterCard({ character }: Props) {
  const add = useCollectionStore((state) => state.add);
  return (
    <div className="character-card">
      <Image src={character.imageUrl} alt={character.name} />
      <Text as="h2">{character.name}</Text>
      <Text>Origin: {character.origin}</Text>
      <Text>Abilities: {character.abilities}</Text>
      <Text>Rarity: {character.rarity}</Text>
      <button onClick={() => add(character)}>Collect</button>
    </div>
  );
}
