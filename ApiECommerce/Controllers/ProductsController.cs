using ApiECommerce.Entities;
using ApiECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ApiECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts(string productType, int? categoryId = null)
        {
            IEnumerable<Product> products;

            if(productType =="category" && categoryId != null)
            {
                products = await _productRepository.GetProductsPerCategoryAsync(categoryId.Value);
            }
            else if (productType == "popular")
            {
                products = await _productRepository.GetPopularProductsAsync();
            }
            else if (productType == "mostSold")
            {
                products = await _productRepository.GetMostSoldProductsAsync();
            }
            else
            {
                return BadRequest("invalid input type");
            }

            var productData = products.Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Detail = x.Detail,
                UrlImage = x.UrlImage
            });

            return Ok(productData);

        }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetProductDetail(int id)
        {
            var product = await _productRepository.GetProductDetailsAsync(id);

            if(product is null)
            {
                return NotFound($"Product with id={id} not found");
            }

            var productData = new
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Detail = product.Detail,
                UrlImage = product.UrlImage
            };

            return Ok(productData);
        }
    }
}
