using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Interfaces
{
    interface ISchoolClass
    {
        public int Id { get ; set ; }
        public int CLass { get; set; }
        public char CLassType { get ; set ; }
        public int TeacherId { get; set ; }

        public string ClassClassType
        {
            get
            {
                string result = CLass + ". " + CLassType;
                return result;
            }
        }

        public bool SchoolLeaver
        {
            get
            {
                if (CLass == 12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
