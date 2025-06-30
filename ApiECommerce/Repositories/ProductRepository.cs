using ApiECommerce.Context;
using ApiECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<IEnumerable<Product>> GetMostSoldProductsAsync()
        {
            return await _dbContext.Products.AsNoTracking()
                .Where(p => p.MostSold && p.Available)
                .ToListAsync();
        }

        
        public async Task<IEnumerable<Product>> GetPopularProductsAsync()
        {
            return await _dbContext.Products.AsNoTracking()
                .Where(p => p.Popular && p.Available)
                .ToListAsync();
        }

       
        public async Task<Product?> GetProductDetailsAsync(int id)
        {
            return await _dbContext.Products.AsNoTracking()
                .Include(p => p.OrderDetails)     
                .Include(p => p.BasketItems)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

      
        public async Task<IEnumerable<Product>> GetProductsPerCategoryAsync(int categoryId)
        {
            return await _dbContext.Products.AsNoTracking()
                .Where(p => p.CategoryId == categoryId && p.Available)
                .ToListAsync();
        }
    }
}
