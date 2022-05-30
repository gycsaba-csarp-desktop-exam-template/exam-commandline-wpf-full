using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Context;
using Kreta.Models.Interfaces;
using Kreta.Repositories;
using Kreta.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kreta.ViewModel
{
    public class TeacherViewModel
    {

        private KreataContext kreataContext;
        private ICRUDRepository<Teacher, DbContext> teacherRepo;
        private TeacherInMemoryDatabaseRepo<Teacher, DbContext> teacherInMemoryTestRepo; 
        private TeacherDatabaseRepo<Teacher, KreataContext> teacherDatabaseRepo;


        private ObservableCollection<ITeacher> teachers;

        public TeacherViewModel()
        {
            bool test = true;
            var context = new KreataContext();






            if (test)
            {
            // c# multiple repositories test database
            //https://stackoverflow.com/questions/5502019/how-to-set-up-an-in-memory-repository

                teacherInMemoryTestRepo = new TeacherInMemoryDatabaseRepo<Teacher, DbContext>(context);
                teacherRepo = (ICRUDRepository<Teacher,KreataContext>) teacherInMemoryTestRepo;
            }
                
            else
            {
               // teacherDatabaseRepo = new TeacherDatabaseRepo<Teacher, KreataContext>(context);
                //teacherRepo = (IGenericRepository<Teacher>) teacherDatabaseRepo;
                //(TeachersDatabaseRepo<TEntity, TContext>)teacherRepo = new TeachersDatabaseRepo<Teacher, JKContext>(context);
            }
                //teacherRepo = new GenericDatabaseRepository<Teacher, JKContext>(context);

            teachers = new ObservableCollection<ITeacher>(teacherRepo.GetAll());
        }

        public ObservableCollection<ITeacher> Teachers { get => teachers; set => teachers = value; }
    }
}
