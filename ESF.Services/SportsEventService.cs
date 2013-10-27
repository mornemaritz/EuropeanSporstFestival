using System;
using System.Collections.Generic;
using System.Linq;
using ESF.Core.Services;
using ESF.Core.Repositories;
using ESF.Domain;
using ESF.Commons.Repository;
using ESF.Commons.Utilities;
using ESF.Commons.Exceptions;

namespace ESF.Services
{
    public class SportsEventService : ISportsEventService
    {
        private readonly IRepository<Sport> sportEventRepository;
        private readonly IParticipantRepository participantRepository;
        private readonly IScheduledSportEventParticipantRepository sportEventParticipantRepository;
        private readonly IScheduledSportEventRepository scheduledSportEventRepository;
        private readonly ISportEventTeamRepository sportEventTeamRepository;

        public SportsEventService(IRepository<Sport> sportEventRepository,
            IParticipantRepository participantRepository,
            IScheduledSportEventParticipantRepository sportEventParticipantRepository,
            IScheduledSportEventRepository scheduledSportEventRepository,
            ISportEventTeamRepository sportEventTeamRepository)
        {
            Check.IsNotNull(sportEventRepository, "sportEventRepository may not be null");
            Check.IsNotNull(participantRepository, "participantRepository may not be null");
            Check.IsNotNull(sportEventParticipantRepository, "sportEventParticipantRepository may not be null");
            Check.IsNotNull(scheduledSportEventRepository, "scheduledSportEventRepository may not be null");
            Check.IsNotNull(sportEventTeamRepository, "sportEventTeamRepository may not be null");

            this.sportEventRepository = sportEventRepository;
            this.participantRepository = participantRepository;
            this.sportEventParticipantRepository = sportEventParticipantRepository;
            this.scheduledSportEventRepository = scheduledSportEventRepository;
            this.sportEventTeamRepository = sportEventTeamRepository;
        }

        public ICollection<SportsEventItem> FindSportEventsAvailableToParticipant(Guid participantId)
        {
            var participant = participantRepository.Get(participantId);
            var signedUpSportEvents = sportEventParticipantRepository.RetrieveSignedUpSportsEvents(participantId);
            var allSportsNotSignedUpFor = scheduledSportEventRepository.RetrieveScheduledSportEventsExcluding(signedUpSportEvents.Select(s => s.ScheduledSportEvent.Id).ToArray());

            var sportEvents = signedUpSportEvents.Select(se => se.ScheduledSportEvent).ToList();

            var scheduleFilteredSports = allSportsNotSignedUpFor.Where(x => !SchedulesOverLap(x, sportEvents));

            return scheduleFilteredSports.Where(x => 
                participant.IsWithinAgeAndGenderBracket(x.AllowedGenders, x.Date, x.MinAge, x.MaxAge))
                .Select(s => new SportsEventItem(s.Id, s.Name)).ToList();
        }

        private static bool SchedulesOverLap(ScheduledSportEvent sportEventToCheck, IEnumerable<ScheduledSportEvent> currentSportEvents)
        {
            return currentSportEvents.Any(x => x.OverLapsWith(sportEventToCheck));
        }

        public SportEventParticipantModel SignUpParticipant(SportsEventSignUpModel model)
        {
            var participant = participantRepository.Get(model.ParticipantId);

            var scheduledSportEvent = scheduledSportEventRepository.RetrieveScheduledSportEventWithSportDetails(model.ScheduledSportsEventId);

            var sportEventParticipant = participant.SignUpToScheduledSportEvent(scheduledSportEvent);
            sportEventParticipant = sportEventParticipantRepository.Save(sportEventParticipant);

            return new SportEventParticipantModel(sportEventParticipant.Id, scheduledSportEvent.Sport.Name, sportEventParticipant.TeamAllocationStatus, Guid.Empty, string.Empty, false);
        }

        public IList<SportEventParticipantModel> RetrieveSignedUpSportsEvents(Guid participantId)
        {
            return sportEventParticipantRepository.FindSignedUpSportsEvents(participantId);
        }

        public void MakeParticipantAvailableForTeamAllocation(Guid sportEventParticpantId)
        {
            var sportEventParticipant = sportEventParticipantRepository.Get(sportEventParticpantId);

            sportEventParticipant.MakeAvailableForTeamAllocation();

            sportEventParticipantRepository.Update(sportEventParticipant);
        }
        
