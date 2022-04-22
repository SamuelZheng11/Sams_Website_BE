namespace SamsWebsite.BackEnd.Dto.Bio
{
    public class MaintenanceNoteDto
    {
        public Guid Id { get; set; }

        public string[]? Credits { get; set; }

        public string[]? Acknowledgments { get; set; }
    }
}