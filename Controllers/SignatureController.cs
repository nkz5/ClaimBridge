using Microsoft.AspNetCore.Mvc;
using ClaimBridge.Models;
using ClaimBridge.Services;

namespace ClaimBridge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SignatureController : ControllerBase
{
    private readonly SignatureService
        _signatureService;

    public SignatureController(
        SignatureService signatureService)
    {
        _signatureService =
            signatureService;
    }

    [HttpPost("sign")]
    public IActionResult Sign(
        SignRequest request)
    {
        var signature =
            _signatureService.Sign(
                request.Message);

        return Ok(new
        {
            Signature = signature
        });
    }

    [HttpPost("verify")]
    public IActionResult Verify(
        VerifyRequest request)
    {
        var result =
            _signatureService.Verify(
                request.Message,
                request.Signature);

        return Ok(new
        {
            IsValid = result
        });
    }
}