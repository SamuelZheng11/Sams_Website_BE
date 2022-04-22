namespace SamsWebsite.BackEnd.Dto.Bio {
    public class ContactDto
    {
        public ContactDto(string[] givenNames, string surname, string location, string email)
        {
            GivenNames = givenNames;
            Surname = surname;
            Location = location;
            Email = email;
        }

        public Guid Id { get; set; }

        public string[] GivenNames { get; set; }

        public string Surname { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public string? GitHub { get; set; }

        public string? LinkedIn { get; set; }
    }
}