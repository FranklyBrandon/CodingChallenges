select m.FirstName, m.LastName, d.DiagnosisID as "Most Severe Diagnosis ID", d.DiagnosisDescription as "Most Severe Diagnosis Description", dc.DiagnosisCategoryID as "Category ID", dc.CategoryDescription as "Category Description", dc.CategoryScore as "Category Score",
cast(case 
     when (dc2.DiagnosisCategoryID is not null or dc.DiagnosisCategoryID is null) then 1
	 else 0
	 end as bit) as "Is Most Severe Category"
from dbo.Member m
--Join on MemberDiagnosis using a subquery that returns the min(DiagnosisID) per member to find the 'Most Severe Diagnosis'
left join dbo.MemberDiagnosis md on md.MemberID = m.MemberID
and md.DiagnosisID =
    (select min(md2.DiagnosisID) from dbo.MemberDiagnosis md2
     where md2.MemberID = md.MemberID)
--Join on MemberDiagnosis again to accomodate all Member/Category combinations
left join dbo.MemberDiagnosis md2 on md2.MemberID = m.MemberID
--Join Diagnosis on md and not md2 to obtain the most severe diagnosis in the 'd' alias
left join dbo.Diagnosis d on d.DiagnosisID = md.DiagnosisID
left join dbo.DiagnosisCategoryMap dcm on dcm.DiagnosisID = md2.DiagnosisID
left join dbo.DiagnosisCategory dc on dc.DiagnosisCategoryID = dcm.DiagnosisCategoryID
--Join on DiagnosisCategory again to find the min(DiagnosisCatgoryID) per member
left join dbo.DiagnosisCategory dc2 on dc2.DiagnosisCategoryID = dcm.DiagnosisCategoryID
and dc2.CategoryDescription = (select min(dc3.CategoryDescription) from dbo.DiagnosisCategory dc3
                               join dbo.DiagnosisCategoryMap dcm2 on dcm2.DiagnosisCategoryID = dc3.DiagnosisCategoryID
                               join dbo.MemberDiagnosis md3 on md3.DiagnosisID = dcm2.DiagnosisID
                               where md3.MemberID = m.MemberID)
--Group by to show distinct member/category combinations
group by m.FirstName, m.LastName, d.DiagnosisID, d.DiagnosisDescription, dc.DiagnosisCategoryID, dc.CategoryDescription, dc.CategoryScore, dc2.DiagnosisCategoryID
