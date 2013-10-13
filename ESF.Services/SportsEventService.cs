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
        private readonly IRepository<SportEvent> sportEventRepository;
        private readonly IRepository<Participant> participantRepository;
        private readonly ISportEventParticipantRepository sportEventParticipantRepository;
        private readonly IScheduledSportEventRepository scheduledSportEventRepository;

        public SportsEventService(IRepository<SportEvent> sportEventRepository,
            IRepository<Participant> participantRepository,
            ISportEventParticipantRepository sportEventParticipantRepository,
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
            var participant = participantRepository.Load(model.ParticipantId);
            var scheduledSportEvent = scheduledSportEventRepository.Load(model.ScheduledSportsEventId);

            var sportEventParticipant = new ParticipantSportEvent(scheduledSportEvent, participant);

            sportEventParticipant = sportEventParticipantRepository.Save(sportEventParticipant);

            return new SportEventParticipantModel { SportEventParticipantId = sportEventParticipant.Id, RequiresTeamAssignment = false };
        }

        public IList<SportEventParticipantModel> RetrieveSignedUpSportsEvents(Guid participantId)
        {
            var sportEventParticipants = sportEventParticipantRepository.FindSignedUpSportsEvents(participantId);

            var sportEventParticipantModels = new List<SportEventParticipantModel>();

            foreach (var sportEventParticipant in sportEventParticipants)
            {
                sportEventParticipantModels.Add(new SportEventParticipantModel{SportName = sportEventParticipant.ScheduledSportEvent.SportEvent.Name});
            }

            return sportEventParticipantModels;
        }
    }
}
