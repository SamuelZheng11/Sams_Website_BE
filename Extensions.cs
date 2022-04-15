using SamsWebsite.BackEnd.Model.Education;
using SamsWebsite.BackEnd.Dto.Education;

namespace SamsWebsite.BackEnd
{
    public static class Extensions 
    {
        public static Education AsEducationModel(this EducationDto education) 
        {

            return new Education() 
            {
                Id = education.Id,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                InstitutionName = education.InstitutionName,
                InstitutionShortHand = education.InstitutionShortHand,
                Achievements = education.Achievements,
                Summaries = education.Summaries, 
            };
        }

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
    }
}