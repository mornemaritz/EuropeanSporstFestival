using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Domain
{
    public class ParticipantSportEvent
    {
        private Guid id;
        private ScheduledSportEvent scheduledSportEvent;
        private Participant participant;

        protected ParticipantSportEvent() { }

        public ParticipantSportEvent(ScheduledSportEvent scheduledSportEvent, Participant participant)
        {
            this.scheduledSportEvent = scheduledSportEvent;
            this.participant = participant;
        }

        public virtual Guid Id 
        {
            get { return id; }
        }

        public virtual ScheduledSportEvent ScheduledSportEvent 
        {
            get { return scheduledSportEvent; }
        }

        public virtual Participant Participant
        {
            get { return participant; }
        }
    }
}
