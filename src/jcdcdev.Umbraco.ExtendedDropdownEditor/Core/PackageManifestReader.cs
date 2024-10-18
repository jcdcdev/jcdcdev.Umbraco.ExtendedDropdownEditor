using jcdcdev.Umbraco.Core.Extensions;
using jcdcdev.Umbraco.Core.Web.Models.Manifests;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.Core;

public class PackageManifestReader : IPackageManifestReader
{
    public Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync()
    {
        var extensions = new List<IManifest>();
        var packageManifest = new PackageManifest
        {
            Name = Constants.PackageName,
            Version = EnvironmentExtensions.CurrentAssemblyVersion().ToSemVer()?.ToString() ?? "0.1.0",
            AllowPublicAccess = false,
            AllowTelemetry = true,
            Extensions = []
        };

        extensions.Add(new EntryPointManifest
        {
            Name = "extended-dropdown-editor.entrypoint",
            Alias = "extended-dropdown-editor.entrypoint",
            Js = "/App_Plugins/jcdcdev.Umbraco.ExtendedDropdownEditor/dist/index.js"
        });

        packageManifest.Extensions = extensions.OfType<object>().ToArray();
        return Task.FromResult<IEnumerable<PackageManifest>>([packageManifest]);
    }
}
