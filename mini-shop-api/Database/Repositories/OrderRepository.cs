using System;
using Microsoft.EntityFrameworkCore;
using MiniShopApi.Database.Entitites;

namespace MiniShopApi.Database.Repositories
{
	public class OrderRepository
	{
        private readonly ApplicationDbContext applicationDbContext;

        public OrderRepository(ApplicationDbContext applicationDbContext)
		{
            this.applicationDbContext = applicationDbContext;
        }

        public Order GetOrderById(int id)
        {
            return applicationDbContext.Orders.Include(y => y.Product).Include(z => z.User).SingleOrDefault(x => x.Id == id);
        }

        public List<Order> GetAllOrders()
        {
            return applicationDbContext.Orders.Include(x => x.Product).Include(x => x.Product).ToList();
        }

        public Order CreateOrder(string userid, int productid, int quantity, decimal price)
        {
            var newOrder = new Order
            {
                UserId = userid,
                ProductId = productid,
                Quantity = quantity,
                Price = price
            };

            var addedOrder = applicationDbContext.Orders.Add(newOrder);
            applicationDbContext.SaveChanges();

            return addedOrder.Entity;
        }

        public void OrderToDelete(int id)
        {
            var orderToDelete = applicationDbContext.Orders.SingleOrDefault(x => x.Id == id);

            if(orderToDelete == null)
            {
                return;
            }

            applicationDbContext.Orders.Remove(orderToDelete);
            applicationDbContext.SaveChanges();
        }
	}
}

