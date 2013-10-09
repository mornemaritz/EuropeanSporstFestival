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

        public virtual Guid Id 
        {
            get { return id; }
        }

        public virtual SportEvent SportEvent 
        {
            get { return sportEvent; }
            set { sportEvent = value; }
        }

        public virtual Participant Participant
        {
            get { return Participant; }
            set { Participant = value; }
        }
    }
}
