using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.ARM.Domain.Model.Queries;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Transform;
using TinteX.DyeText.Platform.ARM.Domain.Services;

namespace TinteX.DyeText.Platform.ARM.Interfaces.REST;


[ApiController]
[Route("api/v1/assets&resourcemanagement/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Textile Machine Endpoints")]
public class TextileMachinesController(
    ITextileMachineCommandService textileMachineCommandService,
    ITextileMachineQueryService textileMachineQueryService) : ControllerBase
{

    //Queries
    
    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Get TextileMachine by Id",
        Description = "Returns a TextileMachine by its unique identifier.",
        OperationId = "GetTextileMachineById")]
    [SwaggerResponse(StatusCodes.Status200OK, "TextileMachine found", typeof(TextileMachineResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "TextileMachine not found")]
    public async Task<IActionResult> GetTextileMachineById(Guid id)
    {
        var getTextileMachineByIdQuery = new GetTextileMachineByIdQuery(id);
        var textileMachine = await textileMachineQueryService.Handle(getTextileMachineByIdQuery);
        if (textileMachine == null) return NotFound();
        var resource = TextileMachineResourceFromEntityAssembler.toResourceFromEntity(textileMachine);
        return Ok(resource);
    }
    
    
    [HttpGet("{name}")]
    [SwaggerOperation(
        Summary = "Get textile machine by Name",
        Description = "Returns a textile machine by its unique identifier.",
        OperationId = "GetTextileMachineByName")]
    [SwaggerResponse(StatusCodes.Status200OK, "Textile machine found", typeof(TextileMachineResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Textile machine not found")]
    public async Task<IActionResult> GetTextileMachineByName(string name)
    {
        var getTextileMachineByNameQuery = new GetTextileMachineByNameQuery(name);
        var textileMachine = await textileMachineQueryService.Handle(getTextileMachineByNameQuery);
        if (textileMachine == null) return NotFound();
        var resource = TextileMachineResourceFromEntityAssembler.toResourceFromEntity(textileMachine);
        return Ok(resource);
    }
    

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Textile Machines",
        Description = "Returns a list of all textile machines in the system.",
        OperationId = "GetAllTextileMachines")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of textile machines", typeof(IEnumerable<TextileMachineResource>))]
    public async Task<IActionResult> GetAllTextileMachines()
    {
        var getAllTextileMachinesQuery = new GetAllTextileMachinesQuery();
        var textileMachines = await textileMachineQueryService.Handle(getAllTextileMachinesQuery);
        var resources = textileMachines.Select(TextileMachineResourceFromEntityAssembler.toResourceFromEntity).ToList();
        return Ok(resources);
    }
    
    
    
    //Commands
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Textile Machine",
        Description = "Creates a new Textile Machine in the system.",
        OperationId = "CreateTextileMachine")]
    [SwaggerResponse(StatusCodes.Status201Created, "Textile Machine created", typeof(TextileMachineResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Textile Machine could not be created")]   
    public async Task<IActionResult> CreateTextileMachine(
        [FromBody] CreateTextileMachineResource resource)
    {
        var createCommand = CreateTextileMachineCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await textileMachineCommandService.Handle(createCommand);
        if (result == null) return BadRequest("Failed to create Textile Machine.");
        var resourceResult = TextileMachineResourceFromEntityAssembler.toResourceFromEntity(result);
        return CreatedAtAction(nameof(GetTextileMachineById), new { id = result.Id }, resourceResult);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a textile machine",
        Description = "Updates an existing textile machine.",
        OperationId = "UpdateTextileMachine")]
    [SwaggerResponse(200, "The textile machine was updated", typeof(TextileMachineResource))]
    [SwaggerResponse(400, "The textile machine was not updated")]
    public async Task<ActionResult> UpdateTextileMachine(
        Guid id,
        [FromBody] UpdateTextileMachineResource resource)
    {
        var existingMachine = await textileMachineQueryService.Handle(new GetTextileMachineByIdQuery(id));
        if (existingMachine == null) return NotFound($"Textile Machine with Id {id} not found.");
        var updateCommand = UpdateTextileMachineCommandFromResourceAssembler.toCommandFromResource(resource, id);
        var result = await textileMachineCommandService.Handle(updateCommand);
        if (result == null) return BadRequest("Failed to update Textile Machine.");
        var resourceResult = TextileMachineResourceFromEntityAssembler.toResourceFromEntity(result);
        return Ok(resourceResult);
    }
}