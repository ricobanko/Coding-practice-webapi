using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;
using TodoApi.Models;

namespace TodoApi.CustomBinders;

public class TodoItemDTOModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext) 
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var request = bindingContext.HttpContext.Request;

        foreach (var header in request.Headers)
        {
            Console.WriteLine($"Request header: {header}");
        }

        // Read the request body
        using var reader = new StreamReader(request.Body);
        var body = await reader.ReadToEndAsync();

        // Deserialize the JSON to TodoItemDTO
        var todoItemDto = JsonSerializer.Deserialize<TodoItemDTO>(body);

        // Perform custom validation or transformation if needed
        if (todoItemDto != null)
        {
            bindingContext.Result = ModelBindingResult.Success(todoItemDto);
        } else
        {
            bindingContext.Result = ModelBindingResult.Failed();
        }
    }
}
