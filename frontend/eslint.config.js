import globals from "globals";
import tseslint from "typescript-eslint";
import pluginReact from "eslint-plugin-react";
import pluginPrettier from "eslint-plugin-prettier";
import { defineConfig } from "eslint/config";

export default defineConfig([
  {
    files: ["**/*.{js,mjs,cjs,ts,tsx}"],
    languageOptions: {
      ecmaVersion: "latest",
      sourceType: "module",
      globals: globals.browser,
    },
    plugins: {
      prettier: pluginPrettier,
      react: pluginReact,
      "@typescript-eslint": tseslint,
    },
    rules: {
      ...pluginPrettier.configs.recommended.rules,
    },
  },
]);
