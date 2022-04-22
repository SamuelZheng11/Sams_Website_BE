using Microsoft.AspNetCore.Mvc;
using SamsWebsite.BackEnd.Dto.Bio;
using SamsWebsite.BackEnd.Models;
using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BioController : ControllerBase
    {
        private readonly ILogger<BioController> _logger;
        private readonly IRepository<BioModel> _bioRepository;

        public BioController(ILogger<BioController> logger, IRepository<BioModel> bioRepository)
        {
            _logger = logger;
            _bioRepository = bioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BioDto>>> GetAsync()
        {

            var bios = (await _bioRepository.GetAllAsync()).Select(bio => bio.AsBioDto());

            return Ok(bios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BioDto>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) {
                BadRequest();
            }

            var bio = await _bioRepository.GetAsync(id);

            if (bio == null) {
                NotFound();
            }

            return Ok(bio!.AsBioDto());
        }

        [HttpPost]
        public async Task<ActionResult<BioDto>> PostAsync(CreateBioDto bioToCreate)
        {
            if (bioToCreate == null) {
                return BadRequest();
            }

            var persistedBio = await _bioRepository.CreateAsync(
                new BioModel()
                {
                    Id = Guid.NewGuid(),
                    AboutMe = bioToCreate.AboutMe,
                    Contact = bioToCreate.Contact != null ? new ContactModel
                    (
                        bioToCreate.Contact.GivenNames,
                        bioToCreate.Contact.Surname,
                        bioToCreate.Contact.Location,
                        bioToCreate.Contact.Email
                    )
                    {
                        GitHub = bioToCreate.Contact.GitHub,
                        LinkedIn = bioToCreate.Contact.LinkedIn,
                    } : null,
                    MaintenanceNote = bioToCreate.MaintenanceNote?.AsMaintenanceNoteModel(),
                }
            );

            if (persistedBio == null) {
                StatusCode(500);
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { Id = persistedBio!.Id }, persistedBio.AsBioDto());
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty) {
                BadRequest();
            }

            var bioToDelete = await _bioRepository.GetAsync(id);

            if (bioToDelete == null) {
                return NotFound();
            }

            await _bioRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}