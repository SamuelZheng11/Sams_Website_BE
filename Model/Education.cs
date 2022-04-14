namespace Sams_Website_BE.Model;

public class Education
{
    public Guid Id = Guid.NewGuid();

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? InstitutionName { get; set; }

    public string? InstitutionShortHand { get; set; }

    public string[]? Summaries { get; set; }

    public string[]? Achievements { get; set; }
}
