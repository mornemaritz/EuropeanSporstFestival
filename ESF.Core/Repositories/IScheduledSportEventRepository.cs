using System;
using System.Collections.Generic;
using ESF.Commons.Utilities;
using ESF.Core.Services;
using ESF.Domain;

namespace ESF.Core.Repositories
{
    public interface IScheduledSportEventRepository
    {
        ScheduledSportEvent Load(Guid scheduledSportEventId);
        ScheduledSportEvent RetrieveScheduledSportEventWithSportDetails(Guid scheduledSportEventId);
        IList<ScheduledSportEvent> RetrieveScheduledSportEventsExcluding(Guid[] scheduledSportEventToExcludeIds);
        IList<DateTime> FindScheduledDays();
        IList<ScheduledSportEvent> RetrieveSignedUpSportsEvents(Guid participantId);
        IList<ScheduledSportEvent> RetrieveScheduledSportEventsForAgeAndGender(int age, Gender gender);
        IList<ScheduleOverLapDetail> FindAllScheduleOverLapDetails();
        IList<ScheduleOverLapDetail> FindScheduleOverLapDetails(Guid[] scheduledSportEventIds);
    }
}
