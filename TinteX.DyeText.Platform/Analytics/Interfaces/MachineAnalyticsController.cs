using Microsoft.AspNetCore.Mvc;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;
using TinteX.DyeText.Platform.Analytics.Domain.Services;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;

namespace TinteX.DyeText.Platform.Analytics.Interfaces
{
    [ApiController]
    [Route("api/machine-failure-count")]
    public class MachineAnalyticsController : ControllerBase
    {
        private readonly IMachinesFailureCountQueryService _queryService;
        private readonly IFailureCountCommandService _commandService;

        public MachineAnalyticsController(
            IMachinesFailureCountQueryService queryService,
            IFailureCountCommandService commandService)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        // POST /api/machine-failure-count/refresh
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshCounts()
        {
            await _commandService.Handle(new UpdateMachineFailureCountsCommand());
            return NoContent();
        }

        // GET /api/machine-failure-count
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineFailureCount>>> GetAll()
        {
            var list = await _queryService.ListAsync();
            return Ok(list);
        }

        // GET /api/machine-failure-count/{machineId}
        [HttpGet("{machineId:guid}")]
        public async Task<ActionResult<MachineFailureCount>> GetByMachineId(Guid machineId)
        {
            var dto = await _queryService.FindByMachineIdAsync(machineId);
            if (dto is null) return NotFound();
            return Ok(dto);
        }
        
    }
}

