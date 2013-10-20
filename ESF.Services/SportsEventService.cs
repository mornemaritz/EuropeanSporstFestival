using System;
using System.Collections.Generic;
using System.Linq;
using ESF.Core.Services;
using ESF.Core.Repositories;
using ESF.Domain;
using ESF.Commons.Repository;
using ESF.Commons.Utilities;

namespace ESF.Services
{
    public class SportsEventService : ISportsEventService
    {
        private readonly IRepository<Sport> sportEventRepository;
        private readonly IRepository<Participant> participantRepository;
        private readonly IScheduledSportEventParticipantRepository sportEventParticipantRepository;
        private readonly IScheduledSportEventRepository scheduledSportEventRepository;
        private readonly ISportEventTeamRepository sportEventTeamRepository;

        public SportsEventService(IRepository<Sport> sportEventRepository,
            IRepository<Participant> participantRepository,
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

            return new SportEventParticipantModel(sportEventParticipant.Id, scheduledSportEvent.Sport.Name) 
            { 
                RequiresTeamAssignment = scheduledSportEvent.IsTeamEvent 
            };
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

            var sportEventTeam = sportEventTeamRepository.FindByName(model.TeamName, sportEventParticipant.ScheduledSportEvent.Id);

            if (sportEventTeam != null)
            {
                sportEventTeam.AddUnconfirmedTeamMember(sportEventParticipant);
                sportEventParticipantRepository.Update(sportEventParticipant);
                sportEventTeamRepository.Update(sportEventTeam);

                model.TeamExists = true;
            }
            else
                model.TeamExists = false;

            return model;
        }
    }
}
