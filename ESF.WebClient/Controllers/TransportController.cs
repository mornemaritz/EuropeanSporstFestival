using System;
using System.Linq;
using System.Web.Mvc;
using ESF.WebClient.Filters;
using WebMatrix.WebData;
using ESF.Commons.Utilities;
using ESF.Core.Services;
using ESF.Core.Services.Models;
using ESF.Commons.Exceptions;

namespace ESF.WebClient.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class TransportController : Controller
    {
        private readonly IParticipantService participantService;
        private readonly ITransportService transportService;
        private readonly ISportsEventService sportEventService;

        public TransportController(IParticipantService participantService, 
            ITransportService transportService, 
            ISportsEventService sportEventService)
        {
            Check.IsNotNull(participantService, "participantService may not be null");
            Check.IsNotNull(transportService, "transportService may not be null");
            Check.IsNotNull(sportEventService, "sportEventService may not be null");

            this.participantService = participantService;
            this.transportService = transportService;
            this.sportEventService = sportEventService;
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

            var transportRequests = transportService.FindParticipantTransportRequests(id.GetValueOrDefault(participantModel.ParticipantId));

            ViewData.Model = transportRequests;

            ViewBag.Message = string.Format("{0}Current Transport Requests.", transportRequests.Any() ? string.Empty : "This is where you view your ");
            ViewBag.ParticipantId = participantModel.ParticipantId;

            return View();
        }

        [HttpGet]
        public ActionResult RequestTransport(Guid id)
        {
            ViewData.Model = TempData["TransportRequestModel"] ?? new TransportRequestModel { ParticipantId = id };
            ModelState.AddModelError(string.Empty, (TempData["RequestTransportErrorMessage"] ?? string.Empty).ToString());

            var daysWithNoTransportRequests = transportService.FindDaysWithNoTransportRequests(id);
            var pickupPoints = transportService.FindPickupPoints();

            ViewBag.Days = daysWithNoTransportRequests.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Value = x.FestivalDayId.ToString(),
                    Text = x.DisplayDate
                });

            ViewBag.PickupPoints = pickupPoints.AsEnumerable()
                .Select(x => new SelectListItem
                {
                    Value = x.PickupPointId.ToString(),
                    Text = x.PickupPointName
                });


            //ViewBag.Message = "This is where you request Transport.";
            ViewBag.ParticipantId = id;

            return View();
        }

        [HttpPost]
        public ActionResult RequestTransport(TransportRequestModel transportRequestModel)
        {
            Check.IsNotNull(transportRequestModel, "transportRequestModel may not be null");

            try
            {
                transportService.CreateTransportRequest(transportRequestModel);
            }
            catch (BusinessException bex)
            {
                TempData["RequestTransportErrorMessage"] = bex.Message;
                TempData["TransportRequestModel"] = transportRequestModel;
                return RedirectToAction("RequestTransport", new { id = transportRequestModel.ParticipantId });
            }

            return RedirectToAction("ViewTransport", new { id = transportRequestModel.ParticipantId });
        }
    }
}
