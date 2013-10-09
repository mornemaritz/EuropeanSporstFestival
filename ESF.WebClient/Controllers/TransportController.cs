using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESF.WebClient.Filters;
using WebMatrix.WebData;
using ESF.Commons.Utilities;
using ESF.Core.Services;

namespace ESF.WebClient.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class TransportController : Controller
    {
        private readonly IParticipantService participantService;

        public TransportController(IParticipantService participantService)
        {
            Check.IsNotNull(participantService, "participantService may not be null");

            this.participantService = participantService;
        }

        [HttpGet]
        public ActionResult RequestTransport(Guid id)
        {
            ViewBag.Message = "This is where you request Transport.";
            ViewBag.ParticipantId = id;

            return View();
        }

        [HttpGet]
        public ActionResult ViewTransport(Guid? id)
        {
            ParticipantDetailsModel participantModel;

            if (id.GetValueOrDefault(Guid.Empty) == Guid.Empty)
            {
                var userId = WebSecurity.CurrentUserId;

                Check.IsTrue(userId > 0, "");

                participantModel = participantService.RetrieveParticipantByUserId(userId);
            }
            else
                participantModel = participantService.RetrieveParticipant(id.Value);

            // TODO : handle the scenario where an id is manually entered in the url
            if (participantModel == null)
            {
                TempData["createparticipantmessage"] = "Please complete your registration";
                return RedirectToAction("CreateParticipant", "Participant");
            }
            
            ViewBag.Message = "This is where you view your Transport details.";
            ViewBag.ParticipantId = participantModel.ParticipantId;

            return View();
        }

    }
}
