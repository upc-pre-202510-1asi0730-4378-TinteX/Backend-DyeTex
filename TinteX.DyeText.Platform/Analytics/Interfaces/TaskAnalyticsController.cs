using Microsoft.AspNetCore.Mvc;
using TinteX.DyeText.Platform.Analytics.Domain.Services;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;

namespace TinteX.DyeText.Platform.Analytics.Interfaces.REST
{
    [ApiController]
    [Route("api/task-due-status")]
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

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            await _commandService.Handle(new UpdateTaskDueStatusCountCommand());
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _repository.GetAsync();
            if (data == null)
                return NotFound("No status counts found. Try refreshing first.");
            return Ok(data);
        }
    }
}