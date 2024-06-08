using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Domain.Services;
using CodePace.GetWork.API.contest.Domain.Model.Queries;
using CodePace.GetWork.API.contest.Interfaces.REST.Resources;
using CodePace.GetWork.API.contest.Interfaces.REST.Transform;
namespace CodePace.GetWork.API.contest.Interfaces.REST;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]

public class ContestController(
    IContestCommandService contestCommandService,
    IContestQueryService contestQueryService)
    : ControllerBase

{
    [HttpPost]
    public async Task<IActionResult> CreateWeeklyContest([FromBody] CreateWeeklyContestResource createWeeklyContestResource)
    {
        var createWeeklyContestCommand =
            CreateWeeklyContestCommandFromResourceAssembler.ToCommandFromResource(createWeeklyContestResource);
        var weeklyContest = await contestCommandService.Handle(createWeeklyContestCommand);
        if (weeklyContest is null) return BadRequest();
        var resource = WeeklyContestResourceFromEntityAssembler.ToResourceFromEntity(weeklyContest);
        return CreatedAtAction(nameof(GetWeeklyContestById), new { weeklyContestId = resource.Id }, resource);
    }
    
    [HttpGet("{weeklyContestId}")]
public async Task<IActionResult> GetWeeklyContestById(int weeklyContestId)
{
    var weeklyContest = await contestQueryService.Handle(new GetWeeklyContestByIdQuery(weeklyContestId));
    if (weeklyContest == null) return NotFound();
    var resource = WeeklyContestResourceFromEntityAssembler.ToResourceFromEntity(weeklyContest);
    return Ok(resource);
}
    

}


    
    