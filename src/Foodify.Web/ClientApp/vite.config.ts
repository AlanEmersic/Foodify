import react from "@vitejs/plugin-react-swc";
import { defineConfig } from "vite";
import mkcert from "vite-plugin-mkcert";
import svgrPlugin from "vite-plugin-svgr";
import viteTsconfigPaths from "vite-tsconfig-paths";

export default defineConfig({
  plugins: [react(), mkcert(), viteTsconfigPaths(), svgrPlugin()],
  build: {
    outDir: "build",
    emptyOutDir: true,
  },
  server: {
    port: 3000,
    https: true,
    proxy: {
      "/api": {
        target: "https://localhost:7024",
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
