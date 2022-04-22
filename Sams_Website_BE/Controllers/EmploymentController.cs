using Microsoft.AspNetCore.Mvc;
using SamsWebsite.BackEnd.Models;
using SamsWebsite.BackEnd.Dto.Employment;
using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class EmploymentController : ControllerBase
    {
        private readonly ILogger<EmploymentController> _logger;
        private readonly IRepository<EmploymentModel> _employmentRepository;

        public EmploymentController(ILogger<EmploymentController> logger, IRepository<EmploymentModel> employmentRepository)
        {
            _logger = logger;
            _employmentRepository = employmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentDto>>> GetAsync()
        {
            var employments = (await _employmentRepository.GetAllAsync())
                                .OrderByDescending(x => x.StartDate.ToUnixTimeSeconds())
                                .Select(employment => employment.AsEmploymentDto());

            return Ok(employments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentDto>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) {
                BadRequest();
            }

            var employment = await _employmentRepository.GetAsync(id);

            if (employment == null) {
                NotFound();
            }

            return Ok(employment!.AsEmploymentDto());
        }

        [HttpPost]
        public async Task<ActionResult<EmploymentDto>> PostAsync(CreateEmploymentDto employmentToCreate) {
            if (employmentToCreate == null) {
                return BadRequest();
            }

            var persistedEmployment = await _employmentRepository.CreateAsync(
                new EmploymentModel()
                {
                    EndDate = employmentToCreate.EndDate > 0 ? DateTimeOffset.FromUnixTimeSeconds(employmentToCreate.EndDate) : null,
                    StartDate = DateTimeOffset.FromUnixTimeSeconds(employmentToCreate.StartDate),
                    Employer = employmentToCreate.Employer,
                    EmployerWebsite = employmentToCreate.EmployerWebsite,
                    Summaries = employmentToCreate.Summaries,
                }
            );

            if (persistedEmployment == null) {
                StatusCode(500);
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { Id = persistedEmployment!.Id }, persistedEmployment.AsEmploymentDto());
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) {
                BadRequest();
            }

            var employmenttToDelete = await _employmentRepository.GetAsync(id);

            if (employmenttToDelete == null) {
                return NotFound();
            }

            await _employmentRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}