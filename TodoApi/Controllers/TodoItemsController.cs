using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private IToDoService _toDoService;

        public TodoItemsController(TodoContext context, IToDoService toDoService)
        {
            _context = context;
            _toDoService = toDoService;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var ToItemsDto = await _toDoService.GetTodoItems();
            return Ok(ToItemsDto);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItemDto = await _toDoService.GetTodoItemDTO(id);
            return todoItemDto != null ? Ok(todoItemDto) : NotFound();
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDTO todoItemDto)
        {
            if (id != todoItemDto.Id)
            {
                return BadRequest();
            }

            var updatedTodoItemDto = await _toDoService.PutTodoItemDTO(id, todoItemDto);
            return CreatedAtAction(nameof(GetTodoItem), new { updatedTodoItemDto.Id }, updatedTodoItemDto);
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoItemDto)
        {
            var newTodoItemDto = await _toDoService.PostTodoItemDTO(todoItemDto);
            return CreatedAtAction(nameof(GetTodoItem), new { newTodoItemDto.Id }, newTodoItemDto);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var isDeleted = await _toDoService.DeleteTodoItem(id);

            if (isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
