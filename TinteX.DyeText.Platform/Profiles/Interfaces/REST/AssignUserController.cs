using System.Net.Mime;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Queries;
using TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.Profiles.Interfaces.REST.Transform;
using TinteX.DyeText.Platform.Profiles.Domain.Services;

namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/users/textiles-machine")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available AssignUser Endpoints")]
public class AssignUserController(
    IAssignUserCommandService assignUserCommandService,
    IAssignUserQueryService assignUserQueryService) : ControllerBase
{
    // Queries

    [HttpGet("{id:guid}/assign-user")]
    [SwaggerOperation(
        Summary = "Get AssignUser by Id",
        Description = "Returns an AssignUser by its unique identifier.",
        OperationId = "GetAssignUserById")]
    [SwaggerResponse(StatusCodes.Status200OK, "AssignUser found", typeof(AssignUserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "AssignUser not found")]
    public async Task<IActionResult> GetAssignUserById(Guid id)
    {
        var query = new GetAssignUserByIdQuery(id);
        var assignUser = await assignUserQueryService.Handle(query);
        if (assignUser == null) return NotFound();
        var resource = AssignUserResourceFromEntityAssembler.ToResourceFromEntity(assignUser);
        return Ok(resource);
    }

    [HttpGet("assign-users")]
    [SwaggerOperation(
        Summary = "Get All AssignUsers",
        Description = "Returns a list of all assigned users in the system.",
        OperationId = "GetAllAssignUsers")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of assigned users", typeof(IEnumerable<AssignUserResource>))]
    public async Task<IActionResult> GetAllAssignUsers()
    {
        var query = new GetAllAssignUserQuery();
        var assignUsers = await assignUserQueryService.Handle(query);
        var resources = assignUsers.Select(AssignUserResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    // Commands

    [HttpPost("assign-users")]
    [SwaggerOperation(
        Summary = "Create AssignUser",
        Description = "Creates a new AssignUser in the system.",
        OperationId = "CreateAssignUser")]
    [SwaggerResponse(StatusCodes.Status201Created, "AssignUser created", typeof(AssignUserResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The AssignUser could not be created")]
    public async Task<IActionResult> CreateAssignUser(
        [FromBody] CreateAssignUserResource resource)
    {
        var createCommand = CreateAssignUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await assignUserCommandService.Handle(createCommand);
        if (result == null) return BadRequest("Failed to create AssignUser.");
        var resourceResult = AssignUserResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetAssignUserById), new { id = result.Id }, resourceResult);
    }

    [HttpPut("{id:guid}/assign-user")]
    [SwaggerOperation(
        Summary = "Update an AssignUser",
        Description = "Updates an existing AssignUser.",
        OperationId = "UpdateAssignUser")]
    [SwaggerResponse(200, "The AssignUser was updated", typeof(AssignUserResource))]
    [SwaggerResponse(400, "The AssignUser was not updated")]
    public async Task<IActionResult> UpdateAssignUser(
        Guid id,
        [FromBody] UpdateAssignUserResource resource)
    {
        var existingAssignUser = await assignUserQueryService.Handle(new GetAssignUserByIdQuery(id));
        if (existingAssignUser == null) return NotFound($"AssignUser with Id {id} not found.");
        var updateCommand = UpdateAssignUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await assignUserCommandService.Handle(updateCommand);
        if (result == null) return BadRequest("Failed to update AssignUser.");
        var resourceResult = AssignUserResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resourceResult);
    }
}