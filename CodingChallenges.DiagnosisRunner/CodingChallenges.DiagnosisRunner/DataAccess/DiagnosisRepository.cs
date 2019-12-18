using System;
using System.Collections.Generic;
using System.Text;
using CodingChallenges.DiagnosisRunner.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenges.DiagnosisRunner.DataAccess
{
    public interface IDiagnosisRepository
    {
        List<MemberDiagnosticReport> GetMemberDiagnosisReport(int memberId);
    }

    public class DiagnosisRepository : IDiagnosisRepository
    {
        public List<MemberDiagnosticReport> GetMemberDiagnosisReport(int memberId)
        {      
            using (var context = new DiagnosisContext())
            {
                List<MemberDiagnosticReport> reports = context.MemberDiagnosticReports.FromSqlInterpolated($@"
                    select m.FirstName, m.LastName, ds.DiagnosisID, ds.DiagnosisDescription, dc.DiagnosisCategoryID, dc.CategoryDescription, dc.CategoryScore,
                    cast(case
                         when(dc2.DiagnosisCategoryID is not null or dc.DiagnosisCategoryID is null) then 1
                         else 0
                         end as bit) ""IsMostSevereCategory""
                    FROM dbo.Member m
                    --Minimum diagnosis Id into Alias d
                    LEFT JOIN
                    (
                        SELECT m.MemberId, dc.DiagnosisCategoryID, min(md.DiagnosisID) as DiagnosisId
                        FROM dbo.Member m
                        LEFT JOIN dbo.MemberDiagnosis md on md.MemberID = m.MemberID
                        LEFT JOIN dbo.DiagnosisCategoryMap dcm on dcm.DiagnosisID = md.DiagnosisID
                        LEFT join dbo.DiagnosisCategory dc on dc.DiagnosisCategoryID = dcm.DiagnosisCategoryID
                        GROUP BY m.MemberId, dc.DiagnosisCategoryID
                    ) d ON d.MemberId = m.MemberId
                    LEFT JOIN dbo.Diagnosis ds ON ds.DiagnosisId = d.DiagnosisId
                    LEFT JOIN dbo.DiagnosisCategoryMap dcm on dcm.DiagnosisID = d.DiagnosisID
                    LEFT JOIN dbo.DiagnosisCategory dc on dc.DiagnosisCategoryID = dcm.DiagnosisCategoryID
                    --Join on DiagnosisCategory again to find the min(DiagnosisCatgoryID) per member for case statement
                    LEFT JOIN dbo.DiagnosisCategory dc2 on dc2.DiagnosisCategoryID = dcm.DiagnosisCategoryID
                    AND dc2.DiagnosisCategoryID = (select min(dc3.DiagnosisCategoryID) from dbo.DiagnosisCategory dc3
                                                   JOIN dbo.DiagnosisCategoryMap dcm2 on dcm2.DiagnosisCategoryID = dc3.DiagnosisCategoryID
                                                   JOIN dbo.MemberDiagnosis md3 on md3.DiagnosisID = dcm2.DiagnosisID
                                                   where md3.MemberID = m.MemberID)
                    where m.MemberId = {memberId}
                    group by m.FirstName, m.LastName, ds.DiagnosisID, ds.DiagnosisDescription, dc.DiagnosisCategoryID, dc.CategoryDescription, dc.CategoryScore, dc.DiagnosisCategoryID, dc2.DiagnosisCategoryID"
            ).ToListAsync().Result;

                return reports;
            }
        }
    }
}
