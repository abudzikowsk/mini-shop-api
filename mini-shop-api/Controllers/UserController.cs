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
        public async Task<ActionResult<UserViewModel>> GetUsers()
        {
	        var result = new List<UserViewModel>();

	        var users = await userRepository.GetAllUsers();

	        foreach (var user in users)
	        {
		        result.Add(user.MapToViewModel());
	        }

	        return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUserById(string id)
        {
	        var user = await userRepository.GetUserById(id);

	        if (user == null)
	        {
		        return NotFound();
	        }

	        return Ok(user.MapToViewModel());
        }

		[HttpPost]
		public async Task<ActionResult<UserViewModel>> CreateUser(CreateUserViewModel createUserViewModel)
		{
			var newUser = await userRepository.CreateUser(createUserViewModel.Name, createUserViewModel.Surname);

			return Ok(newUser.MapToViewModel());
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateUser(string id, UpdateUserViewModel updateUserViewModel)
		{
			await userRepository.UpdateUser(id, updateUserViewModel.Name, updateUserViewModel.Surname);

			return Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteUser(string id)
		{
			await userRepository.DeleteUser(id);

			return Ok();
		}
	}
}

