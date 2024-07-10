import {ExtendedDropdownEditorRepository} from "../repository/extended-dropdown-editor.repository";
import {UmbControllerHost} from "@umbraco-cms/backoffice/controller-api";
import {UmbContextToken} from "@umbraco-cms/backoffice/context-api";
import {UmbControllerBase} from "@umbraco-cms/backoffice/class-api";
import {ExtendedDropdownEditorResponse} from "../api";
import {UmbDataSourceResponse} from "@umbraco-cms/backoffice/repository";

export const EXTENDED_MARKDOWN_EDITOR_CONTEXT_TOKEN =
    new UmbContextToken<ExtendedDropdownEditorContext>("ExtendedDropdownEditorContext");

export class ExtendedDropdownEditorContext extends UmbControllerBase {
    #repository: ExtendedDropdownEditorRepository;

    constructor(host: UmbControllerHost) {
        super(host);
        this.provideContext(EXTENDED_MARKDOWN_EDITOR_CONTEXT_TOKEN, this);
        this.#repository = new ExtendedDropdownEditorRepository(this);
    }

    async getItemsByDataTypeKey(dataTypeKey: string): Promise<UmbDataSourceResponse<ExtendedDropdownEditorResponse>> {
        return await this.#repository.getItemsByDataTypeKey(dataTypeKey);
    }
}
