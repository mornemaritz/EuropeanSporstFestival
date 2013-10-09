using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Core.Services
{
    public interface ISportsEventService
    {
        ICollection<SportsEventItem> FindSportEventsAvailableToParticipant(Guid participantId);

        SportEventParticipantModel SignUpParticipant(SportsEventSignUpModel model);

        IList<SportEventParticipantModel> RetrieveSignedUpSportsEvents(Guid participantId);
    }
}
