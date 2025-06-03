import type { Meta, StoryObj } from '@storybook/react';
import Hero from './Hero';

const meta: Meta<typeof Hero> = {
  component: Hero,
  title: 'Molecules/Hero',
  tags: ['autodocs'],
};

export default meta;
type Story = StoryObj<typeof Hero>;

export const Default: Story = {};
