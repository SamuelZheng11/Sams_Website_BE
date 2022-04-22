using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Models
{
    public class BioModel : IEntity
    {
        public Guid Id { get; set; }

        public ContactModel? Contact { get; set; }

        public string? AboutMe { get; set; }

        public MaintenanceNoteModel? MaintenanceNote { get; set; }
    }
}