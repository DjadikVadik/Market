using Market.Data.IRepositoriy;
using Market.Data.Repositoriy;
using Market.Domain.ModelsDomain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryRepository repository;

        public CategoryController(ICategoryRepository repository) => this.repository = repository;

        [HttpGet("GetAllCategorys")]
        public async Task<IEnumerable<CategoryDomain>?> GetAllCategorys() => await repository.GetAllAsync();

        [HttpPost("AddCategory")]
        public async Task<bool> AddCategory(string name) => await repository.Add(name);

        [HttpPut("UpdateCategory")]
        public async Task<bool> UpdateCategory(CategoryDomain category) => await repository.Update(category);

        [HttpDelete("DeleteCategory")]
        public async Task<bool> DeleteCategory(int id) => await repository.Delete(id);
    }
}
