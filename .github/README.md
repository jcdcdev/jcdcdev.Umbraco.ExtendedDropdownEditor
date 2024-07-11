# jcdcdev.Umbraco.ExtendedDropdownEditor

[![Umbraco Marketplace](https://img.shields.io/badge/Umbraco-Marketplace-%233544B1?style=flat&logo=umbraco)](https://marketplace.umbraco.com/package/jcdcdev.Umbraco.ExtendedDropdownEditor)
[![GitHub License](https://img.shields.io/github/license/jcdcdev/jcdcdev.Umbraco.ExtendedDropdownEditor?color=8AB803&label=License&logo=github)](https://github.com/jcdcdev/jcdcdev.Umbraco.ExtendedDropdownEditor/blob/v14/LICENSE)
[![NuGet Downloads](https://img.shields.io/nuget/dt/jcdcdev.Umbraco.ExtendedDropdownEditor?color=cc9900&label=Downloads&logo=nuget)](https://www.nuget.org/packages/jcdcdev.Umbraco.ExtendedDropdownEditor/)
[![Project Website](https://img.shields.io/badge/Project%20Website-jcdc.dev-jcdcdev?style=flat&color=3c4834&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxNiIgaGVpZ2h0PSIxNiIgZmlsbD0id2hpdGUiIGNsYXNzPSJiaSBiaS1wYy1kaXNwbGF5IiB2aWV3Qm94PSIwIDAgMTYgMTYiPgogIDxwYXRoIGQ9Ik04IDFhMSAxIDAgMCAxIDEtMWg2YTEgMSAwIDAgMSAxIDF2MTRhMSAxIDAgMCAxLTEgMUg5YTEgMSAwIDAgMS0xLTF6bTEgMTMuNWEuNS41IDAgMSAwIDEgMCAuNS41IDAgMCAwLTEgMG0yIDBhLjUuNSAwIDEgMCAxIDAgLjUuNSAwIDAgMC0xIDBNOS41IDFhLjUuNSAwIDAgMCAwIDFoNWEuNS41IDAgMCAwIDAtMXpNOSAzLjVhLjUuNSAwIDAgMCAuNS41aDVhLjUuNSAwIDAgMCAwLTFoLTVhLjUuNSAwIDAgMC0uNS41TTEuNSAyQTEuNSAxLjUgMCAwIDAgMCAzLjV2N0ExLjUgMS41IDAgMCAwIDEuNSAxMkg2djJoLS41YS41LjUgMCAwIDAgMCAxSDd2LTRIMS41YS41LjUgMCAwIDEtLjUtLjV2LTdhLjUuNSAwIDAgMSAuNS0uNUg3VjJ6Ii8+Cjwvc3ZnPg==)](https://jcdc.dev/umbraco-packages/extended-dropdown-editor)

A custom dropdown property editor for Umbraco that supports dynamic data sources.

## Data Sources

#### File Picker

Select any file in the `wwwroot` or `App_Plugins` directory

#### Examples

`wwwroot/data.json`
`App_Plugins/data.json

> [!WARNING]
> Please note that any files in these directories are publicly accessible via URL!

#### File Path Override

Specify a custom path to a file (relative to the root of the web project)

#### Examples

- `/umbraco/Data/MyDataSource.json`
- `/usync/v14/DataSources/countries.json`

> [!NOTE]
> This allows you to configure a path that is not publicly accessible via URL

#### URL

Specify a URL that returns a JSON response

- Supports GET requests with optional query string parameters
- Supports local and external URLs
- Does not support authentication (yet 👀)

#### Examples

- `/myapi/mydata?format=json`
- `https://array-3yn8gu6xn98t.runkit.sh/`

## Data Format

Currently, the data source must return an array of strings.

```json
[
  "Item 1",
  "Item 2",
  "Item 3"
]
```

> [!NOTE]
> In the future I plan to add JSONPath support to allow for more complex data structures 🤓

## Quick Start

### Install Package

```csharp
dotnet add package jcdcdev.Umbraco.ExtendedDropdownEditor 
```

### Create Data Type

- Go to the `Settings` section in the Umbraco backoffice 
- Create a new `Data Type` using the `Extended Dropdown` editor.
- Select your data source (File Picker, File Path Override, or URL).
- Save the data type.

Now you are ready to use the data type in your content types!

## Contributing

Contributions to this package are most welcome! Please read
the [Contributing Guidelines](https://github.com/jcdcdev/jcdcdev.Umbraco.ExtendedDropdownEditor/blob/v14/.github/CONTRIBUTING.md).

## Acknowledgments (thanks!)

- LottePitcher - [opinionated-package-starter](https://github.com/LottePitcher/opinionated-package-starter)