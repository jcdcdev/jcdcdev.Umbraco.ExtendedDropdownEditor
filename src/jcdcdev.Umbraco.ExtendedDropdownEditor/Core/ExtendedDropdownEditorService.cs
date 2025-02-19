using System.Net.Http.Json;
using System.Text.Json;
using jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.IO;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.Core;

public class ExtendedDropdownEditorService(
    IServer server,
    IOptions<WebRoutingSettings> options,
    HttpClient client,
    ILogger<ExtendedDropdownEditorService> logger,
    IPhysicalFileSystem fileSystem)
    : IExtendedDropdownEditorService
{
    public async Task<List<string>> GetItemsFromUrl(string url)
    {
        try
        {
            if (url.StartsWith("/"))
            {
                var baseUrl = options.Value.UmbracoApplicationUrl;
                if (baseUrl.IsNullOrWhiteSpace())
                {
                    var addresses = server.Features.Get<IServerAddressesFeature>();
                    baseUrl = addresses?.Addresses.FirstOrDefault(address => address.StartsWith("https"));
                    if (baseUrl.IsNullOrWhiteSpace())
                    {
                        throw new Exception("Could not determine base URL");
                    }
                }

                var builder = new UriBuilder(baseUrl)
                {
                    Path = url
                };
                url = builder.Uri.ToString();
            }

            var result = await client.GetFromJsonAsync<List<string>>(url) ?? [];
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting items from url {Url}", url);
            throw;
        }
    }

    public async Task<List<string>> GetItemsFromFile(string? filePath)
    {
        if (filePath.IsNullOrWhiteSpace())
        {
            logger.LogDebug("No file path specified");
            return [];
        }

        if (!fileSystem.FileExists(filePath))
        {
            logger.LogDebug("File {FilePath} does not exist", filePath);
            return [];
        }

        await using var stream = fileSystem.OpenFile(filePath);
        return await JsonSerializer.DeserializeAsync<List<string>>(stream) ?? [];
    }

    public async Task<List<string>> GetItems(ExtendedDropdownConfiguration configuration)
    {
        var items = configuration.DropdownType switch
        {
            ExtendedDropdownType.File => await GetItemsFromFile(configuration.FilePath),
            ExtendedDropdownType.Url => await GetItemsFromUrl(configuration.Url),
            _ => []
        };

        return items;
    }
}
