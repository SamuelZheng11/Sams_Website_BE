namespace SamsWebsite.BackEnd.Dto.Education {
    public class EducationDto
    {
        public Guid Id { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string? InstitutionName { get; set; }

        public string? InstitutionShortHand { get; set; }

        public string? InstitutionWebsite { get; set; }

        public string[]? Summaries { get; set; }

        public string[]? Achievements { get; set; }
    }
}