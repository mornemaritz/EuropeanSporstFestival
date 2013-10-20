using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Domain;
using ESF.Core.Services;

namespace ESF.Core.Repositories
{
    public interface IScheduledSportEventParticipantRepository
    {
        ScheduledSportEventParticipant Save(ScheduledSportEventParticipant sportEventParticipant);

        IList<SportEventParticipantModel> FindSignedUpSportsEvents(Guid participantId);

        IList<ScheduledSportEventParticipant> RetrieveSignedUpSportsEvents(Guid participantId);

        ScheduledSportEventParticipant Get(Guid sportEventParticpantId);

        void Update(ScheduledSportEventParticipant sportEventParticipant);
    }
}
