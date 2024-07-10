import {UMB_AUTH_CONTEXT} from "@umbraco-cms/backoffice/auth";
import {OpenAPI} from "./api";
import {UmbEntryPointOnInit} from "@umbraco-cms/backoffice/extension-api";
import {ManifestLocalizations} from "./lang/manifests.ts";
import {ExtendedDropdownEditorContext} from "./context/extended-dropdown-editor.context.ts";
import {manifests} from "./editor/manifests.ts";

export const onInit: UmbEntryPointOnInit = (_host, extensionRegistry) => {
    extensionRegistry.registerMany([...ManifestLocalizations, ...manifests]);
    _host.consumeContext(UMB_AUTH_CONTEXT, (_auth) => {
        const umbOpenApi = _auth.getOpenApiConfiguration();
        OpenAPI.TOKEN = umbOpenApi.token;
        OpenAPI.BASE = umbOpenApi.base;
        OpenAPI.WITH_CREDENTIALS = umbOpenApi.withCredentials;
        new ExtendedDropdownEditorContext(_host);
    });
};
