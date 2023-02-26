using Market.Data.Models;
using Market.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.IRepositoriy
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDomain>?> GetAllAsync();
        Task<bool> Add(string Name);
        Task<bool> Delete(int Id);
        Task<bool> Update(CategoryDomain NewCategory);
    }
}
