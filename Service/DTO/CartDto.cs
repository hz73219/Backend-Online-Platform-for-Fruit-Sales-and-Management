using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class CartDto
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public DateTime Create_Day { get; set; }
        public CartDto()
        {
            Product = new Product();
        }
    }
}
