using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.Analytics.Domain.Services;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;

namespace TinteX.DyeText.Platform.Analytics.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/Dashboard&Analytics/Task/Due-Status")]
    [SwaggerTag("Available Textile Machine Tasks Status Endpoints")]
    public class TaskDueStatusController : ControllerBase
    {
        private readonly ITaskDueStatusCountCommandService _commandService;
        private readonly ITaskDueStatusCountRepository _repository;

        public TaskDueStatusController(
            ITaskDueStatusCountCommandService commandService,
            ITaskDueStatusCountRepository repository)
        {
            _commandService = commandService;
            _repository = repository;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Refresh TextileMachine by Id",
            Description = "Refresh a TextileMachine by its unique identifier.",
            OperationId = "RefreshTextileMachineById")]
        public async Task<IActionResult> Refresh()
        {
            await _commandService.Handle(new UpdateTaskDueStatusCountCommand());
            return NoContent();
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All TextileMachine",
            Description = "Get all the TextileMachine",
            OperationId = "GetAllTextileMachine")]
        public async Task<IActionResult> Get()
        {
            var data = await _repository.GetAsync();
            if (data == null)
                return NotFound("No status counts found. Try refreshing first.");
            return Ok(data);
        }
    }
}