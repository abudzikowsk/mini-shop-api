using System;
using Microsoft.EntityFrameworkCore;
using Trening6.Database.Entitites;

namespace Trening6.Database.Repositories
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

        public void CreateOrder(string userid, int productid, int quantity)
        {
            var newOrder = new Order
            {
                UserId = userid,
                ProductId = productid,
                Quantity = quantity
            };

            applicationDbContext.Orders.Add(newOrder);
            applicationDbContext.SaveChanges();
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

