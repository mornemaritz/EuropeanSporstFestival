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
    public class SportsEventController : Controller
    {
        private readonly IParticipantService participantService;
        private readonly ISportsEventService sportsEventService;

        public SportsEventController(IParticipantService participantService, ISportsEventService sportsEventService)
        {
            Check.IsNotNull(participantService, "participantService may not be null");
            Check.IsNotNull(sportsEventService, "sportsEventService may not be null");

            this.participantService = participantService;
            this.sportsEventService = sportsEventService;
        }

        [HttpGet]
        public ActionResult SignUp(Guid id)
        {
            var availableSportsEvents = sportsEventService.FindSportEventsAvailableToParticipant(id);

            ViewBag.SportsEvents = availableSportsEvents.AsEnumerable()
                .Select(x => new SelectListItem 
                { 
                        Value = x.ScheduledSportsEventId.ToString(), 
                        Text = x.ScheduledSportsEventName 
                });

            ViewData.Model = new SportsEventSignUpModel { ParticipantId = id };

            ViewBag.Message = "Please select the sports event you would like to sign up for.";

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SportsEventSignUpModel model)
        {
            var sportEventParticipantModel = sportsEventService.SignUpParticipant(model);

            if (sportEventParticipantModel.RequiresTeamAssignment)
            {
                return RedirectToAction("SportEventTeamSelect", new { id = sportEventParticipantModel.SportEventParticipantId });
            }

            return RedirectToAction("ViewSportsEvents", new { id = model.ParticipantId });
        }

        [HttpGet]
        public ActionResult SportEventTeamSelect(Guid id)
        {
            ViewData.Model = new TeamSelectionModel { ScheduledSportEventParticipantId = id };

            return View();
        }

        [HttpPost]
        public ActionResult SportEventTeamSelect(TeamSelectionModel model)
        {
            switch (model.TeamSelectionOption)
            {
                case 1: // Create Team
                    break;
                case 2: // Join Team
                    return RedirectToAction("SportEventSelectExistingTeam", new { Id = model.ScheduledSportEventParticipantId });
                case 3: // Available for allocation
                    sportsEventService.MakeParticipantAvailableForTeamAllocation(model.ScheduledSportEventParticipantId);

                    TempData["TeamSelectionConfirmationMessage"] = "Your interest in being allocated to a team has been registered.";

                    return RedirectToAction("TeamSelectionConfirmation");
            }

            return View();
        }

        [HttpGet]
        public ActionResult SportEventSelectExistingTeam(Guid id)
        {
            ViewData.Model = TempData["model"] ?? new ExistingTeamModel { SportEventParticipantId = id };

            ViewBag.TeamAllocationMessage = TempData["TeamAllocationMessage"];

            return View();
        }

        [HttpPost]
        public ActionResult SportEventSelectExistingTeam(ExistingTeamModel model)
        {
            model = sportsEventService.AttemptAllocationToNamedTeam(model);

            if (!model.TeamExists)
            {
                TempData["model"] = model;
                TempData["TeamAllocationMessage"] = "No team currently exists with the name you specified";

                return RedirectToAction("SportEventSelectExistingTeam");
            }

            TempData["TeamSelectionConfirmationMessage"] = "The captain of the team you specified will be notified of your request to join the team.";

            return RedirectToAction("TeamSelectionConfirmation");
        }

        [HttpGet]
        public ActionResult TeamSelectionConfirmation()
        {
            ViewBag.ConfirmationMessage = TempData["TeamSelectionConfirmationMessage"];

            return View();
        }

        [HttpGet]
        public ActionResult ViewSportsEvents(Guid? id)
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

            if (participantModel == null && WebSecurity.IsAuthenticated)
            {
                TempData["createparticipantmessage"] = "Please complete your registration";
                return RedirectToAction("CreateParticipant","Participant");
            }

            var sportsEvents = sportsEventService.RetrieveSignedUpSportsEvents(participantModel.ParticipantId);

            ViewData.Model = sportsEvents;
            ViewBag.Message = string.Format("{0}Sport Events that you are signed up for.", sportsEvents.Any() ? string.Empty : "This is where you view the ");
            ViewBag.ParticipantId = participantModel.ParticipantId;

            return View();
        }
    }
}
