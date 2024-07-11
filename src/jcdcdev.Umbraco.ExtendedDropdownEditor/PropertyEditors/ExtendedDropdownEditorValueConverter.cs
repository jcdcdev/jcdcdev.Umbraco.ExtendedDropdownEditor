using jcdcdev.Umbraco.ExtendedDropdownEditor.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using Umbraco.Cms.Core.Serialization;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;

public class ExtendedDropdownEditorValueConverter : FlexibleDropdownPropertyValueConverter
{
    public ExtendedDropdownEditorValueConverter(IJsonSerializer jsonSerializer) : base(jsonSerializer)
    {
    }

    public override bool IsConverter(IPublishedPropertyType propertyType) =>
        propertyType.EditorAlias.Equals(Constants.PropertyEditors.Aliases.ExtendedDropdownEditor);
}
