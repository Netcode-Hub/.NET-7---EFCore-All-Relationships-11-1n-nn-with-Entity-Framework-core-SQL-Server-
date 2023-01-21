using EFCoreRelationships.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public ProductsController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get(int categoryId)
        {
            var products = await appDbContext.Products
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Size)
                .Include(x => x.Colors).ToListAsync();
            return products;
        }



    }
}
