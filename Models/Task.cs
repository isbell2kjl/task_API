using System.ComponentModel.DataAnnotations;

namespace task_api.Models;

public class Task 
{
    [Required]
    public int TaskId { get; set; }
    [Required]
    public string? Title { get; set; }
    public bool Completed { get; set; }
}