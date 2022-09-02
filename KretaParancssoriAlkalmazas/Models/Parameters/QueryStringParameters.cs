using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Parameters
{
    public class QueryStringParameters : PaginationParameter
	{
		public string OrderBy { get; set; } = "";

		public string Fields { get; set; } = "";

        public string ToQueryString
        {
            get
            {
                StringBuilder result = new StringBuilder("?");
                // TODO általánossan megcsinálni!
                // ?orderby=subjectName&pagesize=10&pagenumber=2&fields=id,subjectName
                result.Append("pagenumber=" + CurrentPage);
                if (PageSize > 0)
                    result.Append("&pagesize=" + PageSize);
                if (OrderBy != string.Empty)
                    result.Append("&orderby=" + OrderBy);
                if (Fields != string.Empty)
                    result.Append("&fields+=" + Fields);
                return result.ToString();
            }
        }

        public QueryStringParameters()
        {
            CurrentPage = 1;
            //PageSize = alapértelmezett
            OrderBy = string.Empty;
            Fields = string.Empty;
        }
    }
}
