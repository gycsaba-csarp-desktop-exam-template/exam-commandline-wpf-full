using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KretaParancssoriAlkalmazas.Models.Parameters;

namespace KretaParancssoriAlkalmazas.Models.Helpers
{
    public class PagedList<T> : List<T>
    {
        private QueryStringParameters queryString;

        public QueryStringParameters QueryString
        {
            get { return queryString; }
            set { queryString = value; }
        }


        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            queryString = new QueryStringParameters();
            queryString.NumberOfRows = count;
            queryString.PageSize = pageSize;
            queryString.CurrentPage = pageNumber;
            queryString.OrderBy = String.Empty;
            queryString.Fields = String.Empty;

            queryString.NumberOfPage = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public PagedList()
        {
            queryString = new QueryStringParameters();
            queryString.CurrentPage = 0;
            queryString.NumberOfPage = 0;
            queryString.PageSize = 0;
            queryString.NumberOfRows = 0;
            queryString.OrderBy = String.Empty;
            queryString.Fields = String.Empty;
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber-1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        public QueryStringParameters GetParameters()
        {
            return queryString;
        }
    }
}
