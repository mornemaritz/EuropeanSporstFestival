using System;
using System.Collections.Generic;

namespace ESF.Core.Services
{
    public interface ISportsEventService
    {
        ICollection<SportsEventItem> FindSportEventsAvailableToParticipant(Guid participantId);
        SportEventParticipantModel SignUpParticipant(SportsEventSignUpModel model);
        IList<SportEventParticipantModel> RetrieveSignedUpSportsEvents(Guid participantId);
        void MakeParticipantAvailableForTeamAllocation(Guid sportEventParticpantId);
        ExistingTeamModel AttemptAllocationToNamedTeam(ExistingTeamModel model);
        TeamCreateModel CreateNewSportEventTeam(TeamCreateModel teamCreateModel);
        IList<TeamMemberDetail> ListTeamMembers(Guid sportEventTeamId);
        void ConfirmTeamMember(Guid sportEventParticipantId);
        void AddNewTeamMember(NewTeamMemberModel model);
        IList<DateTime> FindScheduledDays();
    }
}
