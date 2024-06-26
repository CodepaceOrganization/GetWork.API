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

public class WeeklyContestController(
    IWeeklyContestCommandService weeklyContestCommandService,
    IWeeklyContestQueryService weeklyContestQueryService)
    : ControllerBase

{
    [HttpPost]
    public async Task<IActionResult> CreateWeeklyContest([FromBody] CreateWeeklyContestResource createWeeklyContestResource)
    {
        var createWeeklyContestCommand =
            CreateWeeklyContestCommandFromResourceAssembler.ToCommandFromResource(createWeeklyContestResource);
        var weeklyContest = await weeklyContestCommandService.Handle(createWeeklyContestCommand);
        if (weeklyContest is null) return BadRequest();
        var resource = WeeklyContestResourceFromEntityAssembler.ToResourceFromEntity(weeklyContest);
        return CreatedAtAction(nameof(GetWeeklyContestById), new { weeklyContestId = resource.Id }, resource);
    }
    
    [HttpGet("{weeklyContestId}")]
    public async Task<IActionResult> GetWeeklyContestById(int weeklyContestId)
    {
        var weeklyContest = await weeklyContestQueryService.Handle(new GetWeeklyContestByIdQuery(weeklyContestId));
        if (weeklyContest == null) return NotFound();
        var resource = WeeklyContestResourceFromEntityAssembler.ToResourceFromEntity(weeklyContest);
        return Ok(resource);
    }
    
    [HttpPut("{weeklyContestId}")]
    public async Task<IActionResult> UpdateWeeklyContest(int weeklyContestId, [FromBody] UpdateWeeklyContestResource updateWeeklyContestResource)
    {
        var updateWeeklyContestCommand = UpdateWeeklyContestCommandFromResourceAssembler.ToCommandFromResource(updateWeeklyContestResource);
        var updatedWeeklyContest = await weeklyContestCommandService.Handle(updateWeeklyContestCommand);
        if (updatedWeeklyContest == null) return NotFound();
        var resource = WeeklyContestResourceFromEntityAssembler.ToResourceFromEntity(updatedWeeklyContest);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllWeeklyContest()
    {
        var weeklyContests = await weeklyContestQueryService.Handle(new GetAllWeeklyContestQuery());
        var resources = weeklyContests.Select(WeeklyContestResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
        

}


    
    