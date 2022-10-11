using System;
using System.Configuration;
using Kreta.Models.DataModel;
using Kreta.Models.EFClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

// https://code-maze.com/aspnetcore-multiple-databases-efcore/

namespace Kreta.Models.Context
{
    public partial class KretaContext : DbContext
    {
        public DbSet<EFSchoolClass> SchoolClasses { get; set; }
        public DbSet<EFSubject> Subjects { get; set; }

        /*public KretaContext()
        {
        }*/

        public KretaContext(DbContextOptions<KretaContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
