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
    public class ProductRepository : IProductRepository
    {
        readonly MarketContext context;

        public ProductRepository( MarketContext context ) => this.context = context;

        public async Task<bool> Add(ProductDomain product)
        {
            var cat = await context.Set<Category>().Where(c => c.Id == product.categoryDomain.Id).FirstOrDefaultAsync();
            if (cat == null) return await Task.FromResult(false);

            await context.Set<Product>().AddAsync(new Product() { Name = product.Name, IconName = product.IconName, Description = product.Description, Price = product.Price, CategoryId = product.categoryDomain.Id });
            await context.SaveChangesAsync();
            return await Task.FromResult( true );
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await context.Set<Product>().Where(p => p.Id == Id).FirstOrDefaultAsync();
            if (entity == null) return await Task.FromResult( false );

            context.Set<Product>().Remove(entity);
            await context.SaveChangesAsync();
            return await Task.FromResult( true );
        }

        public async Task<IEnumerable<ProductDomain>?> GetCategoryAsync(int categoryID)
        {
            var entitys = await context.Set<Product>().Include(p => p.category).Where(p => p.category.Id == categoryID).Select(p => new ProductDomain() { Id = p.Id, Name = p.Name, IconName = p.IconName, Description = p.Description, Price = p.Price, categoryDomain = new CategoryDomain() { Id = p.category.Id, Name = p.category.Name} }).ToListAsync();
            if (entitys == null) return null;
            return entitys;
        }

        public async Task<ProductDomain?> GetSingleAsync(int Id)
        {
            var entity = await context.Set<Product>().Include(p => p.category).Where(p => p.Id == Id).Select(p => new ProductDomain() { Id = p.Id, Name = p.Name, IconName = p.IconName, Description = p.Description, Price = p.Price, categoryDomain = new CategoryDomain() { Id = p.category.Id, Name = p.category.Name } }).FirstOrDefaultAsync();
            if (entity == null) return null;
            return entity;
        }

        public async Task<bool> Update(ProductDomain NewProduct)
        {
            var entity = await context.Set<Product>().Where(p => p.Id == NewProduct.Id).FirstOrDefaultAsync();
            var category = await context.Set<Category>().Where(c => c.Id == NewProduct.categoryDomain.Id).FirstOrDefaultAsync();
            if (entity == null || category == null) return await Task.FromResult(false);

            entity.Name = NewProduct.Name;
            entity.Description = NewProduct.Description;
            entity.Price = NewProduct.Price;
            entity.IconName = NewProduct.IconName;
            entity.CategoryId = NewProduct.categoryDomain.Id;
            await context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
