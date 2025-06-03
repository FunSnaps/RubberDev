import type { Meta, StoryObj } from '@storybook/react';
import FilterControls from './FilterControls';

const meta: Meta<typeof FilterControls> = {
  component: FilterControls,
  title: 'Molecules/FilterControls',
  tags: ['autodocs'],
};

export default meta;
type Story = StoryObj<typeof FilterControls>;

export const Default: Story = {
  args: {
    search: '',
    onSearchChange: (value: string) => console.log('Search:', value),
  },
};
