namespace SamsWebsite.BackEnd.Dto.Bio {
    public class BioDto
    {
        public Guid Id { get; set; }

        public ContactDto? Contact { get; set; }

        public string? AboutMe { get; set; }

        public MaintenanceNoteDto? MaintenanceNote { get; set; }
    }
}