using ApiECommerce.Context;
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
            var orderDetails = await (from orderDetail in dbContext.OrderDetails
                                        join order in dbContext.Orders on orderDetail.OrderId equals order.Id
                                        join product in dbContext.Products on orderDetail.ProductId equals product.Id
                                        where orderDetail.OrderId == orderId
                                        select new
                                        {
                                            Id = orderDetail.Id,
                                            Quantidade = orderDetail.Quantity,
                                            SubTotal = orderDetail.TotalPrice,
                                            ProdutoNome = product.Name,
                                            ProdutoImagem = product.UrlImage,
                                            ProdutoPreco = product.Price
                                        }).ToListAsync();

            if (orderDetails == null || orderDetails.Count == 0)
            {
                return NotFound("Order details not found.");
            }

            return Ok(orderDetails);
        }

        [HttpGet("[action]/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> OrdersByUser(int userId)
        {
            var orders = await (from order in dbContext.Orders
                                 where order.UserId == userId
                                 orderby order.OrderDate descending
                                 select new
                                 {
                                     Id = order.Id,
                                     PedidoTotal = order.TotalAmount,
                                     DataPedido = order.OrderDate,
                                 }).ToListAsync();

            if (orders is null || orders.Count == 0)
            {
                return NotFound("No orders where found for this user");
            }

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
