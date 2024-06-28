using System.Linq;
using System.Threading.Tasks;
using CodePace.GetWork.API.Tutors.Application.Internal.CommandServices;
using CodePace.GetWork.API.Tutors.Application.Internal.QueryServices;
using CodePace.GetWork.API.Tutors.Domain.Model.Commands;
using CodePace.GetWork.API.Tutors.Domain.Model.Queries;
using CodePace.GetWork.API.Tutors.Interfaces.REST.Resources;
using CodePace.GetWork.API.Tutors.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using CodePace.GetWork.API.Tutors.Domain.Services;

namespace CodePace.GetWork.API.Tutors.Interfaces
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class TutorsController : ControllerBase
    {
        private readonly ITutorsCommandService _tutorsCommandService;
        private readonly ITutorsQueryService _tutorsQueryService;

        public TutorsController(ITutorsCommandService tutorsCommandService, ITutorsQueryService tutorsQueryService)
        {
            _tutorsCommandService = tutorsCommandService;
            _tutorsQueryService = tutorsQueryService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTutor([FromBody] CreateTutorsResource resource)
        {
            var createTutorsCommand = CreateTutorsSourceCommandFromResourceAssembler.ToCommandFromSource(resource);
            var tutor = await _tutorsCommandService.CreateTutorAsync(createTutorsCommand);
            return CreatedAtAction(nameof(GetTutorById), new { id = tutor.Id }, TutorsSourceResourceFromEntityAssembler.ToResourceFromEntity(tutor));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTutors()
        {
            var getAllTutorsQuery = new GetAllTutorsQuery();
            var result = await _tutorsQueryService.GetAllTutorsAsync(getAllTutorsQuery);
            var resources = result.Select(TutorsSourceResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTutorById(int id)
        {
            var getTutorByIdQuery = new GetTutorsByIdQuery(id);
            var result = await _tutorsQueryService.GetTutorByIdAsync(getTutorByIdQuery);
            if (result == null) return NotFound();
            var resource = TutorsSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
    }
}