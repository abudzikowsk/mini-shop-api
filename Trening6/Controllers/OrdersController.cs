using System;
using Microsoft.AspNetCore.Mvc;
using Trening6.Database.Repositories;
using Trening6.ViewModels;

namespace Trening6.Controllers
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

