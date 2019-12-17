using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.DiagnosisRunner.DataAccess.Models
{
    public class MemberDiagnosticReport
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DiagnosisID { get; set; }
        public string DiagnosisDescription { get; set; }
        public int? DiagnosisCategoryID { get; set; }
        public string CategoryDescription { get; set; }
        public int? CategoryScore { get; set; }
        public bool IsMostSevereCategory { get; set; }
    }
}
