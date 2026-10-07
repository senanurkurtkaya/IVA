using Iva.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Iva.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AiController : ControllerBase
{
    private readonly IAiService _aiService;

    public AiController(IAiService aiService)
    {
        _aiService = aiService;
    }

    [HttpPost("chat")]
    public async Task<IActionResult> Chat(
        [FromBody] string message,
        CancellationToken cancellationToken)
    {
        var response = await _aiService.GetResponseAsync(
            message,
            cancellationToken);

        return Ok(response);
    }
}