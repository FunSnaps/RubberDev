import type { Meta, StoryObj } from '@storybook/react';
import Image from './Image';

const meta: Meta<typeof Image> = {
  component: Image,
  title: 'Atoms/Image',
  tags: ['autodocs'],
};

export default meta;

type Story = StoryObj<typeof Image>;

export const Default: Story = {
  args: {
    src: 'https://placekitten.com/200/200',
    alt: 'Cute kitten',
    className: 'rounded-md',
  },
};
