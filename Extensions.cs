using SamsWebsite.BackEnd.Model;
using SamsWebsite.BackEnd.Dto.Education;
using SamsWebsite.BackEnd.Dto.Project;

namespace SamsWebsite.BackEnd
{
    public static class Extensions 
    {
        public static EducationDto AsEducationDto(this Education education) 
        {
            return new EducationDto() {
                Id = education.Id,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                InstitutionName = education.InstitutionName,
                InstitutionShortHand = education.InstitutionShortHand,
                Achievements = education.Achievements,
                Summaries = education.Summaries,
            };
        }

        public static ProjectDto AsProjectDto(this Project project) 
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
    }
}