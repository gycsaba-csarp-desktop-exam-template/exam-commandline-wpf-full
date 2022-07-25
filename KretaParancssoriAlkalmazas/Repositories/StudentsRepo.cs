using Kreta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Repositories
{
    public class StudentsRepo
    {
        private List<Student> students;
        public List<Student> Students { get => students; }
        public int NumberOfStudents
        {
            get
            {
                return students.Count;
            }
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>(students);
        }

        public StudentsRepo()
        {
            students = new List<Student>();
            MakeTestData();
        }  
        public void MakeTestData()
        {
            students.Add(new Student(1,"Kis","Zoltán", false, new DateTime(2004, 10, 24),1));
            students.Add(new Student(2,"Nagy","Anna", true, new DateTime(2003, 3, 2), 1));
            students.Add(new Student(3,"Szabó", "Imre", false, new DateTime(2004, 7, 4), 3));
            students.Add(new Student(4, "Péter","Zoltán", false, new DateTime(2003, 9, 9), 4));
            students.Add(new Student(5, "Ávra", "Virág", true, new DateTime(2004, 2, 24), 1));
            students.Add(new Student(6, "Zolyom", "Rebeka", true, new DateTime(2004, 10, 24), 2));
            students.Add(new Student(7, "Varga", "Aladár", false, new DateTime(2003, 4, 16), 3));
            students.Add(new Student(8, "Nyugvó", "Roland", false, new DateTime(2003, 11, 24), 1));
            students.Add(new Student(9, "Nyugvó", "Roland", false, new DateTime(2004, 2, 3), 1));
            students.Add(new Student(10, "Marakodó","Melinda", true, new DateTime(2004, 5, 25), 2));
            students.Add(new Student(11, "Jobbágy", "Rita", true, new DateTime(2004, 7, 4), 4));
            students.Add(new Student(12, "Nagy", "Virág", true, new DateTime(2003, 2, 4), 4));
            students.Add(new Student(13, "Tanuló", "Péter", false, new DateTime(2003, 12, 31), 0));
            students.Add(new Student(14, "Nagy","Lajos", false, new DateTime(2004, 1, 14), 0));
            students.Add(new Student(15, "Péter", "László", false, new DateTime(2003, 1, 12), 0));
        }
    }
}

