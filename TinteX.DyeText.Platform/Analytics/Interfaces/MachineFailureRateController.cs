using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;
using TinteX.DyeText.Platform.Analytics.Domain.Services;

namespace TinteX.DyeText.Platform.Analytics.Interfaces
{
    [ApiController]
    [Route("api/v1/Dashboard&Analytics/textiles-machine")]
    [SwaggerTag("Available Textile Machine Failure Rate Endpoints")]
    public class MachineFailureRateController : ControllerBase
    {
        private readonly IMachineFailureRateQueryService _queryService;
        private readonly IFailureRateCommandService _commandService;

        public MachineFailureRateController(
            IMachineFailureRateQueryService queryService,
            IFailureRateCommandService commandService)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        // POST /api/machine-failure-rate/refresh
        [HttpPost("Failure-Rates")]
        [SwaggerOperation(
            Summary = "Refresh TextileMachine by Id",
            Description = "Refresh a TextileMachine by its unique identifier.",
            OperationId = "RefreshTextileMachineById")]
        public async Task<IActionResult> RefreshRates()
        {
            await _commandService.Handle(new UpdateMachineFailureRatesCommand());
            return NoContent();
        }

        // GET /api/machine-failure-rate
        [HttpGet("Failure-Rates")]
        [SwaggerOperation(
            Summary = "Get All TextileMachine",
            Description = "Get all the TextileMachine",
            OperationId = "GetAllTextileMachine")]
        public async Task<ActionResult<IEnumerable<MachineFailureRate>>> GetAll()
        {
            var list = await _queryService.ListAsync();
            return Ok(list);
        }

        // GET /api/machine-failure-rate/{machineId}
        [HttpGet("{machineId:guid}/Failure-Rates")]
        [SwaggerOperation(
            Summary = "Get TextileMachine by Id",
            Description = "Get a TextileMachine by its unique identifier.",
            OperationId = "GetTextileMachineById")]
        public async Task<ActionResult<MachineFailureRate>> GetByMachineId(Guid machineId)
        {
            var dto = await _queryService.FindByMachineIdAsync(machineId);
            if (dto is null) return NotFound();
            return Ok(dto);
        }
    }
}
