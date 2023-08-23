using System;
using MiniShopApi.ViewModels;

namespace MiniShopApi.Database.Entitites
{
	public class Order
	{
        public int Id { get; set; }
        public string UserId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

		public User User { get; set; }
		public Product Product { get; set; }

		public OrderViewModel MapToViewModel()
		{
			return new OrderViewModel
			{
				Id = Id,
				ProductName = Product.Name,
				Price = Price,
				Quantity = Quantity,
				UserFirstname = User.Name,
				UserSurname = User.Surname
			};
		}
	}
}

