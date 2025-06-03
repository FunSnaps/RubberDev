import type { Meta, StoryObj } from '@storybook/react';
import ProfilePage from './ProfilePage';

const meta: Meta<typeof ProfilePage> = {
  component: ProfilePage,
  title: 'Pages/ProfilePage',
  tags: ['autodocs'],
  parameters: {
    layout: 'fullscreen',
  },
};

export default meta;
type Story = StoryObj<typeof ProfilePage>;

export const Default: Story = {};
