using Market.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber  { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; }
    }
}
