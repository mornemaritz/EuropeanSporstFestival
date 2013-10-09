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
    public class EntertainmentController : Controller
    {
        private readonly IParticipantService participantService;

        public EntertainmentController(IParticipantService participantService)
        {
            Check.IsNotNull(participantService, "participantService may not be null");

            this.participantService = participantService;
        }

        [HttpGet]
        public ActionResult SignUp(Guid id)
        {
            ViewBag.Message = "This is where you Sign Up for Entertainment.";
            ViewBag.ParticipantId = id;

            return View();
        }

        [HttpGet]
        public ActionResult ViewEntertainment(Guid? id)
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

            ViewBag.Message = "This is where you view the entertainment events that you have signed up for.";
            ViewBag.ParticipantId = participantModel.ParticipantId;

            return View();
        }

    }
}
