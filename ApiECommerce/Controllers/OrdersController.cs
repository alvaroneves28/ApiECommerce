using ApiECommerce.Context;
using ApiECommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly AppDbContext dbContext;

        public OrdersController(AppDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        [HttpGet("[action]/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> OrderDetails(int orderId)
        {
            var orderDetails = await dbContext.OrderDetails
                .AsNoTracking()
                .Include(od => od.Product) 
                .Where(od => od.OrderId == orderId)
                .Select(orderDetail => new
                {
                    Id = orderDetail.Id,
                    Quantity = orderDetail.Quantity,
                    SubTotal = orderDetail.TotalPrice,
                    ProductName = orderDetail.Product.Name,
                    ProductImage = orderDetail.Product.UrlImage,
                    ProductPrice = orderDetail.Product.Price
                })
                .ToListAsync();

            if (!orderDetails.Any())
            {
                return NotFound("Order details not found.");
            }

            return Ok(orderDetails);
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> OrdersByUser(int userId)
        {
            var orders = await dbContext.Orders
                .AsNoTracking() // <--- Aqui
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new
                {
                    o.Id,
                    o.OrderDate,
                    OrderTotal = dbContext.OrderDetails
                                          .AsNoTracking()
                                          .Where(od => od.OrderId == o.Id)
                                          .Sum(od => od.TotalPrice)
                })
                .ToListAsync();

            if (orders is null || orders.Count == 0)
                return NotFound("No orders found for this user");

            return Ok(orders);
        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { errors });
            }

            order.OrderDate = DateTime.Now;

            var basketItems = await dbContext.BasketItems
                .Where(basketItem => basketItem.UserId == order.UserId)
                .ToListAsync();

            // Verifica se há itens no carrinho
            if (basketItems.Count == 0)
            {
                return NotFound("There are no items in the basket to order");
            }

            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    dbContext.Orders.Add(order);
                    await dbContext.SaveChangesAsync();

                    foreach(var item in basketItems)
                    {
                        var orderDetail = new OrderDetail()
                        {
                            UnitPrice = item.UnitPrice,
                            TotalPrice = item.TotalPrice,
                            Quantity = item.Quantity,
                            ProductId = item.ProductId,
                            OrderId = order.Id

                        };
                        dbContext.OrderDetails.Add(orderDetail);
                    }

                    await dbContext.SaveChangesAsync();
                    dbContext.BasketItems.RemoveRange(basketItems);
                    await dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return Ok(new { OrderId = order.Id });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    var baseException = ex.GetBaseException();
                    return BadRequest(new { error = baseException.Message });
                }
        
    }
        }
    }
}
