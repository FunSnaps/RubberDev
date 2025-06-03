import type { Meta, StoryObj } from '@storybook/react';
import Text from './Text';

const meta: Meta<typeof Text> = {
  component: Text,
  title: 'Atoms/Text',
  tags: ['autodocs'],
};

export default meta;

type Story = StoryObj<typeof Text>;

export const Paragraph: Story = {
  args: {
    children: 'This is a paragraph.',
    as: 'p',
    className: 'text-base',
  },
};

export const Heading: Story = {
  args: {
    children: 'Heading Level 2',
    as: 'h2',
    className: 'text-2xl font-bold',
  },
};

export const Label: Story = {
  args: {
    children: 'Name:',
    as: 'label',
    className: 'text-sm text-gray-600',
  },
};
