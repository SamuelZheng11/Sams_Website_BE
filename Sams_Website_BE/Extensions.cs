using SamsWebsite.BackEnd.Models;
using SamsWebsite.BackEnd.Dto.Education;
using SamsWebsite.BackEnd.Dto.Project;
using SamsWebsite.BackEnd.Dto.Bio;
using SamsWebsite.BackEnd.Dto.Employment;

namespace SamsWebsite.BackEnd
{
    public static class Extensions 
    {
        public static EducationDto AsEducationDto(this EducationModel education) 
        {
            return new EducationDto() {
                Id = education.Id,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                InstitutionName = education.InstitutionName,
                InstitutionShortHand = education.InstitutionShortHand,
                InstitutionWebsite = education.InstitutionWebsite,
                Achievements = education.Achievements,
                Summaries = education.Summaries,
            };
        }

        public static ProjectDto AsProjectDto(this ProjectModel project) 
        {
            return new ProjectDto() {
                Id = project.Id,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Summaries = project.Summaries,
                ProjectName = project.ProjectName,
                ProjectRepositoryUrl = project.ProjectRepositoryUrl,
            };
        }

        public static BioDto AsBioDto(this BioModel bio)
        {
            return new BioDto()
            {
                Id = bio.Id,
                AboutMe = bio.AboutMe,
                MaintenanceNote = bio.MaintenanceNote?.AsMaintenanceNoteDto(),
                Contact = bio.Contact?.AsContactDto(),
            };
        }

        public static ContactDto AsContactDto(this ContactModel contact)
        {
            return new ContactDto(contact.GiveNames, contact.Surname, contact.Location, contact.Email)
            {
                Id = contact.Id,
                GitHub = contact.GitHub,
                LinkedIn = contact.LinkedIn,
            };
        }

        public static MaintenanceNoteDto AsMaintenanceNoteDto(this MaintenanceNoteModel maintenanceNote)
        {
            return new MaintenanceNoteDto()
            {
                Credits = maintenanceNote.Credits,
                Acknowledgments = maintenanceNote.Acknowledgments,
            };
        }

        public static MaintenanceNoteModel AsMaintenanceNoteModel(this MaintenanceNoteDto maintenanceNote)
        {
            return new MaintenanceNoteModel()
            {
                Credits = maintenanceNote.Credits,
                Acknowledgments = maintenanceNote.Acknowledgments,
            };
        }

        public static EmploymentDto AsEmploymentDto(this EmploymentModel employment)
        {
            return new EmploymentDto()
            {
                Id = employment.Id,
                StartDate = employment.StartDate,
                EndDate = employment.EndDate,
                Employer = employment.Employer,
                EmployerWebsite = employment.EmployerWebsite,
                Summaries = employment.Summaries
            };
        }
    }
}