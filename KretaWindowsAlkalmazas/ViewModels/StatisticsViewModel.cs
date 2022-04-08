using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Services;
using System.Collections.ObjectModel;

namespace Kreta.ViewModels
{
    public class StatisticsViewModel
    {
        private Statistics statistics;

        public StatisticsViewModel()
        {
            this.statistics = new Statistics();
        }

        public string NumberOfStudents
        {
            get
            {
                string result = statistics.GetNumerOfStudenst() + " fő.";
                return result;
            }
        }

        public string NumberOfSubjects
        {
            get
            {
                string result = statistics.GetNumberOfSubjects() + " db.";
                return result;
            }
        }

        public string NumberOfClasses
        {
            get
            {
                string result = statistics.GetNumberOfClasses() + " db.";
                return result;
            }
        }

        public ObservableCollection<string> NumberOfStudentPerClass
        {
            get
            {
                ObservableCollection<string> numberOfStudentPerClass = new ObservableCollection<string>(DictionaryToList());
                return numberOfStudentPerClass;
            }
        }

        public ObservableCollection<string> TeachersNamePerClass
        {
            get
            {
                ObservableCollection<string> teachersNamePerClass = new ObservableCollection<string>(DictionaryToListTeacher());
                return teachersNamePerClass;
            }
        }

        private List<string> DictionaryToList()
        {
            Dictionary<string, int> dictionary = statistics.GetStudentPerClasses();
            List<string> numberOfStudentsPerClass = new List<string>();
            foreach (KeyValuePair<string, int> item in dictionary)
            {
                string result = item.Key + " osztály létszáma: " + item.Value + " fő";
                numberOfStudentsPerClass.Add(result);
            }
            return numberOfStudentsPerClass;
        }

        private List<string> DictionaryToListTeacher()
        {
            Dictionary<string, string> dictionary = statistics.GetTeacherPerClasses();
            List<string> teachersNamePerClass = new List<string>();
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                string result = item.Key + " Osztályfőnöke: " + item.Value;
                teachersNamePerClass.Add(result);
            }
            return teachersNamePerClass;
        }
    }
}
