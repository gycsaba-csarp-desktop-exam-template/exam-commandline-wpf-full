using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

// https://code-maze.com/aspnetcore-multiple-databases-efcore/

namespace Kreta.Models.Context
{
    public partial class KreataContext : DbContext
    {
        public DbSet<Teacher> teachers { get; set; }

        public KreataContext()
        {
        }

        public KreataContext(DbContextOptions<KreataContext> options)
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
