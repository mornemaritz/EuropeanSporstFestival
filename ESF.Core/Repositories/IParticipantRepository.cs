using System;
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
    }
}
