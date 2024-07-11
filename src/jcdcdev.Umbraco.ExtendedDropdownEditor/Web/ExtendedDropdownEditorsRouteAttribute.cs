using Umbraco.Cms.Web.Common.Routing;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.Web;

public class ExtendedDropdownEditorsRouteAttribute(string template) : BackOfficeRouteAttribute($"ExtendedDropdownEditor/api/v{{version:apiVersion}}/{template.TrimStart('/')}");
