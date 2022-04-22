using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Models
{
    public class EmploymentModel : IEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string? Employer { get; set; }

        public string? EmployerWebsite { get; set; }

        public string[]? Summaries { get; set; }
    }
}