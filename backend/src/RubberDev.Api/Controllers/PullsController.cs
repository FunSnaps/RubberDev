using Microsoft.AspNetCore.Mvc;
using RubberDev.Application.DTOs;
using RubberDev.Application.UseCases;

namespace RubberDev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PullsController : ControllerBase
{
    private readonly IGachaService _gachaService;

    public PullsController(IGachaService gachaService)
    {
        _gachaService = gachaService;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PullBatchDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var batches = await _gachaService.RetrieveAllPullBatchesAsync(cancellationToken);
        return Ok(batches);
    }

    /// <summary>
    /// Returns one specific pull batch by its ID.
    /// </summary>
    [HttpGet("{batchId:guid}")]
    public async Task<ActionResult<PullBatchDto>> GetByIdAsync(
        Guid batchId,
        CancellationToken cancellationToken = default)
    {
        var batch = await _gachaService
            .RetrieveAllPullBatchesAsync(cancellationToken)
            .ContinueWith(t => t.Result.FirstOrDefault(b => b.PullBatchId == batchId),
                cancellationToken);

        if (batch is null)
            return NotFound();

        return Ok(batch);
    }
}