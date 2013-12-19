using System;
using System.Collections.Generic;

namespace ESF.Core.Services
{
    public interface ISportsEventService
    {
        ICollection<SportsEventItem> FindSportEventsAvailableToParticipant(Guid participantId);
        IList<SportEventParticipantModel> RetrieveSignedUpSportsEvents(Guid participantId);
        void MakeParticipantAvailableForTeamAllocation(Guid sportEventParticpantId);
        ExistingTeamModel AttemptAllocationToNamedTeam(ExistingTeamModel model);
        TeamCreateModel CreateNewSportEventTeam(TeamCreateModel teamCreateModel);
        IList<TeamMemberDetail> ListTeamMembers(Guid sportEventTeamId);
        void ConfirmTeamMember(Guid sportEventParticipantId);
        NewTeamMemberModel AddNewTeamMember(NewTeamMemberModel model);
        IList<DateTime> FindScheduledDays();
        IList<SportEventGroup> FindSportsEventsWithParticipantSelection(Guid participantId);
        void SignUpParticipant(Guid participantId, List<Guid> selectedSportEventIds);
        void CancelParticipation(Guid scheduledSportEventParticipantId);
    }
}
