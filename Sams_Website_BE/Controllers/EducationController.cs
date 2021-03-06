using Microsoft.AspNetCore.Mvc;
using SamsWebsite.BackEnd.Models;
using SamsWebsite.BackEnd.Dto.Education;
using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly ILogger<EducationController> _logger;
        private readonly IRepository<EducationModel> _educationRepository;

        public EducationController(ILogger<EducationController> logger, IRepository<EducationModel> educationRepository)
        {
            _logger = logger;
            _educationRepository = educationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationDto>>> GetAsync()
        {
            var educations = (await _educationRepository.GetAllAsync()).Select(education => education.AsEducationDto());

            return Ok(educations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationDto>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) {
                BadRequest();
            }

            var education = await _educationRepository.GetAsync(id);

            if (education == null) {
                NotFound();
            }

            return Ok(education!.AsEducationDto());
        }

        [HttpPost]
        public async Task<ActionResult<EducationDto>> PostAsync(CreateEducationDto educationToCreate) {
            if (educationToCreate == null) {
                return BadRequest();
            }

            var persistedEducation = await _educationRepository.CreateAsync(
                new EducationModel()
                {
                    Achievements = educationToCreate.Achievements,
                    EndDate = educationToCreate.EndDate > 0 ? DateTimeOffset.FromUnixTimeSeconds(educationToCreate.EndDate) : null,
                    StartDate = DateTimeOffset.FromUnixTimeSeconds(educationToCreate.StartDate),
                    InstitutionName = educationToCreate.InstitutionName,
                    InstitutionShortHand = educationToCreate.InstitutionShortHand,
                    InstitutionWebsite = educationToCreate.InstitutionWebsite,
                    Summaries = educationToCreate.Summaries,
                }
            );

            if (persistedEducation == null) {
                StatusCode(500);
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { Id = persistedEducation!.Id }, persistedEducation.AsEducationDto());
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) {
                BadRequest();
            }

            var educationtToDelete = await _educationRepository.GetAsync(id);

            if (educationtToDelete == null) {
                return NotFound();
            }

            await _educationRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}