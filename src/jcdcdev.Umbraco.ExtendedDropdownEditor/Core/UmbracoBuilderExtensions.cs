using jcdcdev.Umbraco.ExtendedDropdownEditor.Web;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Infrastructure.Manifest;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.Core;

public static class UmbracoBuilderExtensions
{
    public static void AddExtendedDropdownEditor(this IUmbracoBuilder builder)
    {
        builder.Services.ConfigureOptions<ConfigApiSwaggerGenOptions>();
        builder.Services.AddSingleton<IPackageManifestReader, PackageManifestReader>();
    }
}
