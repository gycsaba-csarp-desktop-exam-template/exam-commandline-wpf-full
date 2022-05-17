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
using Kreta.Repositories.BaseClass;

namespace Kreta.ViewModel
{
    public class TeacherViewModel
    {
        //private TeachersRepo teachersRepo;
        private IGenericRepository<Teacher> teacherRepo;
        TeachersTestRepo<Teacher> teacherTestRepo; 
        TeachersDatabaseRepo<Teacher, JKContext> teacherDatabaseRepo;


        private ObservableCollection<ITeacher> teachers;

        public TeacherViewModel()
        {
            bool test = true;
            var context = new JKContext();


            teacherTestRepo = new TeachersTestRepo<Teacher>();
            teacherDatabaseRepo = new TeachersDatabaseRepo<Teacher, JKContext>(context);

            if (test)
                teacherRepo = (IGenericRepository<Teacher>) teacherTestRepo;
            else
            {
                teacherRepo = (IGenericRepository<Teacher>) teacherDatabaseRepo;
                //(TeachersDatabaseRepo<TEntity, TContext>)teacherRepo = new TeachersDatabaseRepo<Teacher, JKContext>(context);
            }
                //teacherRepo = new GenericDatabaseRepository<Teacher, JKContext>(context);

            teachers = new ObservableCollection<ITeacher>(teacherRepo.GetAll());
        }

        public ObservableCollection<ITeacher> Teachers { get => teachers; set => teachers = value; }
    }
}
