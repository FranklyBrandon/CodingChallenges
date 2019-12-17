using CodingChallenges.DiagnosisRunner.Infrastructure;

using System;

namespace CodingChallenges.DiagnosisRunner
{
    class Program
    {
        private static IRunner _runner;
        static void Main(string[] args)
        {
            _runner = new MemberDiagnosisRunner();
            _runner.Execute();
        }
    }
}
