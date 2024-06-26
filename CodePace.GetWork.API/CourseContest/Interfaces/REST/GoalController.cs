using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;
using CodePace.GetWork.API.CourseContest.Domain.Services;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]

public class GoalController(IGoalCommandService goalCommandService, IGoalQueryService goalQueryService)
    : ControllerBase
{
        [HttpPost]
        public async Task<IActionResult> CreateGoal([FromBody] CreateGoalResource createGoalResource)
        {
            var createGoalCommand = CreateGoalCommandFromResourceAssembler.ToCommandFromResource(createGoalResource);
            var goal = await goalCommandService.Handle(createGoalCommand);
            if (goal is null) return BadRequest();
            var resource = GoalResourceFromEntityAssembler.ToResourceFromEntity(goal);
            return CreatedAtAction(nameof(GetGoalById), new { goalId = resource.Id }, resource);
        }

        [HttpGet("{goalId}")]
        public async Task<IActionResult> GetGoalById(int goalId)
        {
            var goal = await goalQueryService.Handle(new GetGoalByIdQuery(goalId));
            if (goal == null) return NotFound();
            var resource = GoalResourceFromEntityAssembler.ToResourceFromEntity(goal);
            return Ok(resource);
        }

        [HttpPut("{goalId}")]
        public async Task<IActionResult> UpdateGoal(int goalId, [FromBody] UpdateGoalResource updateGoalResource)
        {
            var updateGoalCommand = UpdateGoalCommandFromResourceAssembler.ToCommandFromResource(updateGoalResource);
            var updatedGoal = await goalCommandService.Handle(updateGoalCommand);
            if (updatedGoal == null) return NotFound();
            var resource = GoalResourceFromEntityAssembler.ToResourceFromEntity(updatedGoal);
            return Ok(resource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGoals()
        {
            var goals = await goalQueryService.Handle(new GetAllGoalQuery());
            var resources = goals.Select(GoalResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
}