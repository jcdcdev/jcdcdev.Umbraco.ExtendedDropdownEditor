using jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.Core;

public interface IExtendedDropdownEditorService
{
    Task<List<string>> GetItemsFromUrl(string url);
    Task<List<string>> GetItemsFromFile(string? filePath);
    Task<List<string>> GetItems(ExtendedDropdownConfiguration configuration);
}