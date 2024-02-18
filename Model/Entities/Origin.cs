using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Origin
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual IList<Product>? List_Product { get; set; }
        public Origin() {
        }   
    }
}
