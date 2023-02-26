using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.ModelsDomain
{
    public class ProductDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public CategoryDomain categoryDomain { get; set; }
    }
}
