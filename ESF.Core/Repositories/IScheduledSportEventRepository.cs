using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Services;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface IScheduledSportEventRepository
    {
        IList<SportsEventItem> FindSportEventsAvailableToParticipant(Guid participantId);

        ScheduledSportEvent Load(Guid scheduledSportEventId);

        ScheduledSportEvent RetrieveScheduledSportEventWithSportDetails(Guid scheduledSportEventId);
    }
}
