using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Interfaces;
using Kreta.Models.Interfaces.Base;

namespace KretaParancssoriAlkalmazas.Models.DataModel
{
    public class Parent : IBaseModel, IParent
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


        public Parent()
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
        }

        public Parent(int id, string firstName, string lastName, bool wooman, DateTime dataOfBirth)
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
        }

        public Parent(int id, string firstName, string lastName, bool wooman, DateTime dataOfBirth, string city, string streetAndNumber, int postCode, string loginName, string password)
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
        }

        private IParent GetInterfaceObject
        {
            get { return this; }
        }

        long IBaseModel.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string ToString()
        {
            return Id + "." + GetInterfaceObject.FullName;
        }

        public void Set(object obj)
        {
            if (obj is Parent)
            {
                Parent p = (Parent)obj;
                Id = p.Id;
                FirstName = p.FirstName;
                LastName = p.LastName;
                Wooman = p.Wooman;
                DataOfBirth = p.DataOfBirth;
                City = p.City;
                StreetAndNumber = p.StreetAndNumber;
                PostCode = p.PostCode;
                LoginName = p.LoginName;
                Password = p.Password;
            }
        }
    }
}
