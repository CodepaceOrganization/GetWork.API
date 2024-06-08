using System.Net.Mime;
using CodePace.GetWork.API.Plans.Domain.Model.Aggregates;
using CodePace.GetWork.API.Plans.Domain.Service;
using CodePace.GetWork.API.Plans.Interface.REST.Resources;
using CodePace.GetWork.API.Plans.Interface.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace CodePace.GetWork.API.Plans.Interface.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(409)]
[ProducesResponseType(500)]
public class SubscriptionController(ISubscriptionCommandService commandService, ISubscriptionQueryService queryservice) : ControllerBase
{
    
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionResource resource)
    {
        var command = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var subscription = await commandService.Handle(command);
        var response = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return StatusCode(201, response);
    }
}