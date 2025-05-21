using Microsoft.AspNetCore.Mvc;
using RubberDev.Application.DTOs;
using RubberDev.Application.Interfaces;

namespace RubberDev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PullsController : ControllerBase
{
    private readonly IGachaService _gachaService;

    public PullsController(IGachaService gachaService)
    {
        this._gachaService = gachaService;
    }
    
    [HttpPost]
    public async Task<ActionResult<GachaResultDto>> PullAsync(
        [FromQuery] int count = 1,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _gachaService.PullAsync(count, cancellationToken);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}