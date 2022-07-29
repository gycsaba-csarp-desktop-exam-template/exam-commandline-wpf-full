using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Parameters
{
    public class SchoolClassQueryYearParameter
    {
        public int MinYear { get; set; } = 9;
        public int MaxYear { get; set; } = 12;

        public bool ValidYearRange => MinYear <= MaxYear && MinYear >= 9 && MaxYear <= 12;
    }
}
