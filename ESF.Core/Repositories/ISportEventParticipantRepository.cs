using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface ISportEventParticipantRepository
    {
        ParticipantSportEvent Save(ParticipantSportEvent sportEventParticipant);

        IList<ParticipantSportEvent> FindSignedUpSportsEvents(Guid participantId);
    }
}
