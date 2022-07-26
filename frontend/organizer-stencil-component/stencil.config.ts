import { Config } from '@stencil/core';
import { reactOutputTarget } from '@stencil/react-output-target';

export const config: Config = {
  namespace: 'audit-unit-card',
  srcDir: 'src',
  bundles: [{ components: ['audit-unit-card', 'audit-unit-properties'] }],
  enableCache: false,
  nodeResolve: {
    browser: true,
  },
  outputTargets: [
    // reactOutputTarget({
    //   componentCorePackage: 'react-component-library',
    //   proxiesFile: '../../au-mfe/src/react-component-library/src/components.ts',
    //   includeDefineCustomElements: true,
    // }),
    {
      type: 'dist',
      esmLoaderPath: '../loader',
      empty: true,
    },
    {
      type: 'www',
      serviceWorker: null, // disable service workers
    },
    {
      type: 'dist-custom-elements-bundle',
      empty: true,
    },
  ],
};
