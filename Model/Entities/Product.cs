using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string IdCategory { get; set; }
        public string IdOrigin { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public string IdImage { get; set; } = string.Empty;
        public DateTime CreateDay { get; set; }
        public int SoldQuantity { get; set; }
        public virtual IList<Image>? Images { get; set; }

        public Product() {
 
        }
    }
}
