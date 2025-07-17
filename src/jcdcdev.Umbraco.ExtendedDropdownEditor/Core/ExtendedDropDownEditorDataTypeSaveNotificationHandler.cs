using jcdcdev.Umbraco.ExtendedDropdownEditor.PropertyEditors;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace jcdcdev.Umbraco.ExtendedDropdownEditor.Core;

public class ExtendedDropDownEditorDataTypeSaveNotificationHandler(IExtendedDropdownEditorService service) : INotificationAsyncHandler<DataTypeSavingNotification>
{
    public async Task HandleAsync(DataTypeSavingNotification notification, CancellationToken cancellationToken)
    {
        foreach (var dataType in notification.SavedEntities)
        {
            if (dataType.EditorAlias != Constants.PropertyEditors.Aliases.ExtendedDropdownEditor)
            {
                continue;
            }

            var config = dataType.ConfigurationAs<ExtendedDropdownConfiguration>();
            if (config == null)
            {
                continue;
            }

            var items = await service.GetItems(config);
            if (dataType.ConfigurationData.ContainsKey("items"))
            {
                dataType.ConfigurationData.Remove("items");
            }

            dataType.ConfigurationData.Add("items", items);
        }
    }
}
