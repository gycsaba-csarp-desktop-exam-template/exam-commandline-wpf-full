using Kreta.Models.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.DataModel
{
    public class Teacher : Person, IEmployeeData
    {
        public IAccount? Account { get; }
        public IAddress? Address { get; set; }
        public ulong GrossSalary { get; set; }
        public uint NumberOfChildren { get; set; }

        public Teacher(long id, string firstName, string lastName, bool woman, DateTime dateOfBirth, IAddress address, IAccount account, ulong grossSalary, uint numberOfChildren)
            : base(id, firstName, lastName, woman, dateOfBirth)
        {
            Account = account;
            Address = address;
            GrossSalary = grossSalary;
            NumberOfChildren = numberOfChildren;
        }

        public Teacher() : base()
        {
            Account = null;
            Address = null;
            GrossSalary = ulong.MaxValue;
            NumberOfChildren = uint.MaxValue;
        }
    }
}
