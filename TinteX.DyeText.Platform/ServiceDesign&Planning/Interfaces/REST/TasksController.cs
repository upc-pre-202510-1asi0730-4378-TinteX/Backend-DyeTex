using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST;

/// <summary>
/// The tasks controller
/// </summary>
/// <param name="taskCommandService">Service to execute task commands</param>
/// <param name="taskQueryService">Service to query task data</param>

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Endpoints for managing scheduled tasks")]
public class TasksController(
    ITaskCommandService taskCommandService,
    ITaskQueryService taskQueryService) : ControllerBase {
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Tasks",
        Description = "Returns a list of all tasks",
        OperationId = "GetAllTasks")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tasks found", typeof(IEnumerable<TaskResource>))]
    public async Task<IActionResult> GetAll() {
        var query = new GetAllTasksQuery();
        var tasks = await taskQueryService.Handle(query);
        var resources = tasks.Select(TaskResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("{taskId:guid}")]
    [SwaggerOperation(
        Summary = "Get Task by ID",
        Description = "Returns a task by its unique identifier",
        OperationId = "GetTaskById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Task found", typeof(TaskResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found")]
    public async Task<IActionResult> GetById(Guid taskId) {
        var task = await taskQueryService.Handle(new GetTaskByIdQuery(taskId));
        if (task is null) return NotFound();
        var resource = TaskResourceFromEntityAssembler.ToResourceFromEntity(task);
        return Ok(resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Task",
        Description = "Creates a new scheduled task",
        OperationId = "CreateTask")]
    [SwaggerResponse(StatusCodes.Status201Created, "Task created", typeof(TaskResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data or could not create")]
    public async Task<IActionResult> Create([FromBody] CreateTaskResource resource) {
        var command = CreateTaskCommandFromResourceAssembler.ToCommandFromResource(resource);
        var taskId = await taskCommandService.Handle(command);
        return CreatedAtAction(nameof(GetById), new { taskId }, null);
    }

    [HttpPut("{taskId:guid}/name")]
    [SwaggerOperation(
        Summary = "Update Task Name",
        Description = "Updates the name of an existing task",
        OperationId = "UpdateTaskName")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Task updated")]
    public async Task<IActionResult> UpdateName(Guid taskId, [FromBody] UpdateTaskNameResource resource) {
        await taskCommandService.Handle(new UpdateTaskNameCommand(taskId, resource.NewName));
        return NoContent();
    }

    [HttpPut("{taskId:guid}/duedate")]
    [SwaggerOperation(
        Summary = "Update Task Due Date",
        Description = "Updates the due date of an existing task",
        OperationId = "UpdateTaskDueDate")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Task updated")]
    public async Task<IActionResult> UpdateDueDate(Guid taskId, [FromBody] UpdateTaskDueDateResource resource) {
        await taskCommandService.Handle(new UpdateTaskDueDateCommand(taskId, resource.NewDueDate));
        return NoContent();
    }

    [HttpDelete("{taskId:guid}")]
    [SwaggerOperation(
        Summary = "Delete Task",
        Description = "Deletes a task by its ID",
        OperationId = "DeleteTask")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Task deleted")]
    public async Task<IActionResult> Delete(Guid taskId) {
        await taskCommandService.Handle(new DeleteTaskCommand(taskId));
        return NoContent();
    }
}
