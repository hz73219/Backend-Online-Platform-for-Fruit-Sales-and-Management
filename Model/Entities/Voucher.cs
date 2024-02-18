using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Voucher
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Discount { get; set; }
        public bool isUse { get; set; }
        public DateTime Expired_Time { get; set; }
        public Voucher() {
            isUse = false;
        }
    }
}
