import type { Meta, StoryObj } from '@storybook/react';
import StackGrid from './StackGrid';

const meta: Meta<typeof StackGrid> = {
  component: StackGrid,
  title: 'Molecules/StackGrid',
  tags: ['autodocs'],
};

export default meta;
type Story = StoryObj<typeof StackGrid>;

export const Default: Story = {};
