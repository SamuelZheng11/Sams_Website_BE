using SamsWebsite.Common;

namespace SamsWebsite.BackEnd.Models
{
    public class ContactModel : IEntity
    {
        public ContactModel(string[] givenNames, string surname, string location, string email) : base()
        {
            GiveNames = givenNames;
            Surname = surname;
            Location = location;
            Email = email;
        }

        public Guid Id { get; set; }

        public string[] GiveNames { get; set; }

        public string Surname { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public string? GitHub { get; set; }
        
        public string? LinkedIn { get; set; }
    }
}