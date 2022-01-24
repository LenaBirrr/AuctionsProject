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
    public class LotController : Controller
    {
        private readonly ILotService _lotService;
        private readonly IParticipantService _participantService;
        private readonly IAuctionItemService _auctionItemService;
        private readonly IAuctionService _auctionService;


        public LotController(ILotService lotService, IAuctionService auctionService,
             IParticipantService participantService, IAuctionItemService auctionItemService)
        {
            _lotService = lotService;
            _participantService = participantService;
            _auctionItemService=auctionItemService;
            _auctionService = auctionService;
        }
        public IActionResult Index()
        {
            var lots = _lotService.GetAll();
            return View(lots);
        }

        public ActionResult Delete(int id)
        {
          
                _lotService.DeleteLot(id);
                return RedirectToAction(nameof(Index));
           
        }

        public IActionResult Edit(int id)
        {
            var dto = _lotService.GetById(id);
            ViewData["AuctionIds"] = new SelectList(_auctionService.GetAll(),
             dataValueField: nameof(AuctionDto.Id),
             dataTextField: nameof(AuctionDto.Id));
            return View(dto);

        }
        public IActionResult EditSecondStep(int id)
        {

            var dto = _lotService.GetById(id);
            ViewData["AuctionIds"] = new SelectList(_auctionService.GetAll(),
              dataValueField: nameof(AuctionDto.Id),
              dataTextField: nameof(AuctionDto.Id));
            ViewData["ParticipantIds"] = new SelectList(_participantService.GetByAuction(dto.AuctionId),
            dataValueField: nameof(ParticipantDto.Id),
                dataTextField: nameof(ParticipantDto.Id));
            ViewData["AuctionItemIds"] = new SelectList(_auctionItemService.GetAll(),
               dataValueField: nameof(AuctionItemDto.Id),
               dataTextField: nameof(AuctionItemDto.Id));
            return View(dto);
        }

        public IActionResult Create()
        {
            ViewData["AuctionIds"] = new SelectList(_auctionService.GetAll(),
               dataValueField: nameof(AuctionDto.Id),
               dataTextField: nameof(AuctionDto.Id));
            ViewData["ParticipantIds"] = new SelectList(_participantService.GetAll(),
                dataValueField: nameof(ParticipantDto.Id),
                dataTextField: nameof(ParticipantDto.Id));
            ViewData["AuctionItemIds"] = new SelectList(_auctionItemService.GetAll(),
               dataValueField: nameof(AuctionItemDto.Id),
               dataTextField: nameof(AuctionItemDto.Id));
            return View();
        }

        public ActionResult CreateSecondStep(LotDto dto)
        {
            if (ModelState.IsValid)
            {
                _lotService.CreateLot(dto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LotDto dto)
        {
            if (ModelState.IsValid)
            {
                ViewData["ParticipantIds"] = new SelectList(_participantService.GetByAuction(dto.AuctionId),
                  dataValueField: nameof(ParticipantDto.Id),
                  dataTextField: nameof(ParticipantDto.Id));
                ViewData["AuctionItemIds"] = new SelectList(_auctionItemService.GetAll(),
                   dataValueField: nameof(AuctionItemDto.Id),
                   dataTextField: nameof(AuctionItemDto.Id));
                return View("CreateSecondStep", dto);
            }
            return View();
        }
    }
}
