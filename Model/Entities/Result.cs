using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Result
    {
        public List<Product> Products { get; set; }
        public int MaxPage { get; set; }
        public Result() {
            Products = new List<Product>();
        }
    }
}
