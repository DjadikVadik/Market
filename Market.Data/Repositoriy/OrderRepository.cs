using Market.Data.IRepositoriy;
using Market.Data.Models;
using Market.Domain.ModelsDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Repositoriy
{
    public class OrderRepository : IOrderRepository
    {
        readonly MarketContext context;

        public OrderRepository(MarketContext context) => this.context = context;

        public async Task<bool> Add(OrderDomain DomainOrder)
        {
            var order = new Order();
            order.UserName = DomainOrder.UserName;
            order.Address = DomainOrder.Address;
            order.PhoneNumber = DomainOrder.PhoneNumber;    
            order.Products = new List<Product>();

            foreach(var p in DomainOrder.ProductsDomain) order.Products.Add(context.Set<Product>().Where(pr => pr.Id == p.Id).Single());

            await context.Set<Order>().AddAsync(order);
            await context.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await context.Set<Order>().Where(o => o.Id == id).FirstOrDefaultAsync();
            if (entity == null) return await Task.FromResult(false);

            context.Set<Order>().Remove(entity);
            await context.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<OrderDomain>?> GetAllAsync()
        {
            var entity = await context.Set<Order>().Include(o => o.Products).ThenInclude(p => p.category).ToListAsync();
            if (entity == null) return null;

            var result = new List<OrderDomain>();
            foreach (var order in entity)
            {
                var orderDomain = new OrderDomain()
                {
                    Id = order.Id,
                    UserName = order.UserName,
                    Address = order.Address,
                    PhoneNumber = order.PhoneNumber,
                    ProductsDomain = new List<ProductDomain>()
                };
                foreach (var product in order.Products)
                    orderDomain.ProductsDomain.Add(new ProductDomain() { Id= product.Id, Name = product.Name, IconName = product.IconName, Description = product.Description, Price = product.Price, categoryDomain = new CategoryDomain() { Id = product.category.Id, Name = product.category.Name} });
                result.Add(orderDomain);
            }

            return result;
        }

        public async Task<OrderDomain?> GetSingleAsync(int id)
        {
            var entity = await context.Set<Order>().Include(o => o.Products).ThenInclude(p => p.category).Where(o => o.Id == id).FirstOrDefaultAsync();
            if (entity == null) return null;

            var result = new OrderDomain();

            result.Id = entity.Id;
            result.UserName = entity.UserName;
            result.Address = entity.Address;
            result.PhoneNumber = entity.PhoneNumber;
            result.ProductsDomain = new List<ProductDomain>();

            foreach (var product in entity.Products)
                result.ProductsDomain.Add(new ProductDomain() { Id = product.Id, Name = product.Name, IconName = product.IconName, Description = product.Description, Price = product.Price, categoryDomain = new CategoryDomain() { Id = product.category.Id, Name = product.category.Name } });

            return result;
        }

        public async Task<bool> Update(OrderDomain NewOrder)
        {
            var entity = await context.Set<Order>().Include(o => o.Products).ThenInclude(p => p.category).Where(o => o.Id == NewOrder.Id).FirstOrDefaultAsync();
            if (entity == null) return await Task.FromResult(false);

            entity.UserName = NewOrder.UserName;
            entity.Address = NewOrder.Address;
            entity.PhoneNumber = NewOrder.PhoneNumber;
            entity.Products = new List<Product>();

            foreach (var product in NewOrder.ProductsDomain) entity.Products.Add(context.Set<Product>().Where(p => p.Id == product.Id).Single());

            await context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
