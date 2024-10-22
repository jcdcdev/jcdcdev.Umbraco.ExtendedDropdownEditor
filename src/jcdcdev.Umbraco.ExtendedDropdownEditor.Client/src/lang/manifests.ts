export const ManifestLocalizations: Array<UmbExtensionManifest> = [
    {
        type: 'localization',
        alias: 'ExtendedDropdownEditor.lang.enus',
        name: 'English (US)',
        weight: 0,
        // @ts-ignore
        meta: {
            culture: 'en-us'
        },
        js: () => import('./en-us')
    },
    {
        type: 'localization',
        alias: 'ExtendedDropdownEditor.lang.engb',
        name: 'English (UK)',
        weight: 0,
        // @ts-ignore
        meta: {
            culture: 'en-gb'
        },
        js: () => import('./en-us')
    },
]
