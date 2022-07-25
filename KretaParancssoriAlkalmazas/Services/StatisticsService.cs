using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Repositories;
using Kreta.Models;
using Kreta.Models.Interfaces;

namespace Kreta.Services
{
      public class StatisticsService
      {
        /*  private SchoolClassesRepo  schoolClassesRepo;
          private StudentsRepo studentsRepo;
          private SubjectRepo subjectRepo;
          private TeacherTestRepoRepo<Teacher> teachersRepo;

          public StatisticsService()
          {
              schoolClassesRepo = new SchoolClassesRepo();
              studentsRepo = new StudentsRepo();
              subjectRepo = new SubjectRepo();
              teachersRepo = new TeacherTestRepoRepo<Teacher>();
          }


          public int NumerOfStudenst
          {
              get
              {
                  return studentsRepo.NumberOfStudents;
              }
          }

          public int NumberOfClasses
          {
              get
              {
                  return schoolClassesRepo.NumberOfClasses;
              }
          }

          public int NumberOfSubjects
          {
              get
              {
                  return subjectRepo.NumberOfSubjects;
              }
          }


          public Dictionary<string, long> GetStudentPerClasses()
          {
              Dictionary<string, long> studentPerClasses = new Dictionary<string, long>();
              foreach (SchoolClass schoolClass in schoolClassesRepo.SchoolClasses)
              {
                  // Az osztály id meghatározása
                  long classId = schoolClass.Id;

                  //az adott osztály diákjainak a száma
                  int numberOfStudentsInSchoolClass = studentsRepo.Students.FindAll(student => student.SchoolClassId == classId).Count;

                  // Egy bejegyzés a Dictionary-be
                  studentPerClasses.Add(schoolClass.GradeGradeType, numberOfStudentsInSchoolClass);
              }

              return studentPerClasses;
          }

          public Dictionary<string, string> GetTeacherPerClasses()
          {
              Dictionary<string, string> teacherPerClasses = new Dictionary<string, string>();

              foreach (SchoolClass schoolClass in schoolClassesRepo.SchoolClasses)
              {
                  int classId = schoolClass.TeacherId;
                  string teacherOfClass = teachersRepo.GetAllTeachers().Where(teacher => teacher.Id == classId).Select(teacher =>teacher.FullName).SingleOrDefault();
                  teacherPerClasses.Add(schoolClass.GradeGradeType, teacherOfClass);

              }
              return teacherPerClasses;
          }*/
    }
}
