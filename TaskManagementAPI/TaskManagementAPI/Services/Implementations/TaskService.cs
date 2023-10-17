using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services.Implementations
{
    public class TaskService
    {
        private List<TaskData> _tasks = new List<TaskData>();
        private int _nextTaskId = 1;

        public TaskData CreateTask(TaskData task)
        {
            task.TaskId = _nextTaskId++;
            _tasks.Add(task);
            return task;
        }

        public TaskData GetTask(int taskId)
        {
            return _tasks.FirstOrDefault(t => t.TaskId == taskId);
        }

        public TaskData UpdateTask(TaskData updatedTask)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.TaskId == updatedTask.TaskId);

            if (existingTask != null)
            {
                existingTask.Name = updatedTask.Name;
                existingTask.Description = updatedTask.Description;
                existingTask.Deadline = updatedTask.Deadline;
                existingTask.IsFavorited = updatedTask.IsFavorited;
            }

            return existingTask;
        }
    }
}
