using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public interface ITaskService
    {
        TaskData CreateTask(TaskData task);
        TaskData GetTask(int taskId);
        TaskData UpdateTask(TaskData updatedTask);
    }
}
