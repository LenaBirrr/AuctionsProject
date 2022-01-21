using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class StateController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IStateService _stateService;

		public StateController(IStateService stateService)
		{
			_stateService = stateService;
		}

		[HttpGet("find/{name}")]
		public JsonResult FindByName(string name)
		{
			return Json(_stateService.FindByName(name));
		}
	}
}
