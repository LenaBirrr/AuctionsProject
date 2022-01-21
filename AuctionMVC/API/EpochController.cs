using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class EpochController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IEpochService _epochService;

		public EpochController(IEpochService epochService)
		{
			_epochService = epochService;
		}

		[HttpGet("find/{name}")]
		public JsonResult FindByName(string name)
		{
			return Json(_epochService.FindByName(name));
		}
	}
}
