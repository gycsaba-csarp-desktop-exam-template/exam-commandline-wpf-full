using Kreta.Models;
using Kreta.Repositories;
using System;
using System.Collections.Generic;

namespace Kreta.Services
{
    public class StudentOfClassService
    {
        SchoolClassesRepo schoolClassesRepo;
        StudentsRepo studentsRepo;

        public StudentOfClassService()
        {
            schoolClassesRepo = new SchoolClassesRepo();
            studentsRepo = new StudentsRepo();
        }

        public List<SchoolClass> Classes
        {
            get
            {
                return schoolClassesRepo.SchoolClasses;
            }
        }

        public List<Student> GetStudentOfClass(int classId)
        {
            List<Student> result=studentsRepo.Students.FindAll(student => student.SchoolClassId == classId);
            result.Sort();
            return result;
        }

        public List<Student> GetStudentNoClass()
        {
            List<Student> result = studentsRepo.Students.FindAll(student => student.SchoolClassId == 0);
            result.Sort();
            return result;
        }

        public void AddStudentToClass(int studentId, int classId)
        {
            Student student = studentsRepo.Students.Find(student => student.Id == studentId);
            if (student != null)
                student.SchoolClassId = classId;
        }

        public void DeleteStudentFromClass(int studentId)
        {
            Student student = studentsRepo.Students.Find(student => student.Id == studentId);
            if (student != null)
                student.SchoolClassId = 0;
        }
    }
}
