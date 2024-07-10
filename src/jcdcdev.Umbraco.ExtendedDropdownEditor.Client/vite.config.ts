import {defineConfig} from "vite";

export default defineConfig({
    build: {
        lib: {
            entry: ["src/index.ts", "src/editor/extended-dropdown-editor.ts"],
            formats: ["es"],
        },
        outDir: "../jcdcdev.Umbraco.ExtendedDropdownEditor/wwwroot/App_Plugins/jcdcdev.Umbraco.ExtendedDropdownEditor/dist/",
        sourcemap: true,
        rollupOptions: {
            external: [/^@umbraco/],
        },
    },
});
