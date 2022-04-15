namespace Sams_Website_BE.Model.Education {
    public class CreateEducation
    {
        public long StartDate { get; set; }

        public long EndDate { get; set; }

        public string? InstitutionName { get; set; }

        public string? InstitutionShortHand { get; set; }

        public string[]? Summaries { get; set; }

        public string[]? Achievements { get; set; }
    }
}
