using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Services;
using ESF.Core.Repositories;
using ESF.Commons.Utilities;
using ESF.Domain;

namespace ESF.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository participantRepository;

        public ParticipantService(IParticipantRepository participantRepository)
        {
            Check.IsNotNull(participantRepository, "participantRepository may not be null");

            this.participantRepository = participantRepository;
        }

        public void SaveParticipant(ParticipantDetailsModel model)
        {
            participantRepository.Save(new Participant { UserId = model.UserId, FirstName = model.FirstName, LastName = model.LastName });
        }

        public ParticipantDetailsModel RetrieveParticipant(Guid id)
        {
            var participant = participantRepository.RetrieveParticipant(id);

            return new ParticipantDetailsModel { ParticipantId = participant.Id, UserId = participant.UserId, FirstName = participant.FirstName, LastName = participant.LastName };
        }

        public ParticipantDetailsModel RetrieveParticipantByUserId(int userId)
        {
            var participant = participantRepository.RetrieveParticipantByUserId(userId);

            if (participant == null) return null;

            return new ParticipantDetailsModel { ParticipantId = participant.Id, UserId = participant.UserId, FirstName = participant.FirstName, LastName = participant.LastName };
        }

        public void UpdateParticipant(ParticipantDetailsModel model)
        {
            var participant = participantRepository.RetrieveParticipant(model.ParticipantId);

            participant.FirstName = model.FirstName;
            participant.LastName = model.LastName;

            participantRepository.Update(participant);
        }

        public Guid RetrieveParticipantIdByUserId(int userId)
        {
            return participantRepository.RetrieveParticipantIdByUserId(userId);
        }
    }
}
