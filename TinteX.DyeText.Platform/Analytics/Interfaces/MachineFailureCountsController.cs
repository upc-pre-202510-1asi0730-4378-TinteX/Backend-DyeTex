using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;
using TinteX.DyeText.Platform.Analytics.Domain.Services;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;

namespace TinteX.DyeText.Platform.Analytics.Interfaces
{
    [ApiController]
    [Route("api/v1/Dashboard&Analytics/textiles-machine")]
    [SwaggerTag("Available Textile Machine Failure Counts Endpoints")]
    public class MachineFailureCountsController : ControllerBase
    {
        private readonly IMachinesFailureCountQueryService _queryService;
        private readonly IFailureCountCommandService _commandService;

        public MachineFailureCountsController(
            IMachinesFailureCountQueryService queryService,
            IFailureCountCommandService commandService)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        // POST /api/machine-failure-count/refresh
        [HttpPost("Failure-Counts")]
        [SwaggerOperation(
            Summary = "Refresh TextileMachine by Id",
            Description = "Refresh a TextileMachine by its unique identifier.",
            OperationId = "RefreshTextileMachineById")]
        public async Task<IActionResult> RefreshCounts()
        {
            await _commandService.Handle(new UpdateMachineFailureCountsCommand());
            return NoContent();
        }

        // GET /api/machine-failure-count
        [HttpGet("Failure-Counts")]
        [SwaggerOperation(
            Summary = "Get All TextileMachine",
            Description = "Get all the TextileMachine",
            OperationId = "GetAllTextileMachine")]
        public async Task<ActionResult<IEnumerable<MachineFailureCount>>> GetAll()
        {
            var list = await _queryService.ListAsync();
            return Ok(list);
        }

        // GET /api/machine-failure-count/{machineId}
        [HttpGet("{machineId:guid}/Failure-Counts")]
        [SwaggerOperation(
            Summary = "Get TextileMachine by Id",
            Description = "Get a TextileMachine by its unique identifier.",
            OperationId = "GetTextileMachineById")]
        public async Task<ActionResult<MachineFailureCount>> GetByMachineId(Guid machineId)
        {
            var dto = await _queryService.FindByMachineIdAsync(machineId);
            if (dto is null) return NotFound();
            return Ok(dto);
        }
        
    }
}

