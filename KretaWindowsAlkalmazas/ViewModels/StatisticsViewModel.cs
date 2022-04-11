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
        private StatisticsService statisticsService;

        public StatisticsViewModel()
        {
            this.statisticsService = new StatisticsService();
        }

        public string NumberOfStudents
        {
            get
            {
                string result = " "+statisticsService.NumerOfStudenst + " fő.";
                return result;
            }
        }

        public string NumberOfSubjects
        {
            get
            {
                string result = " " + statisticsService.NumberOfSubjects + " db.";
                return result;
            }
        }

        public string NumberOfClasses
        {
            get
            {
                string result = " " + statisticsService.NumberOfClasses + " db.";
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
            Dictionary<string, int> dictionary = statisticsService.GetStudentPerClasses();
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
            Dictionary<string, string> dictionary = statisticsService.GetTeacherPerClasses();
            List<string> teachersNamePerClass = new List<string>();
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                string result = item.Key + ": " + item.Value;
                teachersNamePerClass.Add(result);
            }
            return teachersNamePerClass;
        }
    }
}
