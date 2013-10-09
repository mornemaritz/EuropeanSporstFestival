using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Domain
{
    public class SportEventParticipant
    {
        private Guid id;
        private SportEvent sportEvent;
        private Participant participant;

        protected SportEventParticipant() { }

        public SportEventParticipant(SportEvent sportEvent, Participant participant)
        {
            this.sportEvent = sportEvent;
            this.participant = participant;
        }

        public virtual Guid Id 
        {
            get { return id; }
        }

        public virtual SportEvent SportEvent 
        {
            get { return sportEvent; }
        }

        public virtual Participant Participant
        {
            get { return participant; }
        }
    }
}
