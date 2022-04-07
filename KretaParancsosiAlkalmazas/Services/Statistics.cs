using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Repositories;
using Kreta.Models;

namespace Kreta.Services
{
    public class Statistics
    {
        private SchoolClassesRepo schoolClassRepo;
        private StudentsRepo studentsRepo;
        private SubjectRepo subjectsRepo;

        public Statistics()
        {
            schoolClassRepo = new SchoolClassesRepo();
            studentsRepo = new StudentsRepo();
            subjectsRepo = new SubjectRepo();
        }

        public int GetNumberOfStudents()
        {
            return studentsRepo.Students.Count;
        }

        public Dictionary<string, int> GetStudentPerClasses()
        {
            // <"9.a" -> 12>
            Dictionary<string, int> studentPerClasses = new Dictionary<string, int>();
            foreach(SchoolClass schoolClass in schoolClassRepo.SchoolClasses)
            {
                // Az osztály id meghatározása
                int classId = schoolClass.Id;
                // Az adott osztály diákjainak száma
                int numberOfStuntInSchoolClass =
                    studentsRepo.Students.FindAll(student => student.Id == classId).Count;
                // Egy bejegyzés a dictionary
                studentPerClasses.Add(schoolClass.GradeGradeType, numberOfStuntInSchoolClass);
            }
            return studentPerClasses;
        }
    }
}
