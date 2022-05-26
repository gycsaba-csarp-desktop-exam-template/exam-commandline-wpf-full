using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Kreta.Models
{
    public partial class KreataContext : DbContext
    {
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
