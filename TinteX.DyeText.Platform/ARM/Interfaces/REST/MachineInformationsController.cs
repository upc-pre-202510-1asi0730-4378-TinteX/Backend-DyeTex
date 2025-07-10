using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.ARM.Domain.Model.Queries;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Transform;
using TinteX.DyeText.Platform.ARM.Domain.Services;

namespace TinteX.DyeText.Platform.ARM.Interfaces.REST;

[ApiController]
[Route("api/v1/assets/textile-machines/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Machine Information Endpoints")]
public class MachineInformationsController(
    IMachineInformationCommandService machineInformationCommandService,
    IMachineInformationQueryService machineInformationQueryService) : ControllerBase
{
    
    // Queries
    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        Summary = "Get Machine Information by ID",
        Description = "Retrieves detailed information about a specific machine using its unique identifier (ID).",
        OperationId = "GetMachineInformationById")]
    public async Task<IActionResult> GetMachineInformationById(Guid id)
    {
        var getMachineInformationById = new GetMachineInformationById(id);
        var result = await machineInformationQueryService.Handle(getMachineInformationById);
        if (result == null)
            return NotFound($"Machine information with ID {id} not found.");
        var resource = MachineInformationResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    
    //Commands
    
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "MachineInformation created successfully.",
        typeof(MachineInformationResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data.")]
    [SwaggerOperation(
        Summary = "Create Machine Information",
        Description = "Creates a new machine information entry with the provided details.",
        OperationId = "CreateMachineInformation")]
    public async Task<IActionResult> CreateMachineInformation([FromBody] CreateMachineInformationResource resource)
    {
        var createMachineInformationCommand = 
            CreateMachineInformationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await machineInformationCommandService.Handle(createMachineInformationCommand);
        if (result is null)
            return BadRequest("Failed to create machine information.");
        var createdResource = MachineInformationResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetMachineInformationById), new { id = createdResource.Id }, createdResource);
    }
    
    
    
    [HttpPut("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "MachineInformation updated successfully.",
        typeof(MachineInformationResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "MachineInformation not found.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data.")]
    [SwaggerOperation(
        Summary = "Update Machine Information",
        Description = "Updates an existing machine information entry with the provided details.",
        OperationId = "UpdateMachineInformation")]
    public async Task<IActionResult> UpdateMachineInformation(Guid id, [FromBody] UpdateMachineInformationResource resource)
    {
        var updateMachineInformationCommand = 
            UpdateMachineInformationCommandFromResourceAssembler.ToCommandFromResource(resource, id);
        var result = await machineInformationCommandService.Handle(updateMachineInformationCommand);
        if (result == null)
            return NotFound($"Machine information with ID {id} not found.");
        var updatedResource = MachineInformationResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(updatedResource);
    }
    
}