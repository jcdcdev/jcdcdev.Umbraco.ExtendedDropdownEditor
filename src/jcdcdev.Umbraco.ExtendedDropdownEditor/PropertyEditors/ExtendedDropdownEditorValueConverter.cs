using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Cms.Core.Serialization;
using jcdcdev.Umbraco.ExtendedDropdownEditor.Core;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;

public class ExtendedDropdownEditorValueConverter : FlexibleDropdownPropertyValueConverter
{
    public override bool IsConverter(IPublishedPropertyType propertyType) =>
        propertyType.EditorAlias.Equals(Constants.PropertyEditors.Aliases.ExtendedDropdownEditor);

    public ExtendedDropdownEditorValueConverter(IJsonSerializer jsonSerializer) : base(jsonSerializer)
    {
    }
}
