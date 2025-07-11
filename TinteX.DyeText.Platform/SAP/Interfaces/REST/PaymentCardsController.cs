using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.SAP.Domain.Model.Queries;
using TinteX.DyeText.Platform.SAP.Domain.Services;
using TinteX.DyeText.Platform.SAP.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.SAP.Interfaces.REST.Transform;

namespace TinteX.DyeText.Platform.SAP.Interfaces.REST;

[ApiController]
[Route("api/v1/subscription/user/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Subscriptions and Payments Endpoints")]
public class PaymentCardsController(
      IPaymentCardCommandService paymentCardCommandService,
      IPaymentCardQueryService paymentCardQueryService
      ) : ControllerBase
{
      [HttpGet]
      [SwaggerOperation(
            Summary = "Get All Payments Card",
            Description = "Returns a list of all payments cards in the system.",
            OperationId = "GetAllPaymentsCard")]
      [SwaggerResponse(StatusCodes.Status200OK, "List of payments cards", typeof(IEnumerable<PaymentCardResource>))]
      public async Task<IActionResult> GetAllPaymentsCard()
      {
            var getAllPaymentCardsQuery = new GetAllPaymentCardsQuery();
            var paymentCards = await paymentCardQueryService.Handle(getAllPaymentCardsQuery);
            var resources = paymentCards.Select(PaymentCardResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(resources);
      }

      [HttpPost]
      [SwaggerOperation(
            Summary = "Create Payments Card",
            Description = "Creates a new payments card in the system.",
            OperationId = "CreateTextileMachine")]
      [SwaggerResponse(StatusCodes.Status201Created, "Payments cards created", typeof(PaymentCardResource))]
      [SwaggerResponse(StatusCodes.Status400BadRequest, "The payments cards could not be created")]
      public async Task<IActionResult> CreatePaymentsCard(CreatePaymentCardResource resource)
      {
            var createCommand = CreatePaymentCardCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await paymentCardCommandService.Handle(createCommand);
            if (result == null) return BadRequest("The payments card could not be created.");
            var createdResource = PaymentCardResourceFromEntityAssembler.ToResourceFromEntity(result);
            return CreatedAtAction(nameof(CreatePaymentsCard), new { id = createdResource.Id }, createdResource);
      }
      
}