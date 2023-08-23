using Microsoft.AspNetCore.Mvc;
using MiniShopApi.Database.Repositories;
using MiniShopApi.ViewModels;

namespace MiniShopApi.Controllers
{
	[ApiController]
	[Route("orders")]
    public class OrdersController : ControllerBase
	{
        private readonly OrderRepository orderRepository;

        public OrdersController(OrderRepository orderRepository)
		{
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<OrderViewModel>> GetOrders()
        {
            var result = new List<OrderViewModel>();

            var orders = orderRepository.GetAllOrders();

            foreach(var order in orders)
            {
                result.Add(order.MapToViewModel());
            }
            return Ok(result);
        }
	}
}

