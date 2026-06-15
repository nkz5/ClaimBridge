using ClaimBridge.Services;
using ClaimBridge.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClaimBridge.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CertController : ControllerBase
{
    private readonly CertService _service;

    public CertController(CertService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult GetCertificates()
    {
        var result = _service.GetCertificates();
        return Ok(result);
    }
}