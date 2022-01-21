using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class ParticipantController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IParticipantService _participantService;

		public ParticipantController(IParticipantService participantService)
		{
			_participantService = participantService;
		}

		[HttpGet("find/{id}")]
		public JsonResult FindByName(int id)
		{
			return Json(_participantService.GetById(id));
		}
	}
}
