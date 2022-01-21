using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuctionController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IAuctionService _auctionService;

		public AuctionController(IAuctionService auctionService)
		{
			_auctionService = auctionService;
		}

		[HttpGet("find/{id}")]
		public JsonResult FindByName(int id)
		{
			return Json(_auctionService.GetById(id));
		}
	}
}
