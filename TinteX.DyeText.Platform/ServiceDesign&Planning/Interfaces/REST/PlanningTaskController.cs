using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST;

[ApiController]
[Route("api/v1/designandplanning/tasks")]
[Produces("application/json")]
public class PlanningTaskController : ControllerBase
{
    private readonly IPlanningTaskCommandService _commandService;
    private readonly IPlanningTaskQueryService _queryService;

    public PlanningTaskController(
        IPlanningTaskCommandService commandService,
        IPlanningTaskQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "List all planning tasks",
        Description = "Returns a list of all planning tasks registered in the system."
    )]
    [SwaggerResponse(200, "List of tasks successfully retrieved", typeof(IEnumerable<PlanningTaskResource>))]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _queryService.Handle();
        var resources = tasks.Select(PlanningTaskResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new planning task",
        Description = "Registers a new planning task in the system with the provided data."
    )]
    [SwaggerResponse(201, "Task successfully created", typeof(object))]
    [SwaggerResponse(400, "Invalid data provided")]
    public async Task<IActionResult> Create([FromBody] CreatePlanningTaskResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = CreatePlanningTaskCommandFromResourceAssembler.ToCommandFromResource(resource);
        var taskId = await _commandService.Handle(command);
        return CreatedAtAction(nameof(GetById), new { id = taskId.Value }, new { id = taskId.Value });
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Get a planning task by ID",
        Description = "Returns a planning task based on the provided ID."
    )]
    [SwaggerResponse(200, "Task found", typeof(PlanningTaskResource))]
    [SwaggerResponse(404, "Task not found")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var query = new GetTaskByIdQuery(new TaskId(id));
        var task = await _queryService.Handle(query);
        if (task == null) return NotFound();
        var resource = PlanningTaskResourceFromEntityAssembler.ToResourceFromEntity(task);
        return Ok(resource);
    }

    [HttpPut("{id:guid}")]
    [SwaggerOperation(
        Summary = "Update the name of a task",
        Description = "Allows updating the name of an existing planning task."
    )]
    [SwaggerResponse(204, "Task name successfully updated")]
    [SwaggerResponse(404, "Task not found")]
    public async Task<IActionResult> Rename([FromRoute] Guid id, [FromBody] UpdatePlanningTaskResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = UpdateTaskNameCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        await _commandService.Handle(command);
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    [SwaggerOperation(
        Summary = "Delete a planning task",
        Description = "Removes a planning task based on the provided ID."
    )]
    [SwaggerResponse(204, "Task successfully deleted")]
    [SwaggerResponse(404, "Task not found")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteTaskCommand(new TaskId(id));
        await _commandService.Handle(command);
        return NoContent();
    }
}
