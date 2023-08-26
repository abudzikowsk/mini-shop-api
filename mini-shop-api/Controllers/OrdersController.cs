using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly UserRepository userRepository;
        private readonly ProductRepository productRepository;

        public OrdersController(OrderRepository orderRepository, UserRepository userRepository, ProductRepository productRepository)
		{
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.productRepository = productRepository;
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

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OrderViewModel> GetOrderById(int id)
        {
            var order = orderRepository.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order.MapToViewModel());
        }

        [HttpPost]
        public ActionResult<OrderViewModel> CreateOrder(CreateOrderViewModel createOrderViewModel)
        {
            var user = userRepository.GetUserById(createOrderViewModel.UserId);

            if(user == null)
            {
                return BadRequest("User not found.");
            }

            var product = productRepository.GetProductById(createOrderViewModel.ProductId);

            if(product == null)
            {
                return BadRequest("Product not found.");
            }

            var newOrder = orderRepository.CreateOrder(
                createOrderViewModel.UserId,
                createOrderViewModel.ProductId,
                createOrderViewModel.Quantity,
                createOrderViewModel.Quantity*product.Price);

            return Ok(newOrder.MapToViewModel());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteOrder(int id)
        {
            orderRepository.DeleteOrder(id);

            return Ok();
        }
	}
}

