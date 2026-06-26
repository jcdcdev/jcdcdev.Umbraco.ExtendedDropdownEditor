import {UmbEntryPointOnInit} from "@umbraco-cms/backoffice/extension-api";
import {ManifestLocalizations} from "./lang/manifests.ts";
import {manifest} from "./editor/manifests.ts";

export const onInit: UmbEntryPointOnInit = (_host, extensionRegistry) => {
    extensionRegistry.byAlias("Umb.PropertyEditorUi.Dropdown").subscribe(dropdownmanfiest => {
        // @ts-ignore
        manifest.element = dropdownmanfiest.element;
        extensionRegistry.registerMany([...ManifestLocalizations, manifest]);
    });
};
