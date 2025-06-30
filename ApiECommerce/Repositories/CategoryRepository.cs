using ApiECommerce.Context;
using ApiECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbcontext;

        public CategoryRepository(AppDbContext dbContext)
        {
            this.dbcontext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await dbcontext.Categories.AsNoTracking().ToListAsync();
        }
    }
}
