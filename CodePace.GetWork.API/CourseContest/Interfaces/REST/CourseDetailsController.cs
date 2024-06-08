using System.Net.Mime;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;
using CodePace.GetWork.API.CourseContest.Domain.Services;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST;

[ApiController]
[Route("/api/v1/courses/{courseId}/details")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Courses")]
public class CourseDetailsController(ICourseDetailQueryService courseDetailQueryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCourseDetailsByCourseId([FromRoute] int courseId)
    {
        var getAllCourseDetailsByCourseIdQuery = new GetAllCourseDetailsByCourseIdQuery(courseId);
        var courseDetails = await courseDetailQueryService.Handle(getAllCourseDetailsByCourseIdQuery);
        var resources = courseDetails.Select(CourseDetailResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}