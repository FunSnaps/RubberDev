import type { Meta, StoryObj } from '@storybook/react';
import Contact from './Contact';

const meta: Meta<typeof Contact> = {
  component: Contact,
  title: 'Molecules/Contact',
  tags: ['autodocs'],
};

export default meta;
type Story = StoryObj<typeof Contact>;

export const Default: Story = {};
