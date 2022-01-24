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
    public class ParticipantController : Controller
    {
        private readonly IParticipantService _participantService;
        private readonly IAuctionService _auctionService;
        private readonly IUserService _userService;


        public ParticipantController(IParticipantService participantService, IAuctionService auctionService,
            IUserService userService)
        {
            _participantService = participantService;
            _auctionService = auctionService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var participants = _participantService.GetAll();
            return View(participants);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _participantService.DeleteParticipant(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Create()
        {
            ViewData["AuctionIds"] = new SelectList(_auctionService.GetAll(),
               dataValueField: nameof(AuctionDto.Id),
               dataTextField: nameof(AuctionDto.Id));
            ViewData["UserIds"] = new SelectList(_userService.GetAll(),
                dataValueField: nameof(UserDto.Id),
                dataTextField: nameof(UserDto.Id));
            return View();
        }
        public IActionResult Edit(int id)
        {
            var dto = _participantService.GetById(id);
            ViewData["AuctionIds"] = new SelectList(_auctionService.GetAll(),
               dataValueField: nameof(AuctionDto.Id),
               dataTextField: nameof(AuctionDto.Id));
            ViewData["UserIds"] = new SelectList(_userService.GetAll(),
                dataValueField: nameof(UserDto.Id),
                dataTextField: nameof(UserDto.Id));
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParticipantDto dto)
        {
            if (!ModelState.IsValid)
            {

                return View(dto);
            }
            foreach(var p in _participantService.GetByAuction(dto.AuctionId))
            {
                if(p.UserId==dto.UserId)
                {
                    return View("NotAllowedParticipant");
                }
            }


            _participantService.CreateParticipant(dto);

            return RedirectToAction(nameof(Index));
        }
    }
}
