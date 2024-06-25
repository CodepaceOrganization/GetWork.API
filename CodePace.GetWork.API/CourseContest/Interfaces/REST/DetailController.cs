using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Services;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DetailController(IDetailCommandService detailCommandService, IDetailQueryService detailQueryService)
        : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCourseDetail([FromBody] CreateCourseDetailResource createCourseDetailResource)
        {
            var createCourseDetailCommand = CreateCourseDetailCommandFromResourceAssembler.ToCommandFromResource(createCourseDetailResource);
            var courseDetail = await detailCommandService.Handle(createCourseDetailCommand);
            if (courseDetail is null) return BadRequest();
            var resource = CourseDetailResourceFromEntityAssembler.ToResourceFromEntity(courseDetail);
            return CreatedAtAction(nameof(GetCourseDetailById), new { courseDetailId = resource.Id }, resource);
        }

        [HttpGet("{courseDetailId}")]
        public async Task<IActionResult> GetCourseDetailById(int courseDetailId)
        {
            var courseDetail = await detailQueryService.Handle(new GetCourseDetailByIdQuery(courseDetailId));
            if (courseDetail == null) return NotFound();
            var resource = CourseDetailResourceFromEntityAssembler.ToResourceFromEntity(courseDetail);
            return Ok(resource);
        }

        [HttpPut("{courseDetailId}")]
        public async Task<IActionResult> UpdateCourseDetail(int courseDetailId, [FromBody] UpdateCourseDetailResource updateCourseDetailResource)
        {
            var updateCourseDetailCommand = UpdateCourseDetailCommandFromResourceAssembler.ToCommandFromResource(updateCourseDetailResource);
            var updatedCourseDetail = await detailCommandService.Handle(updateCourseDetailCommand);
            if (updatedCourseDetail == null) return NotFound();
            var resource = CourseDetailResourceFromEntityAssembler.ToResourceFromEntity(updatedCourseDetail);
            return Ok(resource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourseDetails()
        {
            var courseDetails = await detailQueryService.Handle(new GetAllCourseDetailQuery());
            var resources = courseDetails.Select(CourseDetailResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}