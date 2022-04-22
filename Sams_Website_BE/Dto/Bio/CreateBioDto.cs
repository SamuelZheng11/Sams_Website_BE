namespace SamsWebsite.BackEnd.Dto.Bio {
    public class CreateBioDto
    {
        public ContactDto? Contact { get; set; }

        public string? AboutMe { get; set; }

        public MaintenanceNoteDto? MaintenanceNote { get; set; }
    }
}
