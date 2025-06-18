using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.Monitoring.Domain.Repositories;
using TinteX.DyeText.Platform.Monitoring.Domain.Services;

namespace TinteX.DyeText.Platform.ARM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Device Configuration Endpoints")]
public class DeviceConfigurationController : ControllerBase
{
    private readonly IDeviceConfigurationCommandService _commandService;
    private readonly IDeviceConfigurationQueryService _queryService;

    public DeviceConfigurationController(
        IDeviceConfigurationCommandService commandService,
        IDeviceConfigurationQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "DeviceConfiguration created successfully.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data.")]
    [SwaggerOperation(
        Summary = "Create Device Configuration",
        Description = "Creates a new device configuration entry with the provided details.",
        OperationId = "CreateDeviceConfiguration")]
    public async Task<IActionResult> CreateDeviceConfiguration([FromBody] CreateDeviceConfigurationCommand command)
    {
        var result = await _commandService.Handle(command);
        return CreatedAtAction(nameof(GetDeviceConfigurationByIpAddress), new { ipAddress = result?.IpAddress }, result);
    }

    [HttpPut("{ipAddress}")]
    [SwaggerResponse(StatusCodes.Status200OK, "DeviceConfiguration updated successfully.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "DeviceConfiguration not found.")]
    [SwaggerOperation(
        Summary = "Update Device Configuration",
        Description = "Updates an existing device configuration entry with the provided details.",
        OperationId = "UpdateDeviceConfiguration")]
    public async Task<IActionResult> UpdateDeviceConfiguration(string ipAddress, [FromBody] UpdateDeviceConfigurationCommand command)
    {
        if (ipAddress != command.IpAddress)
            return BadRequest("IP address in the URL does not match the IP address in the request body.");

        var deviceConfiguration = await _queryService.GetByIpAddress(ipAddress);
        if (deviceConfiguration == null)
            return NotFound("DeviceConfiguration not found.");

        var result = await _commandService.Handle(command);
        return Ok(result);
    }

    [HttpGet("by-ip/{ipAddress}")]
    [SwaggerResponse(StatusCodes.Status200OK, "DeviceConfiguration retrieved successfully.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "DeviceConfiguration not found.")]
    [SwaggerOperation(
        Summary = "Get Device Configuration by IP Address",
        Description = "Retrieves detailed information about a specific device configuration using its IP address.",
        OperationId = "GetDeviceConfigurationByIpAddress")]
    public async Task<IActionResult> GetDeviceConfigurationByIpAddress(string ipAddress)
    {
        var result = await _queryService.GetByIpAddress(ipAddress);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "List of all DeviceConfigurations retrieved successfully.")]
    [SwaggerOperation(
        Summary = "Get All Device Configurations",
        Description = "Retrieves a list of all device configurations.",
        OperationId = "GetAllDeviceConfigurations")]
    public async Task<IActionResult> GetAllDeviceConfigurations()
    {
        var result = await _queryService.GetAll();
        return Ok(result);
    }
}