using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface ISportEventParticipantRepository
    {
        SportEventParticipant Save(SportEventParticipant sportEventParticipant);

        IList<SportEventParticipant> FindSignedUpSportsEvents(Guid participantId);
    }
}
