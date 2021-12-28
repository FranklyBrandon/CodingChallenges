using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.DiagnosisRunner.DataAccess.Models
{
    public class MemberDiagnosticReport
    {
        private const string NotApplicable = "N/A";

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DiagnosisID { get; set; }
        public string DiagnosisDescription { get; set; }
        public int? DiagnosisCategoryID { get; set; }
        public string CategoryDescription { get; set; }
        public int? CategoryScore { get; set; }
        public bool IsMostSevereCategory { get; set; }

        public override string ToString()
        {
            string sanitaryDiagnosisId = DiagnosisID.HasValue ? DiagnosisID.Value.ToString() : NotApplicable;
            string sanitaryDiagnosisDescription = string.IsNullOrEmpty(DiagnosisDescription)? NotApplicable : DiagnosisDescription;
            string sanitaryDiagnosisCategoryId = DiagnosisCategoryID.HasValue ? DiagnosisCategoryID.Value.ToString() : NotApplicable;
            string sanitaryCategoryDescription = string.IsNullOrEmpty(CategoryDescription) ? NotApplicable : DiagnosisDescription;
            string sanitaryCategoryScore = CategoryScore.HasValue ? CategoryScore.Value.ToString() : NotApplicable;

            return $"First Name: {FirstName}, Last Name: {LastName}, Most Severe Diagnosis ID: {sanitaryDiagnosisId}," +
                $" Most Severe Diagnosis Description: {sanitaryDiagnosisDescription}, Category: {sanitaryDiagnosisCategoryId}," +
                $" Category Description: {sanitaryCategoryDescription}, Category Score: {sanitaryCategoryScore}, Is Most Severe Category?: {IsMostSevereCategory} ";
        }
    }
}
