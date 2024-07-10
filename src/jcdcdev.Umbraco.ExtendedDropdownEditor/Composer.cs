using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using jcdcdev.Umbraco.ExtendedDropdownEditor.Core;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor;

internal class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddExtendedDropdownEditor();
    }
}
