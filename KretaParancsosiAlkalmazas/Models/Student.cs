using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Interfaces;

namespace Kreta.Models
{
    public class Student : IStudent
    {
        public int StudentId { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Wooman { get; set; }
        public DateTime DataOfBirth { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
        public int PostCode { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int SchoolClassId { get; set; }


        public Student()
        {
            Id = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            Wooman = false;
            DataOfBirth = DateTime.MinValue;
            City = string.Empty;
            StreetAndNumber = string.Empty;
            PostCode = -1;
            LoginName = string.Empty;
            Password = string.Empty;
            SchoolClassId = -1;
        }

        public Student(int id, string firstName, string lastName, bool wooman, DateTime dataOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Wooman = wooman;
            DataOfBirth = dataOfBirth;
            City = string.Empty;
            StreetAndNumber = string.Empty;
            PostCode = -1;
            LoginName = string.Empty;
            Password = string.Empty;
            SchoolClassId = -1;
        }

        public Student(int id, string firstName, string lastName, bool wooman, DateTime dataOfBirth, int schoolClassId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Wooman = wooman;
            DataOfBirth = dataOfBirth;
            City = string.Empty;
            StreetAndNumber = string.Empty;
            PostCode = -1;
            LoginName = string.Empty;
            Password = string.Empty;
            SchoolClassId = schoolClassId;
        }

        public Student(int id, string firstName, string lastName, bool wooman, DateTime dataOfBirth, string city, string streetAndNumber, int postCode, string loginName, string password, int schoolClassId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Wooman = wooman;
            DataOfBirth = dataOfBirth;
            City = city;
            StreetAndNumber = streetAndNumber;
            PostCode = postCode;
            LoginName = loginName;
            Password = password;
            SchoolClassId = schoolClassId;
        }

        private IStudent GetInterfaceObject
        {
            get { return (IStudent) this; }
        }

        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                IStudent other = (Student) obj;
                int fullNameCompareResult = this.GetInterfaceObject.FullName.CompareTo(other.FullName);
                if (fullNameCompareResult == 0)
                {
                    if (this.Id == other.Id)
                    {
                        return 0;
                    }
                    else if (this.Id < other.Id)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return fullNameCompareResult;
                }
            }
            else
            {
                return 0;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Student || obj is IStudent)
            {
                IStudent other = (Student) obj;
                Student otherStudent = (Student) obj;
                int fullNameCompareResult = this.GetInterfaceObject.FullName.CompareTo(other.FullName);
                if (fullNameCompareResult != 0)
                    return false;
                else if ((this.Id == other.Id) && (this.SchoolClassId == otherStudent.SchoolClassId))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public override string ToString()
        {
            return Id + ". " + this.GetInterfaceObject.FullName;
        }

        public bool IsLoginNameCorrect(string givenLoginName)
        {
            throw new NotImplementedException();
        }

        public bool IsPasswordCorrect(string givenPassword)
        {
            throw new NotImplementedException();
        }

        public bool VerifyLoginName(string givenLoginName)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string givenPassword)
        {
            throw new NotImplementedException();
        }
    }
}
