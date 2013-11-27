using System;

namespace ESF.Core.Services
{
    public class ScheduleOverLapDetail
    {
        public ScheduleOverLapDetail(Guid scheduledSportEventId, Guid overLappingScheduledSportEventId)
        {
            ScheduledSportEventId = scheduledSportEventId;
            OverLappingScheduledSportEventId = overLappingScheduledSportEventId;
        }

        public Guid ScheduledSportEventId { get; set; }
        public Guid OverLappingScheduledSportEventId { get; set; }
    }
}