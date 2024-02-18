using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Cart
    {
        public string Id { get; set; }
        public string IdProduct { get; set; } = string.Empty;
        public string IdUser { get; set; } = string.Empty;
        public int Quantity { get; set; }
        
        public virtual Product Product { get; set; }
        public Cart() {
        }
    }
}
