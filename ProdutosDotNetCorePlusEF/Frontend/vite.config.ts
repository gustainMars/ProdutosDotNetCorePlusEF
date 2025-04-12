import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vite.dev/config/
export default defineConfig({
  base: '/ProdutosDotNetCorePlusEF/',
  plugins: [vue()],
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5017',
        changeOrigin: true,
        secure: false
      },
    },
  },
})

