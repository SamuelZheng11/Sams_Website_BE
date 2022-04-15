using Microsoft.AspNetCore.Mvc;
using SamsWebsite.BackEnd.Model.Education;
using SamsWebsite.BackEnd.Dto.Education;
using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class EducationController : ControllerBase
{
    private readonly ILogger<EducationController> _logger;
    private readonly IRepository<Education> _educationRepository;

    public EducationController(ILogger<EducationController> logger, IRepository<Education> educationRepository)
    {
        _logger = logger;
        _educationRepository = educationRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EducationDto>>> Get()
    {

        var educations = (await _educationRepository.GetAllAsync()).Select(education => education.AsEducationDto());

        return Ok(educations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EducationDto>> GetById(Guid id)
    {
        if (id.ToString() == null) {
            BadRequest();
        }

        var education = await _educationRepository.GetAsync(id);

        if (education == null) {
            NotFound();
        }

        return Ok(education!.AsEducationDto());
    }

    [HttpPost]
    public async Task<ActionResult<EducationDto>> Post(CreateEducation educationToCreate) {
        if (educationToCreate == null) {
            return BadRequest();
        }

        var item = new DateTime(educationToCreate.EndDate);

        var persistedEducation = await _educationRepository.CreateAsync(
            new Education()
            {
                Achievements = educationToCreate.Achievements,
                EndDate = educationToCreate.EndDate > 0 ? DateTimeOffset.FromUnixTimeSeconds(educationToCreate.EndDate) : null,
                StartDate = DateTimeOffset.FromUnixTimeSeconds(educationToCreate.StartDate),
                InstitutionName = educationToCreate.InstitutionName,
                InstitutionShortHand = educationToCreate.InstitutionShortHand,
                Summaries = educationToCreate.Summaries,
            }
        );

        return CreatedAtAction(nameof(Education), new { Id = persistedEducation.Id }, persistedEducation.AsEducationDto());
    }
}
