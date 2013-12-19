using System;

namespace ESF.Core.Services
{
    public class ScheduledSportEventDetail
    {
        public Guid ScheduledSportEventId { get; set; }
        public string ScheduledSportEventName { get; set; }
        public int FestivalDay { get; set; }
        public string Day { get; set; }
        public string Period { get; set; }
        public bool CurrentParticipantAlreadySignedUp { get; set; }
        public bool IsSelectable { get; set; }

        public string OverLappingEventIds { get; set; }
    }
}
