using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Services;

public class ToDoItemService : IToDoService
{
    TodoContext _context;
    public ToDoItemService(TodoContext context)
    {
        _context = context;
    }

    public async Task<bool> DeleteTodoItem(long id)
    {
        var TodoItemToDelete = await _context.TodoItems.FindAsync(id);

        if (TodoItemToDelete != null)
        {
            _context.TodoItems.Remove(TodoItemToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<IEnumerable<TodoItemDTO>> GetTodoItems()
    {
        return await _context.TodoItems
            .Select(x => ItemToDTO(x)).ToListAsync();
    }

    public async Task<TodoItemDTO?> GetTodoItemDTO(long id)
    {
        var todoItem = await GetItem(id);

        if (todoItem == null)
        {
            return null;
        }

        return ItemToDTO(todoItem);
    }

    public async Task<TodoItemDTO> PostTodoItemDTO(TodoItemDTO todoItemDTO)
    {
        var todoItem = new TodoItem
        {
            Name = todoItemDTO.Name,
            IsComplete = todoItemDTO.IsComplete
        };

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return ItemToDTO(todoItem);
    }

    public async Task<TodoItemDTO> PutTodoItemDTO(long id, TodoItemDTO TodoItemDTO)
    {
        var todoItem = await GetItem(id);

        if (todoItem is null)
        {
            return null;
        }

        todoItem.Name = TodoItemDTO.Name;
        todoItem.IsComplete = TodoItemDTO.IsComplete;

        await _context.SaveChangesAsync();

        return TodoItemDTO;
    }

    private async Task<TodoItem> GetItem(long id) 
    {
        return await _context.TodoItems.FindAsync(id);
    }

    private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
       new TodoItemDTO
       {
           Id = todoItem.Id,
           Name = todoItem.Name,
           IsComplete = todoItem.IsComplete
       };
}
