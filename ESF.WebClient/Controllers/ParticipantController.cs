using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ESF.WebClient.Models;
using ESF.Core.Services;
using ESF.Commons.Utilities;
using WebMatrix.WebData;
using ESF.WebClient.Filters;

namespace ESF.WebClient.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class ParticipantController : Controller
    {
        private readonly IParticipantService participantService;

        public ParticipantController(IParticipantService participantService)
        {
            Check.IsNotNull(participantService, "participantService may not be null");

            this.participantService = participantService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult ViewParticipant(Guid? id)
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
                return RedirectToAction("CreateParticipant");
            }

            ViewData.Model = participantModel;

            return View();
        }

        [HttpGet]
        public ActionResult CreateParticipant()
        {
            if (TempData["createparticipantmessage"] != null)
                ModelState.AddModelError("", TempData["createparticipantmessage"].ToString());

            ViewBag.Months = Enum.GetNames(typeof(Month))
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x, Text = x });

            ViewBag.Genders = Enum.GetNames(typeof(Gender))
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x, Text = x });

            return View();
        }

        [HttpPost]
        public ActionResult SaveParticipant(ParticipantDetailsModel model)
        {
            model.UserId = WebSecurity.CurrentUserId;

            participantService.SaveParticipant(model);

            return RedirectToAction("ViewParticipant");
        }

        [HttpGet]
        public ActionResult EditParticipant(Guid id)
        {
            ViewData.Model = participantService.RetrieveParticipant(id);

            ViewBag.Genders = Enum.GetNames(typeof(Gender))
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x, Text = x });

            return View();
        }

        [HttpPut]
        public ActionResult UpdateParticipant(ParticipantDetailsModel model)
        {
            Check.IsNotNull(model, "Model may not be null");

            participantService.UpdateParticipant(model);

            return RedirectToAction("ViewParticipant");
        }
    }
}
