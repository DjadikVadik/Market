using Market.Data.Models;
using Market.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.IRepositoriy
{
    public interface IProductRepository
    {
        Task<ProductDomain?> GetSingleAsync(int Id);
        Task<IEnumerable<ProductDomain>?> GetCategoryAsync(int categoryID);
        Task<bool> Add(ProductDomain product);
        Task<bool> Update(ProductDomain NewProduct);
        Task<bool> Delete(int Id);
    }
}
