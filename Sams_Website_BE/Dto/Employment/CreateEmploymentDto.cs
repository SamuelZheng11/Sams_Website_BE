namespace SamsWebsite.BackEnd.Dto.Employment {
    public class CreateEmploymentDto
    {
        public long StartDate { get; set; }

        public long EndDate { get; set; }

        public string? Employer { get; set; }

        public string? EmployerWebsite { get; set; }

        public string[]? Summaries { get; set; }
    }
}
