using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class ProductDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }      
        public int Quantity { get; set; }
        public string Note { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public IList<Image> Images { get; set; }
        public ProductDto()
        {       
            Images = new List<Image>();
        }
    }
}
