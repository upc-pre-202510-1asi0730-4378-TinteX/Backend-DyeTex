using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST;

[ApiController]
[Route("api/v1/designandplanning/textiles-machine/maintenances")]
[Produces("application/json")]
public class MaintenancesController : ControllerBase
{
    private readonly IMaintenanceCommandService _commandService;
    private readonly IMaintenanceQueryService _queryService;

    public MaintenancesController(
        IMaintenanceCommandService commandService,
        IMaintenanceQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "List all maintenances",
        Description = "Returns a complete list of scheduled maintenances, including machine name and status."
    )]
    [SwaggerResponse(200, "List of maintenances retrieved successfully", typeof(IEnumerable<MaintenanceResource>))]
    public async Task<IActionResult> GetAll()
    {
        var resources = await _queryService.GetAllResourcesAsync();
        return Ok(resources);
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Get maintenance by ID",
        Description = "Returns a specific maintenance by its unique identifier, enriched with machine name."
    )]
    [SwaggerResponse(200, "Maintenance found", typeof(MaintenanceResource))]
    [SwaggerResponse(404, "Maintenance with specified ID not found")]
    public async Task<ActionResult<MaintenanceResource>> GetById([FromRoute] Guid id)
    {
        var resource = await _queryService.GetResourceByIdAsync(new MaintenanceId(id));
        if (resource == null)
            return NotFound($"No maintenance found with ID: {id}");

        return Ok(resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new maintenance",
        Description = "Registers a new maintenance for a specific machine, assigning a scheduled date and description."
    )]
    [SwaggerResponse(201, "Maintenance successfully created")]
    [SwaggerResponse(400, "Invalid data for maintenance creation")]
    public async Task<IActionResult> Create([FromBody] CreateMaintenanceResource resource)
    {
        try
        {
            var command = CreateMaintenanceCommandFromResourceAssembler.ToCommandFromResource(resource);
            var maintenanceId = await _commandService.Handle(command);
            return CreatedAtAction(nameof(GetById), new { id = maintenanceId.Value }, new { id = maintenanceId.Value });
        }
        catch (FormatException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:guid}/status")]
    [SwaggerOperation(
        Summary = "Update maintenance status",
        Description = "Allows changing the status of an existing maintenance (e.g., Pending → Completed)."
    )]
    [SwaggerResponse(204, "Status successfully updated")]
    [SwaggerResponse(404, "Maintenance not found")]
    public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromBody] UpdateMaintenanceStatusResource resource)
    {
        var command = UpdateMaintenanceStatusCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        await _commandService.Handle(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(
        Summary = "Delete a maintenance",
        Description = "Deletes a maintenance record by its ID."
    )]
    [SwaggerResponse(204, "Maintenance successfully deleted")]
    [SwaggerResponse(404, "Maintenance not found")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteMaintenanceCommand(new MaintenanceId(id));
        await _commandService.Handle(command);
        return NoContent();
    }
}
