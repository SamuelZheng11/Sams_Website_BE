using Microsoft.AspNetCore.Mvc;
using Sams_Website_BE;
using Sams_Website_BE.Model;
using Sams_Website_BE.Repository;

namespace Sams_Website_BE.Controllers;

[ApiController]
[Route("[controller]")]
public class EducationController : ControllerBase
{
    private readonly ILogger<EducationController> _logger;
    private readonly EducationRepository _educationRepository = new();
    private static readonly List<Education> _educations = new() {
        new Education() 
        {
            StartDate = new DateTime(1456657200),
            EndDate = new DateTime(1574161200),
            InstitutionName = "University of Auckland",
            InstitutionShortHand = "UoA",
            Summaries = new string[] {
                "In 2019 I graduated from the University of Auckland Specializing in Software Engineering.",
                "During my tenure I studied a variety of subjects ranging from operating systems, software design and architecture, mobile security, algorithm and data structures, software development methodologies, image processing and artificial intelligence"            },
            Achievements = new string[] {
                "Dean's Honours List class of 2019 (Top 5% of their year of study)",
                "First in class SOFTENG 762: Robotics Process Automation", "First Class Honours",
                "GPA of 7.3/9.0"
            },
        }
    };

    public EducationController(ILogger<EducationController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Education>>> Get()
    {
        var educations = (await _educationRepository.GetAllAsync())
                            .Select(education => education.AsEducationModel());
        return _educations;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Education>> GetById(Guid id)
    {
        if (id.ToString() == null) {
            BadRequest();
        }

        var education = await _educationRepository.GetAsync(id);

        if (education == null) {
            NotFound();
        }

        return Ok(education!.AsEducationModel());
    }
}
