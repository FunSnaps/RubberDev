import type { Meta, StoryObj } from '@storybook/react';
import Button from './Button.tsx';

const meta: Meta<typeof Button> = {
  component: Button,
  title: 'Atoms/Button',
  tags: ['autodocs'],
};

export default meta;

type Story = StoryObj<typeof Button>;

export const Danger: Story = {
  args: {
    children: 'Delete',
    variant: 'danger',
  },
};

export const Primary: Story = {
  args: {
    children: 'Click Me',
    variant: 'primary',
  },
};
