using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Interfaces;
using Kreta.Repositories;
using Kreta.Repositories.Interfaces;

namespace Kreta.ViewModel
{
    public class TeacherViewModel
    {
        //private TeachersRepo teachersRepo;
        private ICRUDRepository<Teacher, KreataContext> teacherRepo;
       // private GenericTestRepository<Teacher> teachersRepo;
        private TeacherInMemoryDatabaseRepo<Teacher,KreataContext> teacherInMemoryTestRepo; 
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

            https://ogeek.cn/qa/?qa=585404/
            https://stackoverflow.com/questions/32249992/explicit-interface-and-generic-dynamic-type-conversion

                teacherInMemoryTestRepo = new TeacherInMemoryDatabaseRepo<Teacher, KreataContext>(context);
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
