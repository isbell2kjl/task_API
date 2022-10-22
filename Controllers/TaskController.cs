using task_api.Models;
using task_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace task_api.Controllers;

[ApiController]
[Route("[controller]")]

public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskRepository _taskRepository;

    public TaskController(ILogger<TaskController> logger, ITaskRepository repository)
    {
        _logger = logger;
        _taskRepository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Models.Task>> GetTasks()
    {
        return Ok(_taskRepository.GetAllTasks());
    }

    [HttpGet]
    [Route("{taskId:int}")]
    public ActionResult<Models.Task> GetTaskById(int taskId)
    {
        var task = _taskRepository.GetTaskById(taskId);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public ActionResult<Models.Task> CreateTask(Models.Task task) 
    {
        if (!ModelState.IsValid || task == null) {
            return BadRequest();
    }
        var newTask = _taskRepository.CreateTask(task);
        return Created(nameof(GetTaskById), newTask);
    }

    [HttpPut]
    [Route("{TaskId:int}")]
    public ActionResult<Models.Task> UpdateTask(Models.Task task) 
    {
        if (!ModelState.IsValid || task == null) {
            return BadRequest();
    }
        return Ok(_taskRepository.UpdateTask(task));
    }

    [HttpDelete]
    [Route("{taskId:int}")]
    public ActionResult DeleteTask(int taskId) 
    {
        _taskRepository.DeleteTaskById(taskId);
            return NoContent();
    }

}