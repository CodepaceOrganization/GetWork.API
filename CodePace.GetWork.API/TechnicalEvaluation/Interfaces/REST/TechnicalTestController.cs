using System.Net.Mime;
using CodePace.GetWork.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Queries;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST;

[ApiController]
[Route("api/v1/technical-test")]
[Produces(MediaTypeNames.Application.Json)]
public class TechnicalTestController(ITechnicalTestQueryService technicalTestQueryService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTechnicalTests()
    {
        var getAllTechnicalTestsQuery = new GetAllTechnicalTestsQuery();
        var technicalTests = await technicalTestQueryService.Handle(getAllTechnicalTestsQuery);
        return Ok(technicalTests);
    }
    [HttpGet("test-type/{testType}")]
    public async Task<IActionResult> GetAllTechnicalTaskByTestType(string testType)
    {
        var getAllTechnicalTaskByTestTypeQuery = new GetAllTechnicalTaskByTestTypeQuery(testType);
        var technicalTests = await technicalTestQueryService.Handle(getAllTechnicalTaskByTestTypeQuery);
        return Ok(technicalTests);
    }
}