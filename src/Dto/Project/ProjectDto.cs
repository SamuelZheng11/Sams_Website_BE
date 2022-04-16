namespace SamsWebsite.BackEnd.Dto.Project {
    public class ProjectDto
    {
        public Guid Id { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string? ProjectName { get; set; }

        public string? ProjectRepositoryUrl { get; set; }

        public string[]? Summaries { get; set; }
    }
}