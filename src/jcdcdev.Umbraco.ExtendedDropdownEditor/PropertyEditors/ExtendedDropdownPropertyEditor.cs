using System.ComponentModel.DataAnnotations;
using jcdcdev.Umbraco.ExtendedDropdownEditor.Core;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Validation;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.Validators;
using Umbraco.Cms.Core.Serialization;
using Umbraco.Cms.Core.Strings;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;

[DataEditor(
    Constants.PropertyEditors.Aliases.ExtendedDropdownEditor,
    ValueType = ValueTypes.Text,
    ValueEditorIsReusable = true)]
public class ExtendedDropdownPropertyEditor(
    IDataValueEditorFactory dataValueEditorFactory,
    IIOHelper ioHelper,
    IConfigurationEditorJsonSerializer configurationEditorJsonSerializer)
    : DropDownFlexiblePropertyEditor(dataValueEditorFactory, ioHelper, configurationEditorJsonSerializer)
{
    private readonly IIOHelper _ioHelper = ioHelper;

    protected override IConfigurationEditor CreateConfigurationEditor()
    {
        var config = new ExtendedDropdownConfigurationEditor(_ioHelper);
        return config;
    }
}
