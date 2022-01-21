using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet("find/{id}")]
		public JsonResult FindByName(int id)
		{
			
			 return Json(_userService.GetById(id));
		}
	}
}
