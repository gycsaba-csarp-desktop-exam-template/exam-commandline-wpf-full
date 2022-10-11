using Kreta.Models.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.DataModel
{
    public class EmployeeData : IEmployeeData, IEquatable<EmployeeData>, IComparable
    {
        public long Id { get; set; }
        public ulong GrossSalary { get; set; }
        public uint NumberOfChildren { get; set; }


        public EmployeeData(long id, ulong grossSalary, uint numberOfChildren)
        {
            Id = id;
            GrossSalary = grossSalary;
            NumberOfChildren = numberOfChildren;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(EmployeeData other)
        {
            throw new NotImplementedException();
        }
    }
}
