using System;
using Microsoft.AspNetCore.Mvc;
using MiniShopApi.Database.Repositories;
using MiniShopApi.ViewModels;

namespace MiniShopApi.Controllers
{
	[ApiController]
	[Route("users")]
	public class UserController : ControllerBase
	{
        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
		{
            this.userRepository = userRepository;
        }

		[HttpPost]
		public ActionResult<UserViewModel> CreateUser(CreateUserViewModel createUserViewModel)
		{
			var newUser = userRepository.CreateUser(createUserViewModel.Name, createUserViewModel.Surname);

			return Ok(newUser.MapToViewModel());
		}
	}
}

