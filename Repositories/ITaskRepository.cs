using task_api.Models;
namespace task_api.Repositories;

public interface ITaskRepository {

    IEnumerable<Models.Task> GetAllTasks();
    Models.Task GetTaskById(int taskId);
    Models.Task CreateTask(Models.Task newTask);
    Models.Task UpdateTask(Models.Task newTask);
    void DeleteTaskById(int taskId);
}