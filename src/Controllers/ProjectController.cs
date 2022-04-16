using Microsoft.AspNetCore.Mvc;
using SamsWebsite.BackEnd.Dto.Project;
using SamsWebsite.BackEnd.Model;
using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<EducationController> _logger;
        private readonly IRepository<Project> _projectRepository;

        public ProjectController(ILogger<EducationController> logger, IRepository<Project> projectRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAsync()
        {

            var educations = (await _projectRepository.GetAllAsync()).Select(education => education.AsProjectDto());

            return Ok(educations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) {
                BadRequest();
            }

            var education = await _projectRepository.GetAsync(id);

            if (education == null) {
                NotFound();
            }

            return Ok(education!.AsProjectDto());
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> PostAsync(CreateProjectDto projectToCreate)
        {
            if (projectToCreate == null) {
                return BadRequest();
            }

            var persistedProject = await _projectRepository.CreateAsync(
                new Project()
                {
                    EndDate = projectToCreate.EndDate > 0 ? DateTimeOffset.FromUnixTimeSeconds(projectToCreate.EndDate) : null,
                    StartDate = DateTimeOffset.FromUnixTimeSeconds(projectToCreate.StartDate),
                    Summaries = projectToCreate.Summaries,
                    ProjectName = projectToCreate.ProjectName,
                    ProjectRepositoryUrl = projectToCreate.ProjectRepositoryUrl
                }
            );

            if (persistedProject == null) {
                StatusCode(500);
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { Id = persistedProject!.Id }, persistedProject.AsProjectDto());
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) {
                BadRequest();
            }

            var projectToDelete = await _projectRepository.GetAsync(id);

            if (projectToDelete == null) {
                return NotFound();
            }

            await _projectRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}