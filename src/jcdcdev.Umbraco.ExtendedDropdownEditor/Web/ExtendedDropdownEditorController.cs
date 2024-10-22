using System.Net.Http.Json;
using System.Text.Json;
using jcdcdev.Umbraco.ExtendedDropdownEditor.Core;
using jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;
using jcdcdev.Umbraco.ExtendedDropdownEditor.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Api.Common.Filters;
using Umbraco.Cms.Api.Management.Filters;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.Web;

[ApiExplorerSettings(GroupName = "Extended Dropdown Editor")]
[ExtendedDropdownEditorsRoute("")]
[MapToApi(Constants.Api.ApiName)]
[JsonOptionsName(global::Umbraco.Cms.Core.Constants.JsonOptionsNames.BackOffice)]
[ApiController]
[Authorize(Policy = AuthorizationPolicies.BackOfficeAccess)]
[AppendEventMessages]
[Produces("application/json")]
public class ExtendedDropdownEditorController(
    IDataTypeService dataTypeService,
    IPhysicalFileSystem fileSystem,
    HttpClient client,
    ILogger<ExtendedDropdownEditorController> logger) : ControllerBase
{
    [HttpGet("items/{dataTypeKey:guid}")]
    [Produces<ExtendedDropdownEditorResponse>]
    public async Task<IActionResult> Items(Guid dataTypeKey)
    {
        var dataType = await dataTypeService.GetAsync(dataTypeKey);
        if (dataType == null)
        {
            return NotFound();
        }

        try
        {
            var model = await GetItems(dataType);
            return Ok(model);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting items for data type {DataTypeKey}", dataTypeKey);
            return BadRequest(ex.Message);
        }
    }

    private async Task<ExtendedDropdownEditorResponse> GetItems(IDataType dataType)
    {
        var model = new ExtendedDropdownEditorResponse
        {
            DataTypeKey = dataType.Key
        };

        var configuration = dataType.ConfigurationAs<ExtendedDropdownConfiguration>();
        if (configuration == null)
        {
            logger.LogWarning("No configuration found for data type {DataTypeKey}", dataType.Key);
            return model;
        }

        var items = configuration.DropdownType switch
        {
            ExtendedDropdownType.File => await GetItemsFromFile(configuration.FilePath),
            ExtendedDropdownType.Url => await GetItemsFromUrl(configuration.Url),
            _ => []
        };

        model.Items = items;
        return model;
    }

    private async Task<List<string>> GetItemsFromUrl(string url)
    {
        try
        {
            if (url.StartsWith("/"))
            {
                var settings = HttpContext.RequestServices.GetRequiredService<IOptions<WebRoutingSettings>>();
                var uri = HttpContext.Request.GetApplicationUri(settings.Value);
                var builder = new UriBuilder(uri)
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

    private async Task<List<string>> GetItemsFromFile(string? filePath)
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
}
