using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESF.WebClient.Filters;
using ESF.Core.Services;
using ESF.Commons.Utilities;
using WebMatrix.WebData;
using ESF.Commons.Exceptions;

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
        public ActionResult ViewSportsEvents(Guid? id)
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

            var sportsEvents = sportsEventService.RetrieveSignedUpSportsEvents(id.Value);

            ViewData.Model = sportsEvents;
            ViewBag.Message = string.Format("{0}Sport Events that you are signed up for.", sportsEvents.Any() ? string.Empty : "This is where you view the ");
            ViewBag.ParticipantId = id.Value;

            return View();
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

        [HttpGet]
        public ActionResult SignUpGrid(Guid id)
        {
            ViewBag.SportsEvents = sportsEventService.FindSportsEventsWithParticipantSelection(id);

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SportsEventSignUpModel model)
        {
            var sportEventParticipantModel = sportsEventService.SignUpParticipant(model);

            if (sportEventParticipantModel.TeamAllocationStatus == TeamAllocationStatus.AllocationRequired)
            {
                TempData["SportEventTeamSelectMessage"] = "The sport you selected is a team event";

                return RedirectToAction("SportEventTeamSelect", new { id = sportEventParticipantModel.ScheduledSportEventParticipantId });
            }

            return RedirectToAction("ViewSportsEvents", new { id = model.ParticipantId });
        }

        [HttpGet]
        public ActionResult SportEventTeamSelect(Guid id)
        {
            ViewBag.SportEventTeamSelectMessage = (TempData["SportEventTeamSelectMessage"] ?? string.Empty).ToString();

            ViewData.Model = new TeamSelectionModel { ScheduledSportEventParticipantId = id };

            return View();
        }

        [HttpPost]
        public ActionResult SportEventTeamSelect(TeamSelectionModel model)
        {
            switch (model.TeamSelectionOption)
            {
                case 1: // Create Team
                    return RedirectToAction("SportEventCreateNewTeam", new { Id = model.ScheduledSportEventParticipantId });
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
        public ActionResult SportEventCreateNewTeam(Guid id)
        {
            ModelState.AddModelError(string.Empty, (TempData["TeamCreateErrorMessage"] ?? string.Empty).ToString());

            ViewData.Model = TempData["TeamCreateModel"] ?? new TeamCreateModel{ CaptainSportEventParticipantId = id };

            return View();
        }

        [HttpPost]
        public ActionResult SportEventCreateNewTeam(TeamCreateModel model)
        {
            try
            {
                model = sportsEventService.CreateNewSportEventTeam(model);
            }
            catch (BusinessException bex)
            {
                TempData["TeamCreateErrorMessage"] = bex.Message;
                TempData["TeamCreateModel"] = model;

                return RedirectToAction("SportEventCreateNewTeam", new { Id = model.CaptainSportEventParticipantId });
            }

            TempData["ManageTeamMessage"] = "Your team has been sucessfully created.";

            return RedirectToAction("ManageTeam", new { sportEventTeamId = model.SportEventTeamId });
        }

        [HttpGet]
        public ActionResult SportEventSelectExistingTeam(Guid id)
        {
            ModelState.AddModelError(string.Empty, (TempData["TeamAllocationErrorMessage"] ?? string.Empty).ToString());

            ViewData.Model = TempData["ExistingTeamModel"] ?? new ExistingTeamModel { SportEventParticipantId = id };

            return View();
        }

        [HttpPost]
        public ActionResult SportEventSelectExistingTeam(ExistingTeamModel model)
        {
            try
            {
                model = sportsEventService.AttemptAllocationToNamedTeam(model);
            }
            catch (BusinessException bex)
            {
                TempData["ExistingTeamModel"] = model;
                TempData["TeamAllocationErrorMessage"] = bex.Message;

                return RedirectToAction("SportEventSelectExistingTeam", new { Id = model.SportEventParticipantId });
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
        public ActionResult ManageTeam(Guid sportEventTeamId)
        {
            // TODO: Apply Authorisation to manage teams (only captains should be able to)
            ViewBag.SportEventTeamId = sportEventTeamId;
            ViewBag.TeamMessage = TempData["ManageTeamMessage"];

            ViewData.Model = sportsEventService.ListTeamMembers(sportEventTeamId);

            return View();
        }

        [HttpGet]
        public ActionResult ConfirmTeamMember(Guid sportEventTeamId, Guid sportEventParticipantId)
        {
            sportsEventService.ConfirmTeamMember(sportEventParticipantId);
            return RedirectToAction("ManageTeam", new { sportEventTeamId });
        }

        [HttpGet]
        public ActionResult AddTeamMember(Guid sportEventTeamId)
        {
            ModelState.AddModelError(string.Empty, (TempData["AddTeamMemberErrorMessage"] ?? string.Empty).ToString());

            ViewBag.Months = Enum.GetNames(typeof(Month))
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x, Text = x });

            ViewBag.Genders = Enum.GetNames(typeof(Gender))
                .AsEnumerable()
                .Select(x => new SelectListItem { Value = x, Text = x });

            NewTeamMemberModel model = TempData["TeamMemberModel"] as NewTeamMemberModel 
                ?? new NewTeamMemberModel { SportEventTeamId = sportEventTeamId };

            if (model.ParticipantAlreadyExists)
            {
                ViewBag.Message = "A participant with the specified email address already exists. You can add this existing participant to your team or change the details you've specified and add a new team member";
            }

            ViewData.Model = model;

            return View();
        }

        [HttpPost]
        public ActionResult AddTeamMember(NewTeamMemberModel model)
        {
            try
            {
                model = sportsEventService.AddNewTeamMember(model);

                if(model.ParticipantAlreadyExists)
                {
                    TempData["TeamMemberModel"] = model;

                    return RedirectToAction("AddTeamMember", new { sportEventTeamId = model.SportEventTeamId });
                }
            }
            catch (BusinessException bex)
            {
                TempData["AddTeamMemberErrorMessage"] = bex.Message;
                TempData["TeamMemberModel"] = model;

                return RedirectToAction("AddTeamMember", new { sportEventTeamId = model.SportEventTeamId });
            }

            return RedirectToAction("ManageTeam", new {sportEventTeamId = model.SportEventTeamId});
        }
    }
}
