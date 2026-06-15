using ClaimBridge.Services;
using ClaimBridge.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClaimBridge.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TaskController : ControllerBase
{
    private readonly TaskService _service;

    public TaskController(TaskService service)
    {
        _service = service;
    }
    [HttpGet("async")]
    public async Task<IActionResult> Get()
    {
        Console.WriteLine(
        $"Controller Start {DateTime.Now:HH:mm:ss.fff}");

        var result = await _service.GetStatusAsync();

        Console.WriteLine(
        $"Controller End {DateTime.Now:HH:mm:ss.fff}");
        
        return Ok(result);
    }
    [HttpGet("sync")]
    public IActionResult GetSync()
    {
        var result = _service.GetStatusSync();
        return Ok(result);
    }
}