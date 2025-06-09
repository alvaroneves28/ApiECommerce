using ApiECommerce.Entities;

namespace ApiECommerce.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsPerCategoryAsync(int categoryId);

        Task<IEnumerable<Product>> GetPopularProductsAsync();

        Task<IEnumerable<Product>> GetMostSoldProductsAsync();

        Task<Product> GetProductDetailsAsync(int Id);


    }
}
