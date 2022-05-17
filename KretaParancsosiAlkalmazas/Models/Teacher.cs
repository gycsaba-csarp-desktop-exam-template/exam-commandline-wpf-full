using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Interfaces;
using Kreta.Models.Interfaces.Base;
using Kreta.Models.BaseClass;

namespace Kreta.Models
{
    public class Teacher : ITeacher, IComparable, IEquatable<Teacher>
    {
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
        public int GrossSalary { get; set; }
        public int NumberOfChildren { get; set; }

        public Teacher()
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
            GrossSalary = -1;
            NumberOfChildren = -1;
        }

        public Teacher(int id, string firstName, string lastName, bool wooman, DateTime dataOfBirth)
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
            GrossSalary = -1;
            NumberOfChildren = -1;
        }

        public Teacher(int id, string firstName, string lastName, bool wooman, DateTime dataOfBirth, string city, string streetAndNumber, int postCode, string loginName, string password, int grossSalary, int numberOfChildren)
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
            GrossSalary = grossSalary;
            NumberOfChildren = numberOfChildren;
        }

        public bool Equals(Teacher other)
        {
            if (!(other is Teacher))
                return false;
            else
            {
                if (this == other)
                    return true;
                else
                {
                    Person person = new Person(other.Id, other.FirstName, other.LastName, other.Wooman, other.DataOfBirth);
                    Account account = new Account(other.LoginName, other.Password);
                    EmployeeData employeeData = new EmployeeData(other.GrossSalary, NumberOfChildren);

                    Person otherPerson = new Person(other.Id, other.FirstName, other.LastName, other.Wooman, other.DataOfBirth);
                    Account otherAccount = new Account(other.LoginName, other.Password);
                    EmployeeData otherEmloyeeData = new EmployeeData(other.GrossSalary, NumberOfChildren);

                    return person.Equals(otherPerson) && account.Equals(otherAccount) && (employeeData.Equals(otherEmloyeeData));
                }
            }
                   
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Teacher))
                return 0;
            else
            {
                ITeacher objTeacher = (ITeacher) obj;
                ITeacher thisTeacher = (ITeacher) this;

                int teacherFullNameCompareResult = thisTeacher.FullName.CompareTo(objTeacher.FullName);
                if (teacherFullNameCompareResult == 0)
                    return 0;
                else
                {
                    int teacherDataOfBirthComapreResult = this.DataOfBirth.CompareTo(objTeacher.DataOfBirth);
                    if (teacherDataOfBirthComapreResult == 0)
                        return 0;
                    else
                        return thisTeacher.Id.CompareTo(objTeacher.Id);
                }
            }
        }

        public override string ToString()
        {

            return "("+Id+") "+ GetInterfaceObject.FullName;
        }

        private ITeacher GetInterfaceObject
        {
            get { return (ITeacher)this; }
        }
    }
}
