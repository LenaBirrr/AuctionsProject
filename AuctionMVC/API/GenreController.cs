using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IGenreService _genreService;

		public GenreController(IGenreService genreService)
		{
			_genreService = genreService;
		}

		[HttpGet("find/{name}")]
		public JsonResult FindByName(string name)
		{
			return Json(_genreService.FindByName(name));
		}
	}
}
