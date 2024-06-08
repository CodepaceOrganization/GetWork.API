using System.Net.Mime;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;
using CodePace.GetWork.API.CourseContest.Domain.Services;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CoursesController(
    ICourseCommandService courseCommandService,
    ICourseQueryService courseQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a course",
        Description = "Creates a course with the given details",
        OperationId = "CreateCourse")]
    [SwaggerResponse(201, "The course was created", typeof(CourseResource))]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseResource createCourseResource)
    {
        var createCourseCommand =
            CreateCourseCommandFromResourceAssembler.ToCommandFromResource(createCourseResource);
        var course = await courseCommandService.Handle(createCourseCommand);
        if (course is null) return BadRequest();
        var resource = CourseResourceFromEntityAssembler.ToResourceFromEntity(course);
        return CreatedAtAction(nameof(GetCourseById), new { courseId = resource.Id }, resource);
    }

    [HttpGet("{courseId:int}")]
    [SwaggerOperation(
        Summary = "Gets a course by id",
        Description = "Gets a course for a given identifier",
        OperationId = "GetCourseById")]
    [SwaggerResponse(200, "The course was found", typeof(CourseResource))]
    public async Task<IActionResult> GetCourseById(int courseId)
    {
        var getCourseByIdQuery = new GetCourseByIdQuery(courseId);
        var course = await courseQueryService.Handle(getCourseByIdQuery);
        var resource = CourseResourceFromEntityAssembler.ToResourceFromEntity(course);
        return Ok(resource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all courses",
        Description = "Gets all courses",
        OperationId = "GetAllCourses")]
    [SwaggerResponse(200, "The courses were found", typeof(IEnumerable<CourseResource>))]
    public async Task<IActionResult> GetAllCourses()
    {
        var getAllCoursesQuery = new GetAllCoursesQuery();
        var courses = await courseQueryService.Handle(getAllCoursesQuery);
        var resources = courses.Select(CourseResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}