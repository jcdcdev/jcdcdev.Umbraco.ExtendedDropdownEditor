using System.Text.Json.Serialization;
using System.Web;
using jcdcdev.Umbraco.ExtendedDropdownEditor.Core;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;

public class ExtendedDropdownConfiguration : DropDownFlexibleConfiguration
{
    [ConfigurationField("file")]
    [JsonPropertyName("file")]
    public List<string> File { get; set; } = [];

    [ConfigurationField("filePathOverride")]
    [JsonPropertyName("filePathOverride")]
    public string FilePathOverride { get; set; }

    [ConfigurationField("url")]
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonIgnore] public ExtendedDropdownType DropdownType => GetDropdownType();
    [JsonIgnore] public string? FilePath => HttpUtility.UrlDecode(FilePathOverride.IfNullOrWhiteSpace(File.FirstOrDefault()))?.Replace("%dot%", ".");

    private ExtendedDropdownType GetDropdownType()
    {
        if (!FilePath.IsNullOrWhiteSpace())
        {
            return ExtendedDropdownType.File;
        }

        if (!Url.IsNullOrWhiteSpace())
        {
            return ExtendedDropdownType.Url;
        }

        return ExtendedDropdownType.Unknown;
    }
}
