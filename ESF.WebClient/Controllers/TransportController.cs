using System;
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
        private readonly ITransportService transportService;

        public TransportController(IParticipantService participantService, 
            ITransportService transportService)
        {
            Check.IsNotNull(participantService, "participantService may not be null");
            Check.IsNotNull(transportService, "transportService may not be null");

            this.participantService = participantService;
            this.transportService = transportService;
        }

        [HttpGet]
        public ActionResult RequestTransport(Guid id)
        {
            ViewBag.PickupPoints = transportService.FindPickupPoints();
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
