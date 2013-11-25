using System;
using ESF.Core.Services;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface IParticipantRepository
    {
        Participant Get(Guid participantId);
        Guid RetrieveParticipantIdByUserId(int userId);
        Participant RetrieveParticipantByUserId(int userId);
        Participant RetrieveParticipant(Guid participantId);
        Participant RetrieveByEmailAddress(string emailAddress);
        Participant Save(Participant participant);
        void Update(Participant participant);
        Participant Load(Guid participantId);

        ParticipantDetailsViewModel RetrieveParticipantViewModelByUserId(int userId);
        ParticipantDetailsViewModel RetrieveParticipantViewModel(Guid participantId);
        ParticipantDetailsEditModel RetrieveParticipantEditModel(Guid participantId);
    }
}
