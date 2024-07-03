using Microsoft.AspNetCore.Mvc;
using TaskHub.Models;
using TaskHub.Models.Repository;

namespace TaskHub.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(ILogger<TasksController> logger, IUserRepository<User> userRepository)
    : ControllerBase
{
    private readonly ILogger<TasksController> _logger = logger;
    private readonly IUserRepository<User> _userRepository = userRepository;

    [HttpGet("{userId:guid}", Name = "GetUser")]
    public async Task<IActionResult> GetUser(Guid userId)
    {
        try
        {
            var user = await _userRepository.GetUser(userId);
            return Ok(user);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing GetUser request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
    }

    [HttpPost(Name = "AddUser")]
    public async Task<IActionResult> AddUser(User user)
    {
        try
        {
            var newUser = await _userRepository.AddUser(user);
            return CreatedAtRoute("GetUser", new { userId = newUser.UserId }, newUser);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing AddUser request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
    }

    [HttpPut("{userId:guid}", Name = "UpdateUser")]
    public async Task<IActionResult> UpdateUser(Guid userId, User user)
    {
        try
        {
            var updatedUser = await _userRepository.UpdateUser(userId, user);
            return Ok(updatedUser);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing UpdateUser request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
    }

    [HttpDelete("{userId:guid}", Name = "DeleteUser")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        try
        {
            var result = await _userRepository.DeleteUser(userId);
            return result ? NoContent() : NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while processing DeleteUser request");
            return Problem("An error occurred while processing your request", statusCode: 500);
        }
    }
}