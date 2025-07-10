using System.Net.Mime;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.Monitoring.Domain.Model.Queries;
using TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Transform;
using TinteX.DyeText.Platform.Monitoring.Domain.Services;

namespace TinteX.DyeText.Platform.Monitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/monitoring/textiles-machine")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Notification Endpoints")]
public class NotificationsController(
    INotificationCommandService notificationCommandService,
    INotificationQueryService notificationQueryService) : ControllerBase
{
    // Queries

    [HttpGet("{id:guid}/notification")]
    [SwaggerOperation(
        Summary = "Get Notification by Id",
        Description = "Returns a Notification by its unique identifier.",
        OperationId = "GetNotificationById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Notification found", typeof(NotificationResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Notification not found")]
    public async Task<IActionResult> GetNotificationById(Guid id)
    {
        var query = new GetNotificationsByIdQuery(id);
        var notification = await notificationQueryService.Handle(query);
        if (notification == null) return NotFound();
        var resource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return Ok(resource);
    }

    [HttpGet("notification")]
    [SwaggerOperation(
        Summary = "Get All Notifications",
        Description = "Returns a list of all notifications in the system.",
        OperationId = "GetAllNotifications")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of notifications", typeof(IEnumerable<NotificationResource>))]
    public async Task<IActionResult> GetAllNotifications()
    {
        var query = new GetAllNotificationsQuery();
        var notifications = await notificationQueryService.Handle(query);
        var resources = notifications.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    // Commands

    [HttpPost("notification")]
    [SwaggerOperation(
        Summary = "Create Notification",
        Description = "Creates a new Notification in the system.",
        OperationId = "CreateNotification")]
    [SwaggerResponse(StatusCodes.Status201Created, "Notification created", typeof(NotificationResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The Notification could not be created")]
    public async Task<IActionResult> CreateNotification(
        [FromBody] CreateNotificationResource resource)
    {
        var createCommand = CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await notificationCommandService.Handle(createCommand);
        if (result == null) return BadRequest("Failed to create Notification.");
        var resourceResult = NotificationResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetNotificationById), new { id = result.Id }, resourceResult);
    }

    [HttpPut("{id}/notification")]
    [SwaggerOperation(
        Summary = "Update a notification",
        Description = "Updates an existing notification.",
        OperationId = "UpdateNotification")]
    [SwaggerResponse(200, "The notification was updated", typeof(NotificationResource))]
    [SwaggerResponse(400, "The notification was not updated")]
    public async Task<ActionResult> UpdateNotification(
        Guid id,
        [FromBody] UpdateNotificationResource resource)
    {
        var existingNotification = await notificationQueryService.Handle(new GetNotificationsByIdQuery(id));
        if (existingNotification == null) return NotFound($"Notification with Id {id} not found.");
        var updateCommand = UpdateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource, id);
        var result = await notificationCommandService.Handle(updateCommand);
        if (result == null) return BadRequest("Failed to update Notification.");
        var resourceResult = NotificationResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resourceResult);
    }
}