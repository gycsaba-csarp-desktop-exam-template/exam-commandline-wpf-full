using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaParancssoriAlkalmazas.Models.Parameters
{
    public class QueryStringParameters : IQueryStringParameters
    {   
        public int CurrentPage { get; set; }
        public int NumberOfPage { get; set; }
        public int PageSize { get; set; } = 10;
        public int NumberOfItem { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < NumberOfPage;

        public string OrderBy { get; set; } = "";
        public string Fields { get; set; } = "";
        public string Filter { get; set; } = "";

        public string ToQueryString
        {
            get
            {
                StringBuilder result = new StringBuilder("?");
                // TODO általánossan megcsinálni!
                // ?orderby=subjectName&CurrentPage=2&pagesize=10&fields=id,subjectName
                result.Append("currentpage=" + CurrentPage);
                if (PageSize > 0)
                    result.Append("&pagesize=" + PageSize);
                if (OrderBy != string.Empty)
                    result.Append("&orderby=" + OrderBy);
                if (Fields != string.Empty)
                    result.Append("&fields=" + Fields);
                if (Filter != string.Empty)
                    result.Append("&filter=" + Filter);
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

        public override string ToString()
        {
            return $"Curent page:{CurrentPage}, Number of page:{NumberOfPage}, Page size:{PageSize}, NumberOfItem:{NumberOfItem}";
        }
    }
}
