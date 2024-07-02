using Microsoft.AspNetCore.Mvc;
using TaskHub.Models.Repository;
using Task = TaskHub.Models.Task;

namespace TaskHub.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController(ILogger<TaskController> logger, ITaskRepository<Task> taskRepository)
    : ControllerBase
{
    private readonly ILogger<TaskController> _logger = logger;
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
            _logger.LogError(e, "An error occurred while processing your request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
        
    }
}
