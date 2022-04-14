namespace Sams_Website_BE.Dto {
    public class EducationDto
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? InstitutionName { get; set; }

        public string? InstitutionShortHand { get; set; }

        public string[]? Summaries { get; set; }

        public string[]? Achievements { get; set; }
    }
}