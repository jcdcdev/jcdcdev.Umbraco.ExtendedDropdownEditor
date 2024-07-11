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
            propertyEditorSchemaAlias: "jcdcdev.Umbraco.ExtendedDropdown",
            settings: {
                properties: [
                    {
                        alias: 'multiple',
                        label: 'Enable multiple choice',
                        propertyEditorUiAlias: 'Umb.PropertyEditorUi.Toggle',
                    },
                    {
                        alias: "file",
                        label: "File",
                        description: "Select a file from the wwwroot or App_Plugins folder",
                        propertyEditorUiAlias: "Umb.PropertyEditorUi.StaticFilePicker",
                        config: [
                            {
                                alias: 'validationLimit',
                                value: {
                                    min: 0,
                                    max: 1
                                }
                            },
                        ]
                    },
                    {
                        alias: "filePathOverride",
                        label: "File Path Override",
                        description: "Provide a path relative to the root of the web project",
                        propertyEditorUiAlias: "Umb.PropertyEditorUi.TextBox",
                    },
                    {
                        alias: "url",
                        label: "URL",
                        description: "Works with GET requests with no authentication",
                        propertyEditorUiAlias: "Umb.PropertyEditorUi.TextBox",
                    }
                ]
            }
        }
    }
export const manifests: Array<ManifestTypes> = [manifest];
