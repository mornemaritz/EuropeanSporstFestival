using System;
using System.Collections.Generic;

namespace ESF.Core.Services
{
    public class ScheduledSportEventDetail
    {
        private readonly IList<Guid> overLappingEventIds = new List<Guid>();

        public Guid ScheduledSportEventId { get; set; }
        public string ScheduledSportEventName { get; set; }
        public bool CurrentParticipantAlreadySignedUp { get; set; }
        public bool IsSelectable { get; set; }

        public IList<Guid> OverLappingEventIds
        {
            get { return overLappingEventIds; }
        }
    }
}
