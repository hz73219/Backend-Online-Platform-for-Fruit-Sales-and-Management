using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Order 
    {
        public string Id { get; set; }
        public string IdUser { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public decimal PriceDiscount { get; set; }
        public string? IdVoucher { get; set; }
        public int Status { get; set; }
        public DateTime CreateDay { get; set; }
        public DateTime? FinishDay { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public virtual IList<OrderDetail> ListOrderDetail { get; set; }
        public Order()
        {
        }

    }
}
