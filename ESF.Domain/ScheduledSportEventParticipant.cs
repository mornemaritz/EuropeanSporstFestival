using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Utilities;

namespace ESF.Domain
{
    public class ScheduledSportEventParticipant
    {
        private Guid id;
        private ScheduledSportEvent scheduledSportEvent;
        private Participant participant;
        private TeamAllocationStatus teamAllocationStatus = TeamAllocationStatus.NotApplicable;

        protected ScheduledSportEventParticipant() { }

        public ScheduledSportEventParticipant(ScheduledSportEvent scheduledSportEvent, Participant participant)
        {
            this.scheduledSportEvent = scheduledSportEvent;
            this.participant = participant;
            this.teamAllocationStatus = scheduledSportEvent.IsTeamEvent 
                ? TeamAllocationStatus.AllocationRequired 
                : TeamAllocationStatus.NotApplicable;
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

        public virtual TeamAllocationStatus TeamAllocationStatus
        {
            get { return teamAllocationStatus; }
        }

        public virtual void MakeAvailableForTeamAllocation()
        {
            teamAllocationStatus = TeamAllocationStatus.AvailableForTeamAllocation;
        }

        public virtual void MakeUnconfirmedTeamMember()
        {
            teamAllocationStatus = TeamAllocationStatus.UnconfirmedTeamMember;
        }

        public virtual void MakeConfirmedTeamMember()
        {
            teamAllocationStatus = TeamAllocationStatus.ConfirmedTeamMember;
        }
    }
}
