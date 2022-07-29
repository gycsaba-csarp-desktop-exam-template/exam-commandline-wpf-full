using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kreta.Models.Relationship;
using Kreta.Repositories;
using Kreta.Repositories.Relationship;
using KretaParancssoriAlkalmazas.Models.DataModel;

namespace Kreta.Services
{
    public class ParentService
    {
        StudentsRepo studentsRepo;
        ParentsRepo parentsRepo;
        ParentOfStudentRepo parentOfStudentRepo;

        public int NumberOfParents
        {
            get
            {
                return parentsRepo.GetAllParents().Count;
            }
        }

        public int NumberOfWomen
        {
            get
            {
                int result = parentsRepo.GetAllParents().Where(parents => parents.Wooman == true).Count();
                return result;
            }
        }

        public int NumberOfMan
        {
            get
            {
                int result = parentsRepo.GetAllParents().Where(parents => parents.Wooman == false).Count();
                return result;
            }
        }

        public ParentService()
        {
            studentsRepo = new StudentsRepo();
            parentsRepo = new ParentsRepo();
            parentOfStudentRepo = new ParentOfStudentRepo();
        }


        public List<Student> GetAllStudents()
        {
            return new List<Student>(studentsRepo.GetAllStudents());
        }
        public List<Parent> GetAllParents()
        {
            return new List<Parent>(parentsRepo.GetAllParents());
        }

        public List<Parent> GetAllParentsWithNoStudent()
        {
            List<Parent> parentsWithNoStudent = parentsRepo.GetAllParents();
            List<ParentOfStudent> parentsIdWithStudent = parentOfStudentRepo.GetAllParentOfStudents();
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
                var deleteParent = parentsRepo.GetAllParents().Find(x => x.Id == parentId);
                parentsRepo.Parents.Remove(deleteParent);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteParent(int id)
        {
            parentsRepo.DeleteParent(id);
        }


        public List<Parent> GetMothers()
        {
            return parentsRepo.GetAllParents().Where(x => x.Wooman == true).ToList();
        }


        public List<Parent> GetFathers()
        {
            return parentsRepo.GetAllParents().Where(x => x.Wooman == false).ToList();
        }


        public List<Parent> GetParentsOfStudents()
        {
            return parentsRepo.GetAllParents();
        }
    }
}
