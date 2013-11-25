using System;

namespace ESF.Domain
{
    public class ScheduledSportEventOverLap
    {
        private Guid id;
        private ScheduledSportEvent scheduledSportEvent;
        private ScheduledSportEvent overLappingScheduledSportEvent;

        public virtual Guid Id
        {
            get { return id; }
        }

        public virtual ScheduledSportEvent ScheduledSportEvent
        {
            get { return scheduledSportEvent; }
            set { scheduledSportEvent = value; }
        }

        public virtual ScheduledSportEvent OverLappingScheduledSportEvent
        {
            get { return overLappingScheduledSportEvent; }
            set { overLappingScheduledSportEvent = value; }
        }
    }
}
