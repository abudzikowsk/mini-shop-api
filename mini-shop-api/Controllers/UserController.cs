using System;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet]
        public ActionResult<UserViewModel> GetUsers()
        {
	        var result = new List<UserViewModel>();

	        var users = userRepository.GetAllUsers();

	        foreach (var user in users)
	        {
		        result.Add(user.MapToViewModel());
	        }

	        return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UserViewModel> GetUserById(string id)
        {
	        var user = userRepository.GetUserById(id);

	        if (user == null)
	        {
		        return NotFound();
	        }

	        return Ok(user.MapToViewModel());
        }

		[HttpPost]
		public ActionResult<UserViewModel> CreateUser(CreateUserViewModel createUserViewModel)
		{
			var newUser = userRepository.CreateUser(createUserViewModel.Name, createUserViewModel.Surname);

			return Ok(newUser.MapToViewModel());
		}

		[HttpPut]
		[Route("{id}")]
		public IActionResult UpdateUser(string id, UpdateUserViewModel updateUserViewModel)
		{
			userRepository.UpdateUser(id, updateUserViewModel.Name, updateUserViewModel.Surname);

			return Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult DeleteUser(string id)
		{
			userRepository.DeleteUser(id);

			return Ok();
		}
	}
}

