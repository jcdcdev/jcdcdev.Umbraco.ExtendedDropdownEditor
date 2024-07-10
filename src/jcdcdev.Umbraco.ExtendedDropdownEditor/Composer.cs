using jcdcdev.Umbraco.ExtendedDropdownEditor.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor;

internal class Composer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddExtendedDropdownEditor();
    }
}
