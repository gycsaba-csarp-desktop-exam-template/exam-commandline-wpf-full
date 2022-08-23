using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Parameters
{
    public abstract class QueryStringParameters : PaginationParameter
	{
		public string OrderBy { get; set; } = "";

		public string Fields { get; set; } = "";
	}
}
