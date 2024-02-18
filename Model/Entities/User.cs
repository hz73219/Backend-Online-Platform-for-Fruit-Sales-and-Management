using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User
    {
        public string Id { get; set; }
        [MinLength(6)]
        public string UserName { get; set; } = string.Empty;
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone {get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public virtual IList<Order> ListOrder { get; set; }
        public virtual IList<Cart> ListCart { get; set; }
        public User() { 

        }
    }
}
