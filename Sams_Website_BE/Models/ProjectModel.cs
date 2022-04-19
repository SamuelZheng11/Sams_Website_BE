using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Models
{
    public class ProjectModel : IEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string? ProjectName { get; set; }

        public string? ProjectRepositoryUrl { get; set; }

        public string[]? Summaries { get; set; }
    }
}