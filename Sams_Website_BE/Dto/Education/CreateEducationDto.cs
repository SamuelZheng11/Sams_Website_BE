namespace SamsWebsite.BackEnd.Dto.Education {
    public class CreateEducationDto
    {
        public long StartDate { get; set; }

        public long EndDate { get; set; }

        public string? InstitutionName { get; set; }

        public string? InstitutionShortHand { get; set; }

        public string[]? Summaries { get; set; }

        public string[]? Achievements { get; set; }
    }
}
