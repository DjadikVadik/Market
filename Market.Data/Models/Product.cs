using Market.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Models
{
    public class Product
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public string IconName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}
