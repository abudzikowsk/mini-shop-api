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

        public async Task<Order> GetOrderById(int id)
        {
            return await applicationDbContext.Orders.Include(y => y.Product).Include(z => z.User).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await applicationDbContext.Orders.Include(x => x.Product).Include(x => x.Product).ToListAsync();
        }

        public async Task<Order> CreateOrder(string userid, int productid, int quantity, decimal price)
        {
            var newOrder = new Order
            {
                UserId = userid,
                ProductId = productid,
                Quantity = quantity,
                Price = price
            };

            var addedOrder = applicationDbContext.Orders.Add(newOrder);
            await applicationDbContext.SaveChangesAsync();

            return addedOrder.Entity;
        }

        public async Task DeleteOrder(int id)
        {
            var orderToDelete = applicationDbContext.Orders.SingleOrDefault(x => x.Id == id);

            if(orderToDelete == null)
            {
                return;
            }

            applicationDbContext.Orders.Remove(orderToDelete);
            await applicationDbContext.SaveChangesAsync();
        }
	}
}

