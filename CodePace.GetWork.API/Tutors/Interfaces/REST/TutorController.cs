namespace DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class TutorsController : ControllerBase
{
    private readonly TutorCommandService _commandService;
    private readonly TutorQueryService _queryService;

    public TutorsController(TutorCommandService commandService, TutorQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    // GET: api/tutors
    [HttpGet]
    public ActionResult<IEnumerable<Tutor>> GetTutors()
    {
        var tutors = _queryService.GetTutors();
        return Ok(tutors);
    }

    // GET: api/tutors/{id}
    [HttpGet("{id}")]
    public ActionResult<Tutor> GetTutor(int id)
    {
        var tutor = _queryService.GetTutorById(id);
        if (tutor == null)
        {
            return NotFound();
        }
        return Ok(tutor);
    }

    // POST: api/tutors
    [HttpPost]
    public ActionResult<Tutor> PostTutor(CreateTutorCommand command)
    {
        _commandService.Handle(command);
        return CreatedAtAction(nameof(GetTutors), new { id = command.Name }, command);
    }
}