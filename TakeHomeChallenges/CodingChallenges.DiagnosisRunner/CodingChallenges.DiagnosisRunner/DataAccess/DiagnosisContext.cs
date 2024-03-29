﻿using CodingChallenges.DiagnosisRunner.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.DiagnosisRunner.DataAccess
{
    public class DiagnosisContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("My test database");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasNoKey();
            modelBuilder.Entity<MemberDiagnosticReport>().HasNoKey();
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<MemberDiagnosticReport> MemberDiagnosticReports { get; set; }
    }
}
