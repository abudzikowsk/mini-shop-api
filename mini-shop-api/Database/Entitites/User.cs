using System;
using MiniShopApi.ViewModels;

namespace MiniShopApi.Database.Entitites
{
	public class User
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }

		public UserViewModel MapToViewModel()
		{
			return new UserViewModel
			{
				Id = Id,
				Name = Name,
				Surname = Surname
			};
		}
	}
}

