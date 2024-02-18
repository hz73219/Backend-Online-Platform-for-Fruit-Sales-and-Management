using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Search
    {
        public string Name { get; set; }
        public bool NewProduct { get; set; }
        public bool MostProduct { get; set; }
        public string PriceProduct { get; set; }
        public int MaxPrice { get; set; }
        public int MinPrice { get; set; }
        public string Origin { get; set; }
        public string Category { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Search()
        {
            NewProduct = false;
            MostProduct = false;
            Page = 1;
            PageSize = 1;
        }

    }
}
