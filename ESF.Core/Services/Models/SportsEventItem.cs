using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Core.Services
{
    public class SportsEventItem
    {
        public SportsEventItem(Guid scheduledSportsEventId, string scheduledsportsEventName)
        {
            ScheduledSportsEventId = scheduledSportsEventId;
            ScheduledSportsEventName = scheduledsportsEventName;
        }

        public Guid ScheduledSportsEventId { get; private set; }
        public string ScheduledSportsEventName { get; private set; }
    }
}
