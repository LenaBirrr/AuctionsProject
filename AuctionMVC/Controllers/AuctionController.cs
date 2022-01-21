using Business.Interop.Data;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionMVC.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;
		private readonly IAuctionHouseService _auctionHouseService;

		public AuctionController(IAuctionService auctionService, IAuctionHouseService auctionHouseService)
		{
			_auctionService = auctionService;
			_auctionHouseService = auctionHouseService;
		}
		public ActionResult Edit(int id)
		{
			AuctionDto dto = _auctionService.GetById(id);
			ViewData["AuctionHouseIds"] = new SelectList(_auctionHouseService.GetAll(),
				dataValueField: nameof(AuctionHouseDto.Id),
				dataTextField: nameof(AuctionHouseDto.Name));
			return View(dto);
		}
		// GET: AuctionController
		public ActionResult Index()
		{
			var auctions = _auctionService.GetAll();
			return View(auctions);
		}

		// GET: IngredientController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: IngredientController/Create
		public ActionResult Create()
		{
			ViewData["AuctionHouseIds"] = new SelectList(_auctionHouseService.GetAll(),
				dataValueField: nameof(AuctionHouseDto.Id),
				dataTextField: nameof(AuctionHouseDto.Name));
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AuctionDto dto)
		{
			if (!ModelState.IsValid)
			{
				return View(dto);
			}

			_auctionService.CreateAuction(dto);

			return RedirectToAction(nameof(Index));
		}

		
		

		public ActionResult Delete(int id)
		{
			try
			{
				_auctionService.DeleteAuction(id);
				return RedirectToAction(nameof(Index));
			}
			catch
            {
				return View();
            }
		}

		
	}
}
