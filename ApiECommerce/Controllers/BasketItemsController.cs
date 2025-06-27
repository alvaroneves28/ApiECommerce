using ApiECommerce.Context;
using ApiECommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketItemsController : Controller
    {
        private readonly AppDbContext dbContext;

        public BasketItemsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await dbContext.Users.FindAsync(userId);

            if (user is null)
            {
                return NotFound($"User with id = {userId} not found");
            }

            var basketItems = await (from s in dbContext.BasketItems.Where(s => s.UserId == userId)
                                       join p in dbContext.Products on s.ProductId equals p.Id
                                       select new
                                       {
                                           Id = s.Id,
                                           UnitPrice = s.UnitPrice,
                                           TotalPrice = s.TotalPrice,
                                           Quantity = s.Quantity,
                                           ProductId = p.Id,
                                           ProductName = p.Name,
                                           UrlImage = p.UrlImage
                                       }).ToListAsync();

            return Ok(basketItems);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BasketItem basketItem)
        {
            try
            {
                var shoppingCart = await dbContext.BasketItems.FirstOrDefaultAsync(s =>
                    s.ProductId == basketItem.ProductId &&
                    s.UserId == basketItem.UserId);

                if (shoppingCart is not null)
                {
                    shoppingCart.Quantity += basketItem.Quantity;
                    shoppingCart.TotalPrice = shoppingCart.UnitPrice * shoppingCart.Quantity;
                }
                else
                {
                    var product = await dbContext.Products.FindAsync(basketItem.ProductId);

                    var basket = new BasketItem()
                    {
                        UserId = basketItem.UserId,
                        ProductId = basketItem.ProductId,
                        UnitPrice = basketItem.UnitPrice,
                        Quantity = basketItem.Quantity,
                        TotalPrice = (basketItem.UnitPrice) * (basketItem.Quantity)
                    };
                    dbContext.BasketItems.Add(basket);
                }

                await dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error processing your request");
            }

           
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int productId, string action)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user is null)
            {
                return NotFound("User not found.");
            }

            var basketItem = await dbContext.BasketItems.FirstOrDefaultAsync(s =>
                s.UserId == user.Id && s.ProductId == productId);

            if (basketItem != null)
            {
                string actionMessage;

                switch (action.ToLower())
                {
                    case "increase":
                        basketItem.Quantity += 1;
                        actionMessage = "increased";
                        break;

                    case "decrease":
                        if (basketItem.Quantity > 1)
                        {
                            basketItem.Quantity -= 1;
                            actionMessage = "decreased";
                        }
                        else
                        {
                            dbContext.BasketItems.Remove(basketItem);
                            await dbContext.SaveChangesAsync();
                            return Ok("Item removed from basket.");
                        }
                        break;

                    case "delete":
                        dbContext.BasketItems.Remove(basketItem);
                        await dbContext.SaveChangesAsync();
                        return Ok("Item deleted from basket.");

                    default:
                        return BadRequest("Invalid action. Allowed: increase, decrease, delete.");
                }

                basketItem.TotalPrice = basketItem.UnitPrice * basketItem.Quantity;
                await dbContext.SaveChangesAsync();
                return Ok($"Item quantity {actionMessage} successfully.");
            }

            return NotFound("Basket item not found.");
        }


    }
}
