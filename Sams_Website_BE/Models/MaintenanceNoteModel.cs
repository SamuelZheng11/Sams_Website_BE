using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Models
{
    public class MaintenanceNoteModel : IEntity
    {
        public Guid Id { get; set; }

        public string[]? Credits { get; set; }

        public string[]? Acknowledgments { get; set; }
    }
}