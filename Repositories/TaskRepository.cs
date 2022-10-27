using task_api.Migrations;

namespace task_api.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }
    public Models.Task CreateTask(Models.Task newTask)
    {
        _context.Tasks!.Add(newTask);
        _context.SaveChanges();
        return newTask;

    }

    public void DeleteTaskById(int taskId)
    {
        var task = _context.Tasks!.Find(taskId);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Models.Task> GetAllTasks()
    {
        return _context.Tasks!.ToList();
    }

    public Models.Task? GetTaskById(int taskId)
    {
        return _context.Tasks!.SingleOrDefault(t => t.TaskId == taskId);
    }

    public Models.Task? UpdateTask(Models.Task newTask)
    {
        var originalTask = _context.Tasks!.Find(newTask.TaskId);
        if (originalTask != null)
        {
            originalTask.Title = newTask.Title;
            originalTask.Completed = newTask.Completed;
            _context.SaveChanges();
        }
        return originalTask;
    }
}