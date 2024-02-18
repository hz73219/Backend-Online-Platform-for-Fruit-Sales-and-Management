using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class OrderDetail 
    {
        public string Id { get; set; } = string.Empty;
        public string IdOrder { get; set; } = string.Empty;
        public string IdProduct { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
        public OrderDetail() { 
        }

    }
}
