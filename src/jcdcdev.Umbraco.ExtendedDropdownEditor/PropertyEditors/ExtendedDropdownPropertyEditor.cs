using jcdcdev.Umbraco.ExtendedDropdownEditor.Core;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Serialization;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;

[DataEditor(
    Constants.PropertyEditors.Aliases.ExtendedDropdownEditor,
    ValueType = ValueTypes.Text,
    ValueEditorIsReusable = true)]
public class ExtendedDropdownPropertyEditor : DropDownFlexiblePropertyEditor
{
    private readonly IIOHelper _ioHelper;


    public ExtendedDropdownPropertyEditor(
        IDataValueEditorFactory dataValueEditorFactory,
        IIOHelper ioHelper,
        IConfigurationEditorJsonSerializer configurationEditorJsonSerializer) : base(dataValueEditorFactory, ioHelper, configurationEditorJsonSerializer)
    {
        _ioHelper = ioHelper;
    }

    protected override IConfigurationEditor CreateConfigurationEditor()
    {
        var config = new ExtendedDropdownConfigurationEditor(_ioHelper);
        return config;
    }
}
