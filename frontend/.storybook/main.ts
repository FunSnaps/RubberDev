import type { StorybookConfig } from '@storybook/react-vite';

const config: StorybookConfig = {
  stories: [
    '../src/components/**/*.stories.@(ts|tsx)',
    '../src/features/**/*.stories.@(ts|tsx)',
    '../src/**/*.mdx',
  ],
  addons: [
    '@storybook/addon-essentials',
    '@storybook/addon-onboarding',
    {
      name: '@storybook/addon-docs',
      options: {
        autodocs: true,
      },
    },
  ],
  framework: {
    name: '@storybook/react-vite',
    options: {},
  },
};

export default config;
