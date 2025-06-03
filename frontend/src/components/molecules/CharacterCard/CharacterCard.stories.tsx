import type { Meta, StoryObj } from '@storybook/react';
import CharacterCard from './CharacterCard';
import type { Character } from '../../../features/characters/character.types';

const meta: Meta<typeof CharacterCard> = {
  component: CharacterCard,
  title: 'Molecules/CharacterCard',
  tags: ['autodocs'],
};

export default meta;
type Story = StoryObj<typeof CharacterCard>;

const mockCharacter: Character = {
  id: '1',
  name: 'CupKid',
  origin: 'ToonTown',
  abilities: 'Bouncing, Zapping',
  rarity: 3,
  imageUrl: 'https://placekitten.com/200/200',
};

export const Default: Story = {
  args: {
    character: mockCharacter,
  },
};
