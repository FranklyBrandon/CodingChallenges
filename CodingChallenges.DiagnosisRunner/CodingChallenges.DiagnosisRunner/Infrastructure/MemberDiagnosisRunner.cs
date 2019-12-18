using CodingChallenges.DiagnosisRunner.DataAccess;
using CodingChallenges.DiagnosisRunner.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges.DiagnosisRunner.Infrastructure
{
    public interface IRunner
    {
        public void Execute();
    }
    internal class MemberDiagnosisRunner : IRunner
    {
        private IDiagnosisRepository _repo;

        public MemberDiagnosisRunner()
        {
            _repo = new DiagnosisRepository();
        }
        public void Execute()
        {
            Console.WriteLine("Welcome to the Diagnosis Runner!");
            Console.WriteLine("Please enter a Member ID:");
            int memberId = ReadInput();
            List<MemberDiagnosticReport> reports = _repo.GetMemberDiagnosisReport(memberId);

            if (reports.Any())
            {
                Console.WriteLine($"{reports.Count} records for Member ID {memberId} reported:");
                foreach (var report in reports)
                {
                    Console.WriteLine(report);
                }
            }
            else
            {
                Console.WriteLine($"No reports returned for the supplied Member ID: {memberId}");
            }
        }

        private int ReadInput()
        {
            int? memberId = null;
            while (!memberId.HasValue)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out int memberIdParse))
                {
                    memberId = memberIdParse;
                }
                else
                {
                    Console.WriteLine("Invalid input, please provide a numeric Member Id");
                }
            }

            return memberId.Value;
        }
    }
}
