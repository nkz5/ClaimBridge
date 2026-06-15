using ClaimBridge.Services;
using ClaimBridge.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClaimBridge.Controllers;

[ApiController]
// URLの指定 [controller]は、コントローラーのクラス名から"Controller"を除いた部分が入る
[Route("api/[controller]")]
public class ClaimController : ControllerBase
{
    private readonly ClaimService _service;

    public ClaimController(ClaimService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetStatus());
    }
    [HttpPost]
    public IActionResult Send(
        SendClaimRequest request)
    {
        try
        {
            var result =
                _service.Send(request.UserId);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(
                500,
                new
                {
                    Message = ex.Message
                });
        }
    }
}