using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESF.WebClient.Filters;
using ESF.Core.Services;
using ESF.Commons.Utilities;
using WebMatrix.WebData;

namespace ESF.WebClient.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccommodationController : Controller
    {
        private readonly IParticipantService participantService;

        public AccommodationController(IParticipantService participantService)
        {
            Check.IsNotNull(participantService, "participantService may not be null");

            this.participantService = participantService;
        }

        [HttpGet]
        public ActionResult RequestAccommodation(Guid id)
        {
            ViewBag.Message = "This is where you request Accommodation.";
            ViewBag.ParticipantId = id;

            return View();
        }

        [HttpGet]
        public ActionResult ViewAccommodation(Guid? id)
        {
            if (id.GetValueOrDefault(Guid.Empty) == Guid.Empty)
            {
                var userId = WebSecurity.CurrentUserId;

                Check.IsTrue(userId > 0, "");

                id = participantService.RetrieveParticipantIdByUserId(userId);
            }

            if (id.GetValueOrDefault(Guid.Empty) == Guid.Empty && WebSecurity.IsAuthenticated)
            {
                TempData["createparticipantmessage"] = "Please complete your registration";
                return RedirectToAction("CreateParticipant", "Participant");
            }

            // TODO : handle the scenario where an id is manually entered in the url
            if (id.GetValueOrDefault(Guid.Empty) == Guid.Empty && WebSecurity.IsAuthenticated)
            {
                TempData["createparticipantmessage"] = "Please complete your registration";
                return RedirectToAction("CreateParticipant", "Participant");
            }

            ViewBag.Message = "This is where you view your Accommodation details.";
            ViewBag.ParticipantId = id.Value;

            return View();
        }
    }
}
