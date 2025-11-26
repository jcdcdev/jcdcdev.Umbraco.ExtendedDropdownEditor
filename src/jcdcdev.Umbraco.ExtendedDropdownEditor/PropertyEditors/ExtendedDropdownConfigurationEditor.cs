using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;

// Or should it be: ExtendedDropdownConfigurationConfigurationEditor? :D
internal class ExtendedDropdownConfigurationEditor(
    IIOHelper ioHelper)
    : ConfigurationEditor<ExtendedDropdownConfiguration>(ioHelper)
{
}
