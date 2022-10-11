using Kreta.Models.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.DataModel
{
    public abstract class Employee : Person, IEmployeeData
    {
        public ulong TaxNumber { get; set; }
        public uint NumberOfChildren { get; set; }
        public ulong GrossSalary { get; set; }
        public IAccount? Account { get; }
        public IAddress? Address { get; set; }

        protected Employee(
            long id,
            string firstName,
            string lastName,
            bool wooman,
            DateTime dataOfBirth,
            ulong taxNumber,
            ulong grossSalary,
            uint numberOfChildren,
            IAddress address,
            IAccount account
            ) : base(id, firstName, lastName, wooman, dataOfBirth)

        {
            TaxNumber = taxNumber;
            GrossSalary = grossSalary;
            NumberOfChildren = numberOfChildren;
            Account = account;
            Address = address;
        }


        protected Employee(long id, string firstName, string lastName, bool wooman, DateTime dataOfBirth)
            : base()

        {
            TaxNumber = ulong.MaxValue;
            GrossSalary = ulong.MaxValue;
            NumberOfChildren = uint.MaxValue;
            Account = null;
            Address = null;
        }

        protected Employee() : base()
        {
            TaxNumber = ulong.MaxValue;
            GrossSalary = ulong.MaxValue;
            NumberOfChildren = uint.MaxValue;
            Account = null;
            Address = null;
        }
    }
}
