using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class OrderDetailDto
    {
        public string Id { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public OrderDetailDto()
        {
            Product = new Product();
        }
    }
}
