namespace SamsWebsite.BackEnd.Dto.Employment
{
    public class EmploymentDto
    {
        public Guid Id { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string? Employer { get; set; }

        public string? EmployerWebsite { get; set; }

        public string[]? Summaries { get; set; }
    }
}