import type { Meta, StoryObj } from '@storybook/react';
import ProjectIntro from './ProjectIntro';

const meta: Meta<typeof ProjectIntro> = {
  component: ProjectIntro,
  title: 'Molecules/ProjectIntro',
  tags: ['autodocs'],
};

export default meta;
type Story = StoryObj<typeof ProjectIntro>;

export const Default: Story = {};
