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
        private ClassesRepo classesRepo;
        private StudentsRepo studentsRepo;
        private SubjectRepo subjectsRepo;

        public Statistics()
        {
            classesRepo = new ClassesRepo();
            studentsRepo = new StudentsRepo();
            subjectsRepo = new SubjectRepo();
        }

        public int GetNumberOfStudents()
        {
            return studentsRepo.Studentss.Count;
        }

        public Dictionary<string, int> GetStudentPerClasses()
        {
            // <"9.a" -> 12>
            Dictionary<string, int> studentPerClasses = new Dictionary<string, int>();
            foreach(Class schoolClass in classesRepo.Classes)
            {
                // Az osztály id meghatározása
                int classId = schoolClass.Id;
                // Az adott osztály diákjainak száma
                int numberOfStuntInSchoolClass =
                    studentsRepo.Studentss.FindAll(student => student.Id == classId).Count;
                // Egy bejegyzés a dictionary
                studentPerClasses.Add(schoolClass.GradeGradeType, numberOfStuntInSchoolClass);
            }
            return studentPerClasses;
        }
    }
}
