using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApi.Models;

namespace TodoApi.CustomBinders;

public class TodoItemDTOModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType == typeof(TodoItemDTO))
        {
            return new TodoItemDTOModelBinder();
        }

        return null;
    }
}
