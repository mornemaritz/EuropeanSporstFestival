using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Core.Services
{
    public class SportsEventItem
    {
        public SportsEventItem(Guid scheduledSportsEventId, string sportsEventName)
        {
            ScheduledSportsEventId = scheduledSportsEventId;
            SportsEventName = sportsEventName;
        }

        public Guid ScheduledSportsEventId { get; private set; }
        public string SportsEventName { get; private set; }
    }
}
