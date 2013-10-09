using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface IParticipantRepository
    {
        Participant RetrieveParticipantByUserId(int userId);
        Participant RetrieveParticipant(Guid participantId);
        void Save(Participant participant);
        void Update(Participant participant);
        Guid RetrieveParticipantIdByUserId(int userId);
    }
}
