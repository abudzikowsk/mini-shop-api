using System;
using MiniShopApi.ViewModels;

namespace MiniShopApi.Database.Entitites
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }

		public ProductViewModel MapToViewModel()
		{
			return new ProductViewModel
			{
				Id = Id,
				Name = Name,
				Price = Price
			};
		}
	}
}

