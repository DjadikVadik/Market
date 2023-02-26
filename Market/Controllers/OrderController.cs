using Market.Data.IRepositoriy;
using Market.Domain.ModelsDomain;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        readonly IOrderRepository repository;

        public OrderController(IOrderRepository repository) => this.repository = repository;

        [HttpGet("GetSingleOrder")]
        public async Task<OrderDomain?> GetSingleOrder(int id) => await repository.GetSingleAsync(id);

        [HttpGet("GetAllOrder")]
        public async Task<IEnumerable<OrderDomain>?> GetAllOrder() => await repository.GetAllAsync();
        
        [HttpPost("AddOrder")]
        public async Task<bool> AddOrder(OrderDomain order) => await repository.Add(order);

        [HttpPut("UpdateOrder")]
        public async Task<bool> UpdateOrder(OrderDomain order) => await repository.Update(order);

        [HttpDelete("DeleteOrder")]
        public async Task<bool> DeleteOrder(int id) => await repository.Delete(id);
    }
}
