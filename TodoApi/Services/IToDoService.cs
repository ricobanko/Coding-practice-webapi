using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Services;

public interface IToDoService
{
    Task<IEnumerable<TodoItemDTO>> GetTodoItems();
    Task<TodoItemDTO?> GetTodoItemDTO(long id);
    Task<TodoItemDTO> PutTodoItemDTO(long id, TodoItemDTO todoItemDTO);
    Task<TodoItemDTO> PostTodoItemDTO(TodoItemDTO todoItemDTO);
    Task<bool> DeleteTodoItem(long id);
}
