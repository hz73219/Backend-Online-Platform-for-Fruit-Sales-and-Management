using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class OrderDto
    {
        public string Id { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public decimal PriceDiscount { get; set; }
        public DateTime Create_Day { get; set; }
        public IList<OrderDetail> ListOrderDetail { get; set; }
        public Voucher Voucher { get; set; }
        public OrderDto() {

        }

    }
}
