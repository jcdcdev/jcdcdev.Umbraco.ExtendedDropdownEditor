using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Infrastructure.Manifest;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.Core;

public static class UmbracoBuilderExtensions
{
    public static void AddExtendedDropdownEditor(this IUmbracoBuilder builder)
    {
        builder.AddNotificationAsyncHandler<DataTypeSavingNotification, ExtendedDropDownEditorDataTypeSaveNotificationHandler>();
        builder.Services.AddSingleton<IPackageManifestReader, PackageManifestReader>();
        builder.Services.AddSingleton<IExtendedDropdownEditorService, ExtendedDropdownEditorService>();
    }
}
