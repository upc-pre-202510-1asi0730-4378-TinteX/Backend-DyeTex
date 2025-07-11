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
[Route("api/v1/designandplanning/textiles-machine/request-invoices")]
[Produces("application/json")]
public class RequestInvoicesController : ControllerBase
{
    private readonly IRequestInvoiceCommandService _commandService;
    private readonly IRequestInvoiceQueryService _queryService;

    public RequestInvoicesController(
        IRequestInvoiceCommandService commandService,
        IRequestInvoiceQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "List all request invoices",
        Description = "Returns a list of all request invoices registered in the system."
    )]
    [SwaggerResponse(200, "List of request invoices successfully retrieved", typeof(IEnumerable<RequestInvoiceResource>))]
    public async Task<IActionResult> GetAll()
    {
        var invoices = await _queryService.Handle(new GetAllRequestInvoiceQuery());
        var resources = invoices.Select(RequestInvoiceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Register a new request invoice",
        Description = "Creates a new invoice associated with a technical service request."
    )]
    [SwaggerResponse(201, "Request invoice successfully created", typeof(object))]
    [SwaggerResponse(400, "Invalid data provided")]
    public async Task<IActionResult> Create([FromBody] CreateRequestInvoiceResource resource)
    {
        var command = CreateRequestInvoiceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var invoiceId = await _commandService.Handle(command);
        return CreatedAtAction(nameof(GetById), new { id = invoiceId.Value }, new { id = invoiceId.Value });
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(
        Summary = "Get a request invoice by ID",
        Description = "Returns detailed information for a specific request invoice by its ID."
    )]
    [SwaggerResponse(200, "Request invoice found", typeof(RequestInvoiceResource))]
    [SwaggerResponse(404, "Request invoice not found")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var invoice = await _queryService.GetByRequestIdAsync(new RequestId(id));
        if (invoice == null) return NotFound();
        var resource = RequestInvoiceResourceFromEntityAssembler.ToResourceFromEntity(invoice);
        return Ok(resource);
    }
    
    [HttpDelete("{id:guid}")]
    [SwaggerOperation(
        Summary = "Delete a request invoice",
        Description = "Deletes a request invoice by its associated request ID."
    )]
    [SwaggerResponse(204, "Invoice successfully deleted")]
    [SwaggerResponse(404, "Invoice not found")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteRequestInvoiceCommand(new RequestId(id));
        await _commandService.Handle(command);
        return NoContent();
    }

}