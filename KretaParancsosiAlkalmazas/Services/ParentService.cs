using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Relationship;
using Kreta.Repositories;
using Kreta.Repositories.Relationship;

namespace Kreta.Services
{
    public class ParentService
    {
        StudentsRepo studentsRepo;
        ParentsRepo parentsRepo;
        ParentOfStudentRepo parentOfStudentRepo;


        public ParentService()
        {
            studentsRepo = new StudentsRepo();
            parentsRepo = new ParentsRepo();
            parentOfStudentRepo = new ParentOfStudentRepo();
        }

        public List<Parent> GetAllParentsWithNoStudent()
        {
            List<Parent> parentsWithNoStudent = parentsRepo.GetAllParents();
            List<ParentOfStudent> parentsIdWithStudent = parentOfStudentRepo.ParentOfStudents;
            foreach (ParentOfStudent parentOfStudent in parentsIdWithStudent)
            {
                Parent parentToDelete = parentsRepo.Parents.Find(parent => parent.Id == parentOfStudent.ParentId);
                if (parentToDelete != null)
                    parentsWithNoStudent.Remove(parentToDelete);
            }
            return parentsWithNoStudent;

        }

        public List<Parent> GetParents(int studentId)
        {

            List<ParentOfStudent> findParents = parentOfStudentRepo.GetAllParentOfStudents().Where(x => x.StudentId == studentId).ToList();
            List<Parent> studentParent = parentsRepo.GetAllParents().Where(x => findParents.Any(p => p.ParentId == x.Id)).ToList();
            return studentParent;
        }


        public bool DeleteParent(int studentId, int parentId)
        {
            bool findStudent = parentOfStudentRepo.ParentOfStudents.Exists(x => x.StudentId == studentId && x.ParentId == parentId);
            if (!findStudent)
            {
                return false;
            }
            else
            {
                var deleteParent = parentOfStudentRepo.ParentOfStudents.Find(x => x.StudentId == studentId && x.ParentId == parentId);
                parentOfStudentRepo.ParentOfStudents.Remove(deleteParent);
                return true;
            }
        }

        public bool Delete(int parentId)
        {
            bool findParent = parentOfStudentRepo.ParentOfStudents.Exists(x => x.ParentId == parentId);

            if (!findParent)
            {
                var deleteParent = parentsRepo.Parents.Find(x => x.Id == parentId);
                parentsRepo.Parents.Remove(deleteParent);
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<Parent> GetMothers()
        {
            return parentsRepo.Parents.Where(x => x.Woomen = true).ToList();
        }


        public List<Parent> GetFathers()
        {
            return parentsRepo.Parents.Where(x => x.Woomen = false).ToList();
        }


        public List<Parent> GetParentsOfStudents()
        {
            return parentsRepo.Parents;
        }
    }
}
