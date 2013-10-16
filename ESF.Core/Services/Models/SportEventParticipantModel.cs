using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Core.Services
{
    public class SportEventParticipantModel
    {
        public SportEventParticipantModel(Guid sportEventParticipantId, string scheduledSportEventName)
        {
            ScheduledSportEventName = scheduledSportEventName;
            SportEventParticipantId = sportEventParticipantId;
        }
        public Guid SportEventParticipantId { get; private set; }
        public string ScheduledSportEventName { get; private set; }
        public bool RequiresTeamAssignment { get; set; }
    }
}
