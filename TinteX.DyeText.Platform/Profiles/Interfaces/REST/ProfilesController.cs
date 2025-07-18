using System.Net.Mime;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Queries;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;
using TinteX.DyeText.Platform.Profiles.Domain.Services;
using TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Profile Endpoints.")]
public class ProfilesController(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService)
: ControllerBase
{
    [HttpGet("{profileId:int}")]
    [SwaggerOperation("Get Profile by Id", "Get a profile by its unique identifier.", OperationId = "GetProfileById")]
    [SwaggerResponse(200, "The profile was found and returned.", typeof(ProfileResource))]
    [SwaggerResponse(404, "The profile was not found.")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile is null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Profile", "Create a new profile.", OperationId = "CreateProfile")]
    [SwaggerResponse(201, "The profile was created.", typeof(ProfileResource))]
    [SwaggerResponse(400, "The profile was not created.")]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new { profileId = profile.Id }, profileResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Profiles", "Get all profiles.", OperationId = "GetAllProfiles")]
    [SwaggerResponse(200, "The profiles were found and returned.", typeof(IEnumerable<ProfileResource>))]
    [SwaggerResponse(404, "The profiles were not found.")]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResources);
    }

    [HttpPut("{profileId:int}")]
    [SwaggerOperation("Update Profile", "Update an existing profile.", OperationId = "UpdateProfile")]
    [SwaggerResponse(200, "The profile was updated.", typeof(ProfileResource))]
    [SwaggerResponse(400, "Invalid data.")]
    [SwaggerResponse(404, "Profile not found.")]
    public async Task<IActionResult> UpdateProfile(int profileId, UpdateProfileResource resource)
    {
        if (profileId != resource.Id)
            return BadRequest("Profile ID mismatch.");

        var updateCommand = UpdateProfileCommandFromResourceAssembler.ToCommand(resource);
        var updated = await profileCommandService.Handle(updateCommand);
        if (updated is null)
            return NotFound();

        var output = ProfileResourceFromEntityAssembler.ToResourceFromEntity(updated);
        return Ok(output);
    }
}
