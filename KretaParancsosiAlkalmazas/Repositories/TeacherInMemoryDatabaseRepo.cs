using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Interfaces;
using Kreta.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Repositories
{
    public class TeacherInMemoryDatabaseRepo<TEntity, TContext> : ICRUDRepository<ITeacher, KreataContext>
    {
        public TeacherInMemoryDatabaseRepo(KreataContext context) : 
            base(context)
        {
            this.context = context;
            var builder = new DbContextOptionsBuilder<KreataContext>();
            builder.UseInMemoryDatabase(databaseName: "KreataTest");
            var options = builder.Options;

            var teachers = new List<Teacher>();

            teachers.Add(new Teacher(1, "Számoló", "Szonja", true, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(2, "Buktató", "Béla", false, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(3, "Aritmetika", "Antal", false, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(4, "Arany", "András", false, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(5, "Sportoló", "Jenő", false, new DateTime(1974, 10, 24)));
            teachers.Add(new Teacher(6, "Visszanéző", "Viola", true, new DateTime(1974, 10, 24)));

            context.AddRange(teachers);           
            context.SaveChanges();
        }
    }
}
