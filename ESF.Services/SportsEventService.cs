using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Services;
using System.Collections.ObjectModel;

namespace ESF.Services
{
    public class SportsEventService : ISportsEventService
    {
        public ICollection<SportsEventItem> FindSportEventsAvailableToParticipant(Guid participantId)
        {
            return new Collection<SportsEventItem> 
            { 
                new SportsEventItem { SportsEventId = Guid.NewGuid(), SportsEventName = "Football" }, 
                new SportsEventItem { SportsEventId = Guid.NewGuid(), SportsEventName = "Cricket" },
                new SportsEventItem { SportsEventId = Guid.NewGuid(), SportsEventName = "Tennis" },
                new SportsEventItem { SportsEventId = Guid.NewGuid(), SportsEventName = "Squash" } 
            };
        }

        public SportEventParticipantModel SignUpParticipant(SportsEventSignUpModel model)
        {
            return new SportEventParticipantModel { SportEventParticipantId = Guid.NewGuid(), RequiresTeamAssignment = false };
        }
    }
}
