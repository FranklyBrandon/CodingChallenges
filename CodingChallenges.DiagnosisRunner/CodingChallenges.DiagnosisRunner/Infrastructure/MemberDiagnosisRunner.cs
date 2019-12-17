using CodingChallenges.DiagnosisRunner.DataAccess;
using System;
using System.Collections.Generic;
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
            _repo.GetMemberDiagnosisReport(memberId);
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
