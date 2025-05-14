import type { CartoonCharacter } from '../../features/characters/character.types';
import Text from '../atoms/Text.tsx';
import Image from '../atoms/Image';

type Props = {
  character: CartoonCharacter;
};

export default function CharacterCard({ character }: Props) {
  return (
    <div className="character-card">
      <Image src={character.imageUrl} alt={character.name} />
      <Text as="h2">{character.name}</Text>
      <Text>Origin: {character.origin}</Text>
      <Text>Abilities: {character.abilities}</Text>
      <Text>Rarity: {character.rarity}</Text>
    </div>
  );
}
