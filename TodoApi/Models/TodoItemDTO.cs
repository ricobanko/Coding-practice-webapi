using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class TodoItemDTO
{
    public long Id { get; set; }

    [Required]
    [StringLength(20)]
    public string? Name { get; set; }

    [Required]
    public bool IsComplete { get; set; }
}
