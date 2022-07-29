using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Parameters
{
    public class SchoolClassQueryYearParameter
    {
        public int minYear { get; set; } = 9;
        public int maxYear { get; set; } = 12;

        public bool ValidYearRange => minYear <= maxYear && minYear >= 9 && maxYear <= 12;
    }
}
