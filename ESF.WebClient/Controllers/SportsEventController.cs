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
        public ActionResult SignUpGrid(Guid id)
        {
            ViewBag.SportEventSignUpMessage = TempData["SportEventSignUpMessage"];

            var sportEvents = sportsEventService.FindSportsEventsWithParticipantSelection(id);

            ViewData.Model = sportEvents;

            ViewBag.ParticipantId = id;

            return View();
        }

        [HttpPost]
        // TODO: Get MVC Framework to Populate sportEventIds parameter.
        public ActionResult SignUpGrid(Guid participantId, Guid[] sportEventIds)
        {
            var selectedSportEventIds = new List<Guid>();

            foreach (var key in Request.Form.AllKeys.Where(x => x != "participantId"))
            {
                var sportEventGuid = Guid.Empty;
                if(Guid.TryParse(key, out sportEventGuid))
                {
                    if(Request.Form[key] == "on")
                        selectedSportEventIds.Add(sportEventGuid);
                }
            }

            if(selectedSportEventIds.Any())
            {
                try
                {
                    sportsEventService.SignUpParticipant(participantId, selectedSportEventIds);
                    return RedirectToAction("ViewSportsEvents", new {id = participantId});
                }
                catch (BusinessException bex)
                {
                    TempData["SportEventSignUpMessage"] = bex.Message;
                    RedirectToAction("SignUpGrid", new {id = participantId});
                }
            }

            TempData["SportEventSignUpMessage"] = "Please select one or more sport events.";

            return RedirectToAction("SignUpGrid", new { id = participantId });
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

        // TODO: This should actually be a POST action.
        public ActionResult DeleteSportEventParticipation(Guid participantId, Guid scheduledSportEventParticipantId)
        {
            try
            {
                sportsEventService.CancelParticipation(scheduledSportEventParticipantId);

                TempData["Message"] = "Sport Event successfully deleted";
            }
            catch (BusinessException bex)
            {
                TempData["Message"] = bex.Message;
            }

            return RedirectToAction("ViewSportsEvents", new {id = participantId});
        }
    }
}
