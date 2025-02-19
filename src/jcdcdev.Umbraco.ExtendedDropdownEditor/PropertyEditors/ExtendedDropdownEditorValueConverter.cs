using jcdcdev.Umbraco.ExtendedDropdownEditor.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Cms.Core.Serialization;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;

public class ExtendedDropdownEditorValueConverter(IJsonSerializer jsonSerializer)
    : FlexibleDropdownPropertyValueConverter(jsonSerializer)
{
    public override bool IsConverter(IPublishedPropertyType propertyType) =>
        propertyType.EditorAlias.Equals(Constants.PropertyEditors.Aliases.ExtendedDropdownEditor);
}
