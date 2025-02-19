import {defineConfig} from "vite";

export default defineConfig({
    build: {
        lib: {
            entry: ["src/index.ts"],
            formats: ["es"],
        },
        outDir: "../jcdcdev.Umbraco.ExtendedDropdownEditor/wwwroot/App_Plugins/jcdcdev.Umbraco.ExtendedDropdownEditor/dist/",
        sourcemap: true,
        rollupOptions: {
            external: [/^@umbraco/],
        },
    },
});
