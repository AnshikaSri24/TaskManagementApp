using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskData task)
        {
            if (task == null)
            {
                return BadRequest("Task data is invalid.");
            }

            var createdTask = _taskService.CreateTask(task);
            return Ok(createdTask);
        }

        [HttpGet("{taskId}")]
        public IActionResult GetTask(int taskId)
        {
            var task = _taskService.GetTask(taskId);

            if (task == null)
            {
                return NotFound("Task not found.");
            }

            return Ok(task);
        }

        [HttpPut("{taskId}")]
        public IActionResult UpdateTask(int taskId, [FromBody] TaskData updatedTask)
        {
            var task = _taskService.GetTask(taskId);

            if (task == null)
            {
                return NotFound("Task not found.");
            }

            if (updatedTask == null)
            {
                return BadRequest("Task data is invalid.");
            }

            updatedTask.TaskId = taskId;
            var updated = _taskService.UpdateTask(updatedTask);

            if (updated == null)
            {
                return NotFound("Task not found.");
            }

            return Ok(updated);
        }
    }
}
