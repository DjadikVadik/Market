using Market.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.IRepositoriy
{
    public interface IOrderRepository
    {
        Task<OrderDomain?> GetSingleAsync(int id);
        Task<IEnumerable<OrderDomain>?> GetAllAsync();
        Task<bool> Add(OrderDomain DomainOrder);
        Task<bool> Update(OrderDomain NewOrder);
        Task<bool> Delete(int id);
    }
}
