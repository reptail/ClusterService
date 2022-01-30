namespace ClusterService.Api.Controllers;

[ApiController]
[Route("ClusterService/v1/Lease")]
public class LeaseController : ControllerBase
{
    private readonly ITimeService _timeService;
    private readonly ILeaseRepository _leaseRepository;

    public LeaseController(ITimeService timeService, ILeaseRepository leaseRepository)
    {
        _timeService = timeService;
        _leaseRepository = leaseRepository;
    }

    [HttpGet("{system}")]
    [ProducesResponseType(typeof(dto.Lease), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(dto.Error), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetActiveAsync(string system)
    {
        dto.Lease latest = await _leaseRepository.GetLatestAsync(system);

        if (latest.ExpiresAt <= _timeService.UtcNow)
            throw new NotFoundException($"No active Lease found for '{system}'!");

        return Ok(latest);
    }

    [HttpPost("{system}/Aquire")]
    [ProducesResponseType(typeof(dto.LeaseResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> AquireAsync(string system, [FromBody] dto.LeaseRequest request)
    {
        await Task.Delay(10);

        return Ok(new dto.LeaseResponse(1, DateTime.UtcNow.AddMinutes(10)));
    }

    [HttpPut("{system}/Renew")]
    [ProducesResponseType(typeof(dto.LeaseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(dto.Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(dto.Error), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RenewAsync(string system, [FromBody] Guid leaseToken)
    {
        await Task.Delay(10);

        return Ok(new dto.LeaseResponse(1, DateTime.UtcNow.AddMinutes(10)));
    }

    [HttpDelete("{system}/Release/{leaseToken}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(dto.Error), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(dto.Error), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ReleaseAsync(string system, Guid leaseToken)
    {
        await Task.Delay(10);

        return Ok();
    }
}