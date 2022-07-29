using System;
using System.Configuration;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.EFClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

// https://code-maze.com/aspnetcore-multiple-databases-efcore/

namespace Kreta.Models.Context
{
    public partial class KretaContext : DbContext
    {
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<EFSubject> Subjects { get; set; }

        public KretaContext()
        {
        }

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
