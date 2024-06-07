using System.Net.Mime;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Queries;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;
using CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST;

[ApiController]
[Route("api/v1/technical-tasks")]
[Produces(MediaTypeNames.Application.Json)]

public class TechnicalTaskController(ITechnicalTaskCommandService technicalTaskCommandService): ControllerBase
{
    [HttpPut("{technicalTestId}/assign/{userId}")]
    public async Task<IActionResult> AssignTechnicalTaskToUser([FromRoute] int technicalTestId, [FromRoute]int userId)
    { 
        //falta
        return null;
    }
}