using Microsoft.AspNetCore.Mvc;
using TaskHub.Models.Repository;
using Task = TaskHub.Models.Task;

namespace TaskHub.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TasksController(ILogger<TasksController> logger, ITaskRepository<Task> taskRepository)
    : ControllerBase
{
    private readonly ILogger<TasksController> _logger = logger;
    private readonly  ITaskRepository<Task> _taskRepository = taskRepository;

    [HttpGet(Name = "GetAll")]
    public async Task<IActionResult> GetAllTasks()
    {
        try
        {
            return Ok(await _taskRepository.GetAll());
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing GetAllTasks request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
        
    }
    [HttpGet("{taskId:guid}", Name = "GetTask")]
    public async Task<IActionResult> GetTask(Guid taskId)
    {
        try
        {
            var task = await _taskRepository.Get(taskId);
            return Ok(task);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing GetTask request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
    }
    [HttpGet("category/{categoryName}", Name = "GetByCategory")]
    public async Task<IActionResult> GetByCategory(string categoryName)
    {
        try
        {
            var tasks = await _taskRepository.GetByCategory(categoryName);
            return Ok(tasks);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing GetByCategory request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
    }
    [HttpPost(Name = "AddTask")]
    public async Task<IActionResult> AddTask(Task task)
    {
        try
        {
            var newTask = await _taskRepository.Add(task);
            return CreatedAtRoute("GetTask", new {taskId = newTask.TaskId}, newTask);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing AddTask request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTask(Guid taskId, Task task)
    {
        try
        {
            var updatedTask = await _taskRepository.Update(taskId, task);
            return Ok(updatedTask);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing UpdateTask request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteTask(Guid taskId)
    {
        try
        {
            var result = await _taskRepository.Delete(taskId);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing DeleteTask request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
    }
}
