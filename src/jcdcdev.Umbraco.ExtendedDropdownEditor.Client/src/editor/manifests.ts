import {ManifestPropertyEditorUi, ManifestTypes} from "@umbraco-cms/backoffice/extension-registry";

const manifest: ManifestPropertyEditorUi =
    {
        type: "propertyEditorUi",
        alias: "jcdcdev.Umbraco.PropertyEditorUi.ExtendedDropdown",
        name: "Extended Dropdown Editor",
        element: () => import("./extended-dropdown-editor.ts"),
        meta: {
            label: "Extended Dropdown",
            icon: "icon-list",
            group: "pickers",
            propertyEditorSchemaAlias: "jcdcdev.Umbraco.ExtendedDropdownEditor",
            settings: {
                properties: [
                    {
                        alias: 'multiple',
                        label: 'Enable multiple choice',
                        propertyEditorUiAlias: 'Umb.PropertyEditorUi.Toggle',
                    },
                    {
                        alias: "file",
                        label: "JSON File",
                        propertyEditorUiAlias: "Umb.PropertyEditorUi.StaticFilePicker",
                    },
                    {
                        alias: "filePathOverride",
                        label: "File Path Override",
                        propertyEditorUiAlias: "Umb.PropertyEditorUi.TextBox",
                    },
                    {
                        alias: "url",
                        label: "URL",
                        propertyEditorUiAlias: "Umb.PropertyEditorUi.TextBox",
                    }
                ]
            }
        }
    }
export const manifests: Array<ManifestTypes> = [manifest];
