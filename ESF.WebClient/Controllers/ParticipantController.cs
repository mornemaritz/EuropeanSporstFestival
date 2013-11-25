using System;
using System.Linq;
using System.Web.Mvc;
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
            ParticipantDetailsViewModel participantModel;

            if (id.GetValueOrDefault(Guid.Empty) == Guid.Empty)
            {
                var userId = WebSecurity.CurrentUserId;

                Check.IsTrue(userId > 0, "");

                participantModel = participantService.RetrieveParticipantViewModelByUserId(userId);
            }
            else
                participantModel = participantService.RetrieveParticipantViewModel(id.Value);

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

            ViewBag.Genders = Enum.GetNames(typeof(Gender))
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x, Text = x });

            ViewBag.Jamatkhanas = participantService.ListJamatkhanas()
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x.JamatkhanaId.ToString(), Text = x.JamatkhanaName });

            ViewBag.Counties = participantService.ListCounties()
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x.CountyId.ToString(), Text = x.CountyName });

            ViewBag.Countries = participantService.ListCountries()
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x.CountryId.ToString(), Text = x.CountryName });

            ViewBag.YesNo = Enum.GetNames(typeof(YesNo))
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x, Text = x });

            return View();
        }

        [HttpPost]
        public ActionResult SaveParticipant(ParticipantDetailsCreateModel model)
        {
            // TODO: Authentication rework
            model.UserId = WebSecurity.CurrentUserId;
            model.EmailAddress = WebSecurity.CurrentUserName;

            participantService.SaveParticipant(model);

            return RedirectToAction("ViewParticipant", new{ id = model.ParticipantId});
        }

        [HttpGet]
        public ActionResult EditParticipant(Guid id)
        {
            ViewData.Model = participantService.RetrieveParticipantEditModel(id);

            ViewBag.Jamatkhanas = participantService.ListJamatkhanas()
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x.JamatkhanaId.ToString(), Text = x.JamatkhanaName });

            ViewBag.Counties = participantService.ListCounties()
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x.CountyId.ToString(), Text = x.CountyName });

            ViewBag.Countries = participantService.ListCountries()
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x.CountryId.ToString(), Text = x.CountryName });

            ViewBag.YesNo = Enum.GetNames(typeof(YesNo))
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x, Text = x });

            return View();
        }

        [HttpPut]
        public ActionResult UpdateParticipant(ParticipantDetailsEditModel model)
        {
            Check.IsNotNull(model, "Model may not be null");

            participantService.UpdateParticipant(model);

            return RedirectToAction("ViewParticipant");
        }
    }
}
