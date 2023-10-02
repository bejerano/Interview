import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path';
import inject from '@rollup/plugin-inject';
import tailwindcss from 'tailwindcss';
 

export default defineConfig({
  resolve: {
    alias: [
      {
        find: /@\//,
        replacement: path.resolve('./src/') + '/',
      },
    ],
  },
  plugins: [
    
    inject({  
      include: '**/*.js',
      exclude: 'node_modules/**',    
      $: 'jquery',
      jQuery: 'jquery',
         }),
    react(),
   
  ], 
  esbuild: {
    supported: {
      'top-level-await': true
    },
  },
  build: {
    commonjsOptions: {
      include: [/linked-dep/, /node_modules/]
    },
    assetsInlineLimit: 2048,
    rollupOptions: {      
      output: {
          manualChunks(id) {
          if (id.includes(id.includes('node_modules/jquery/') || id.includes('src/jquery-global.js'))) 
          {
            return 'jquery';
          }

          if (id.includes('node_modules')) {
            return id.toString().split('node_modules/')[1].split('/')[0].toString();
          }
        },
      },
    },
  },
  define: {
     },
});