using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual IList<Product>? List_Product { get; set; }
        public Category() {
        }
    }
}