        public ExistingTeamModel AttemptAllocationToNamedTeam(ExistingTeamModel model)
        {
            var sportEventParticipant = sportEventParticipantRepository.Get(model.SportEventParticipantId);
            var scheduledSportEvent = sportEventParticipant.ScheduledSportEvent;

            var sportEventTeam = sportEventTeamRepository.FindByName(model.TeamName, scheduledSportEvent.Id);

            if (sportEventTeam == null)
                throw new BusinessException(string.Format("There is no team registered for {0} with the name that you've specified.", scheduledSportEvent.Name));

            sportEventTeam.AddUnconfirmedTeamMember(sportEventParticipant);
            sportEventParticipantRepository.Update(sportEventParticipant);
            sportEventTeamRepository.Update(sportEventTeam);

            return model;
        }

        public TeamCreateModel CreateNewSportEventTeam(TeamCreateModel teamCreateModel)
        {
            var sportEventParticipant = sportEventParticipantRepository.Get(teamCreateModel.CaptainSportEventParticipantId);

            var sportEventTeam = sportEventTeamRepository.FindByName(teamCreateModel.TeamName, sportEventParticipant.ScheduledSportEvent.Id);

            if (sportEventTeam != null)
                throw new BusinessException("A team with the specified name already exists.");

            sportEventTeam = SportEventTeam.Create(sportEventParticipant, teamCreateModel.TeamName);
            sportEventTeam = sportEventTeamRepository.Save(sportEventTeam);

            teamCreateModel.SportEventTeamId = sportEventTeam.Id;

            return teamCreateModel;
        }

        public IList<TeamMemberDetail> ListTeamMembers(Guid sportEventTeamId)
        {
            return sportEventTeamRepository.ListTeamMembers(sportEventTeamId);
        }

        public void ConfirmTeamMember(Guid sportEventParticipantId)
        {
            var teamMember = sportEventParticipantRepository.Get(sportEventParticipantId);
            teamMember.ConfirmAsTeamMember();

            sportEventParticipantRepository.Update(teamMember);
        }

        public NewTeamMemberModel AddNewTeamMember(NewTeamMemberModel model)
        {
            // TODO: This whole use case implementation stinks. Setting booleans on the model to drive functionality stinks.
            // TODO: Should have a shortcut to add a team member if you knwo they already exist.
            // TODO: Combine Self SignUp and Third Party SignUp (via Adding Members to a Team) into one.
            var sportEventTeam = sportEventTeamRepository.RetrieveWithSportEventDetails(model.SportEventTeamId);
            var scheduledSportEvent = sportEventTeam.ScheduledSportEvent;

            var participant = participantRepository.RetrieveByEmailAddress(model.EmailAddress);

            if(participant != null)
            {
                var availableEvents = FindSportEventsAvailableToParticipant(participant.Id);

                if (!availableEvents.Any(e => e.ScheduledSportsEventId == scheduledSportEvent.Id))
                {
                    throw new BusinessException("A participant with the specified email address already exists and is not available due to other sport event committments.");
                }

                if (!participant.CanParticipateInSportEvent(scheduledSportEvent))
                {
                    throw new BusinessException("A participant with the specified email address already exists and cannot join your team due to the Age and Gender limitations of the sport event.");
                }

                model.ParticipantAlreadyExists = true;

                //TODO: Should disable form elements and pre-check the AddExistingParticipant checkbox
                // Only if the user unchecks the checkbox, should the form be enabled.
                if(!model.AddExistingParticipant)
                    return model;
            }
            else
            {
                participant = new Participant()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    DateOfBirth = new DateTime(model.BirthYear, (int)model.BirthMonth,model.BirthDay),
                    Gender = model.Gender
                };

                if(!participant.CanParticipateInSportEvent(scheduledSportEvent))
                {
                    throw new BusinessException("The person specified cannot join your team due to the Age and Gender limitations of the sport event.");
                }

                participant = participantRepository.Save(participant);
            }

            var scheduledSportEventParticipant = participant.SignUpToScheduledSportEvent(sportEventTeam.ScheduledSportEvent);
            sportEventParticipantRepository.Save(scheduledSportEventParticipant);

            sportEventTeam.AddConfirmedTeamMember(scheduledSportEventParticipant);
            sportEventTeamRepository.Update(sportEventTeam);

            model.ParticipantAlreadyExists = false;
            model.AddExistingParticipant = false;

            return model;
        }

        public IList<DateTime> FindScheduledDays()
        {
            return scheduledSportEventRepository.FindScheduledDays();
        }
    }
}
