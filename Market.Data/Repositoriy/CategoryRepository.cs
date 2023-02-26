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
    public class CategoryRepository : ICategoryRepository
    {
        readonly MarketContext context;

        public CategoryRepository (MarketContext context) => this.context = context;

        public async Task<bool> Add(string Name)
        {
            await context.Set<Category>().AddAsync(new Category { Name = Name });
            await context.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await context.Set<Category>().Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (entity == null) return await Task.FromResult(false);

            context.Set<Category>().Remove(entity);
            await context.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<CategoryDomain>?> GetAllAsync()
        {
            var entitys = await context.Set<Category>().Select(c => new CategoryDomain() { Id = c.Id, Name = c.Name}).ToListAsync();
            if (entitys == null) return null;
            return entitys;
        }

        public async Task<bool> Update(CategoryDomain NewCategory)
        {
            var entity = await context.Set<Category>().Where(c => c.Id == NewCategory.Id).FirstOrDefaultAsync();
            if (entity == null) return await Task.FromResult(false);

            entity.Name = NewCategory.Name;
            await context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
