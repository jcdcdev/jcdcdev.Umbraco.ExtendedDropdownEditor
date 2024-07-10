import {UmbControllerBase} from "@umbraco-cms/backoffice/class-api";
import {UmbControllerHost} from "@umbraco-cms/backoffice/controller-api";
import {UmbDataSourceResponse} from "@umbraco-cms/backoffice/repository";
import {IExtendedDropdownEditorDataSource, ExtendedDropdownEditorDataSource} from "../datasource/extended-dropdown-editor.data-source.ts";
import {ExtendedDropdownEditorResponse} from "../api";

export class ExtendedDropdownEditorRepository extends UmbControllerBase {
    #resource: IExtendedDropdownEditorDataSource;

    constructor(host: UmbControllerHost) {
        super(host);
        this.#resource = new ExtendedDropdownEditorDataSource(host);
    }

    async getItemsByDataTypeKey(dataTypeKey: string): Promise<UmbDataSourceResponse<ExtendedDropdownEditorResponse>> {
        return await this.#resource.getItemsByDataTypeKey(dataTypeKey);
    }
}
