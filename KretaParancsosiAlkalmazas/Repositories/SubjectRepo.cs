using Kreta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Repositories
{
    public class SubjectRepo
    {
        private List<Subject> subjects;
        public List<Subject> Subjects { get => subjects; }

        public int NumberOfSubjects
        {
            get
            {
                return subjects.Count;
            }
        }

        public SubjectRepo()
        {
            subjects = new List<Subject>();
            MakeTestData();
        }

        public void MakeTestData()
        {

            subjects.Add(new Subject(1,"Informatika"));
            subjects.Add(new Subject(2,"Angol"));
            subjects.Add(new Subject(3,"Matematika"));
            subjects.Add(new Subject(4,"Fizika"));
            subjects.Add(new Subject(5,"Testnevelés"));
            subjects.Add(new Subject(6,"Történelem"));
            subjects.Add(new Subject(7,"Magyar nyelv és Irodalom"));
        }

        public Subject GetSubject(int subjectID)
        {
            return subjects.Find(s => s.Id == subjectID);
        }
    }
}
