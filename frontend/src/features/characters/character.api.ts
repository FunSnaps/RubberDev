import type { Character } from './character.types';

// Mock character data
const mockCharacters: Character[] = [
  {
    id: '1',
    name: 'Cuphead',
    origin: 'Inkwell Isle',
    abilities: 'Rapid Fire, Dash',
    rarity: 3,
    imageUrl: '/images/characters/cuphead.png',
  },
  {
    id: '2',
    name: 'Mugman',
    origin: 'Inkwell Isle',
    abilities: 'Shield, Spread Shot',
    rarity: 2,
    imageUrl: '/images/characters/mugman.png',
  },
  {
    id: '3',
    name: 'Devil',
    origin: 'The Plateau',
    abilities: 'Fire Breath, Teleport',
    rarity: 5,
    imageUrl: '/images/characters/devil.png',
  },
];

// Simulate API call
export function getCharacters(): Promise<Character[]> {
  return Promise.resolve(mockCharacters);
}
