using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Models.Context
{
    class KretaInMemoryContext : DbContext
    {
        public KretaInMemoryContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Teacher> teachers { get; set; }
    }
}
