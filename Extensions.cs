using Sams_Website_BE.Model;
using Sams_Website_BE.Dto

namespace Sams_Website_BE
{
    public static class Extensions 
    {
        public static Education AsEducationModel(this EducationDto education) 
        {
            return new Education() {
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