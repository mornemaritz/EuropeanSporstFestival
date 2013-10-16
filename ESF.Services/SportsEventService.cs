using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Services;
using System.Collections.ObjectModel;
using ESF.Core.Repositories;
using ESF.Domain;
using ESF.Commons.Repository;

namespace ESF.Services
{
    public class SportsEventService : ISportsEventService
    {
        private readonly IRepository<Sport> sportEventRepository;
        private readonly IRepository<Participant> participantRepository;
        private readonly IScheduledSportEventParticipantRepository sportEventParticipantRepository;
        private readonly IScheduledSportEventRepository scheduledSportEventRepository;

        public SportsEventService(IRepository<Sport> sportEventRepository,
            IRepository<Participant> participantRepository,
            IScheduledSportEventParticipantRepository sportEventParticipantRepository,
            IScheduledSportEventRepository scheduledSportEventRepository)
        {
            this.sportEventRepository = sportEventRepository;
            this.participantRepository = participantRepository;
            this.sportEventParticipantRepository = sportEventParticipantRepository;
            this.scheduledSportEventRepository = scheduledSportEventRepository;
        }

        public ICollection<SportsEventItem> FindSportEventsAvailableToParticipant(Guid participantId)
        {
            return scheduledSportEventRepository.FindSportEventsAvailableToParticipant(participantId);
        }

        public SportEventParticipantModel SignUpParticipant(SportsEventSignUpModel model)
        {
            var participant = participantRepository.Get(model.ParticipantId);

            var scheduledSportEvent = scheduledSportEventRepository.RetrieveScheduledSportEventWithSportDetails(model.ScheduledSportsEventId);

            var sportEventParticipant = participant.SignUpToScheduledSportEvent(scheduledSportEvent);

            //var sportEventParticipant = new ParticipantSportEvent(scheduledSportEvent, participant);
            
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
    }
}
