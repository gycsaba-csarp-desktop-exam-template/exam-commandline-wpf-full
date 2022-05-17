using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Interfaces.Base
{
    public interface IEmployeeData
    {
        public int GrossSalary { get; set; }

        public int NumberOfChildren { get; set; }

        public bool HasChild
        {
            get => this.NumberOfChildren > 0;
        }
    }
}
