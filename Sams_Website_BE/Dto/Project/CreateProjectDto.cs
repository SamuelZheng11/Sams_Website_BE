namespace SamsWebsite.BackEnd.Dto.Project {
    public class CreateProjectDto
    {
        public long StartDate { get; set; }

        public long EndDate { get; set; }

        public string? ProjectName { get; set; }

        public string? ProjectRepositoryUrl { get; set; }

        public string[]? Summaries { get; set; }
    }
}
