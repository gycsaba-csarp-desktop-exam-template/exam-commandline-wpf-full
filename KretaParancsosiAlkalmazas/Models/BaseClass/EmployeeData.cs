using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models.Interfaces.Base;

namespace Kreta.Models.BaseClass
{
    public class EmployeeData : IEmployeeData, IEquatable<EmployeeData>, IComparable
    {
        public int GrossSalary { get; set; }
        public int NumberOfChildren { get; set; }

        public EmployeeData(int grossSalary, int numberOfChildren)
        {
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
