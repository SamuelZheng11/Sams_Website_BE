using Microsoft.AspNetCore.Mvc;
using SamsWebsite.BackEnd.Dto.Project;
using SamsWebsite.BackEnd.Models;
using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IRepository<ProjectModel> _projectRepository;

        public ProjectController(ILogger<ProjectController> logger, IRepository<ProjectModel> projectRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAsync()
        {

            var projects = (await _projectRepository.GetAllAsync()).Select(project => project.AsProjectDto());

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) {
                BadRequest();
            }

            var project = await _projectRepository.GetAsync(id);

            if (project == null) {
                NotFound();
            }

            return Ok(project!.AsProjectDto());
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> PostAsync(CreateProjectDto projectToCreate)
        {
            if (projectToCreate == null) {
                return BadRequest();
            }

            var persistedProject = await _projectRepository.CreateAsync(
                new ProjectModel()
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