import {UmbControllerHost} from "@umbraco-cms/backoffice/controller-api";
import {UmbDataSourceResponse} from "@umbraco-cms/backoffice/repository";
import {tryExecuteAndNotify} from "@umbraco-cms/backoffice/resources";
import {UmbContextToken} from "@umbraco-cms/backoffice/context-api";
import {
    ExtendedDropdownEditorResponse, getUmbracoExtendedDropdownEditorApiV1ItemsByDataTypeKey, GetUmbracoExtendedDropdownEditorApiV1ItemsByDataTypeKeyData
} from "../api";
import {ExtendedDropdownEditorContext} from "../context/extended-dropdown-editor.context";

export const EXTENDED_DROPDOWN_EDITOR_CONTEXT_TOKEN =
    new UmbContextToken<ExtendedDropdownEditorContext>("ExtendedDropdownEditorContext");

export interface IExtendedDropdownEditorDataSource {
    getItemsByDataTypeKey(dataTypeKey: string): Promise<UmbDataSourceResponse<ExtendedDropdownEditorResponse>>;
}

export class ExtendedDropdownEditorDataSource implements IExtendedDropdownEditorDataSource {

    #host: UmbControllerHost;

    constructor(host: UmbControllerHost) {
        this.#host = host;
    }

    async getItemsByDataTypeKey(dataTypeKey: string): Promise<UmbDataSourceResponse<ExtendedDropdownEditorResponse>> {
        const data: GetUmbracoExtendedDropdownEditorApiV1ItemsByDataTypeKeyData = {
            dataTypeKey: dataTypeKey
        };
        return await tryExecuteAndNotify(this.#host, getUmbracoExtendedDropdownEditorApiV1ItemsByDataTypeKey(data))
    }
}
