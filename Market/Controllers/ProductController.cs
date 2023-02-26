using Market.Data.IRepositoriy;
using Market.Data.Repositoriy;
using Market.Domain.ModelsDomain;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

       public ProductController (IProductRepository repository) => this.repository = repository;    

        [HttpGet("GetSingleProduct")]
        public async Task<ProductDomain?> GetSingleProduct(int id) => await repository.GetSingleAsync(id);

        [HttpGet("GetAllProducts")]
        public async Task<IEnumerable<ProductDomain>?> GetAllProducts(int CategoryID) => await repository.GetCategoryAsync(CategoryID);

        [HttpPost("AddProduct")]
        public async Task<bool> AddProduct(ProductDomain product) => await repository.Add(product);

        [HttpPut("UpdateProduct")]
        public async Task<bool> UpdateProduct(ProductDomain product) => await repository.Update(product);

        [HttpDelete("DeleteProduct")]
        public async Task<bool> DeleteProduct(int id) => await repository.Delete(id);
    }
}