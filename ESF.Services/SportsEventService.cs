using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Services;
using System.Collections.ObjectModel;
using ESF.Core.Repositories;
using ESF.Domain;

namespace ESF.Services
{
    public class SportsEventService : ISportsEventService
    {
        private readonly ISportEventRepository sportEventRepository;
        private readonly IParticipantRepository participantRepository;
        private readonly ISportEventParticipantRepository sportEventParticipantRepository;

        public SportsEventService(ISportEventRepository sportEventRepository, 
            IParticipantRepository participantRepository,
            ISportEventParticipantRepository sportEventParticipantRepository)
        {
            this.sportEventRepository = sportEventRepository;
            this.participantRepository = participantRepository;
            this.sportEventParticipantRepository = sportEventParticipantRepository;
        }
        public ICollection<SportsEventItem> FindSportEventsAvailableToParticipant(Guid participantId)
        {
            var participant = participantRepository.RetrieveParticipant(participantId);

            var sportEvents = sportEventRepository.FindSportEventsAvailableToParticipant(participant.Gender);
            var sportEventItems = new Collection<SportsEventItem>();

            foreach (var sportEvent in sportEvents)
            {
                sportEventItems.Add(new SportsEventItem { SportsEventId = sportEvent.Id, SportsEventName = sportEvent.Name });
            }

            return sportEventItems;
        }

        public SportEventParticipantModel SignUpParticipant(SportsEventSignUpModel model)
        {
            var participant = participantRepository.RetrieveParticipant(model.ParticipantId);
            var sportEvent = sportEventRepository.RetrieveById(model.SportsEventId);

            var sportEventParticipant = new SportEventParticipant(sportEvent, participant);

            sportEventParticipant = sportEventParticipantRepository.Save(sportEventParticipant);

            return new SportEventParticipantModel { SportEventParticipantId = sportEventParticipant.Id, RequiresTeamAssignment = false };
        }

        public IList<SportEventParticipantModel> RetrieveSignedUpSportsEvents(Guid participantId)
        {
            var sportEventParticipants = sportEventParticipantRepository.FindSignedUpSportsEvents(participantId);

            var sportEventParticipantModels = new List<SportEventParticipantModel>();

            foreach (var sportEventParticipant in sportEventParticipants)
            {
                sportEventParticipantModels.Add(new SportEventParticipantModel{SportName = sportEventParticipant.SportEvent.Name});
            }

            return sportEventParticipantModels;
        }
    }
}
