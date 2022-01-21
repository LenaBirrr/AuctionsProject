using Business.Interop.Data;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionMVC.Controllers
{
    public class AuctionItemController : Controller
    {
        private readonly IAuctionItemService _auctionItemService;
        private readonly IGenreService _genreService;
        private readonly IUserService _userService;
        private readonly IEpochService _epochService;
        private readonly IStateService _stateService;


        public AuctionItemController(IAuctionItemService auctionItemService,
            IGenreService genreService, IUserService userService,
            IEpochService epochService,
            IStateService stateService)
        {
            _auctionItemService = auctionItemService;
            _genreService = genreService;
            _userService = userService;
            _epochService = epochService;
            _stateService = stateService;

        }
        public ActionResult Delete(int id)
        {
            try
            {
                _auctionItemService.DeleteAuctionItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var auctionItem=_auctionItemService.GetById(id);
            ViewData["GenreIds"] = new SelectList(_genreService.GetAll(),
               dataValueField: nameof(GenreDto.Id),
               dataTextField: nameof(GenreDto.Name));
            ViewData["UserIds"] = new SelectList(_userService.GetAll(),
                dataValueField: nameof(UserDto.Id),
                dataTextField: nameof(UserDto.Id));
            ViewData["EpochIds"] = new SelectList(_epochService.GetAll(),
                dataValueField: nameof(EpochDto.Id),
                dataTextField: nameof(EpochDto.Name));
            ViewData["StateIds"] = new SelectList(_stateService.GetAll(),
                dataValueField: nameof(StateDto.Id),
                dataTextField: nameof(StateDto.Id));
            return View(auctionItem);
        }

        public IActionResult Create()
        {
            ViewData["GenreIds"] = new SelectList(_genreService.GetAll(),
                dataValueField:nameof(GenreDto.Id),
                dataTextField:nameof(GenreDto.Name));
            ViewData["UserIds"] = new SelectList(_userService.GetAll(),
                dataValueField: nameof(UserDto.Id),
                dataTextField: nameof(UserDto.Id));
            ViewData["EpochIds"] = new SelectList(_epochService.GetAll(),
                dataValueField: nameof(EpochDto.Id),
                dataTextField: nameof(EpochDto.Name));
            ViewData["StateIds"] = new SelectList(_stateService.GetAll(),
                dataValueField: nameof(StateDto.Id),
                dataTextField: nameof(StateDto.Id));
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuctionItemDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _auctionItemService.CreateAuctionItem(dto);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index()
        {
            var auctionItems = _auctionItemService.GetAll();
            return View(auctionItems);
        }
    }
}
