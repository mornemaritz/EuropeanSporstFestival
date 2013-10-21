using System;
using ESF.Commons.Utilities;

namespace ESF.Core.Services
{
    public class TeamMemberDetail
    {
        public TeamMemberDetail(Guid sportEventTeamId, Guid teamMemberSportEventParticipantId, string teamMemberFirstName, string teamMemberLastName, TeamAllocationStatus teamMemberAllocationStatus)
        {
            SportEventTeamId = sportEventTeamId;
            TeamMemberSportEventParticipantId = teamMemberSportEventParticipantId;
            TeamMemberName = string.Format("{0} {1}",teamMemberFirstName, teamMemberLastName);
            TeamMemberAllocationStatusString = teamMemberAllocationStatus.GetStringValue();
        }

        public Guid SportEventTeamId { get; private set; }
        public Guid TeamMemberSportEventParticipantId { get; private set; }
        public string TeamMemberName { get; private set; }
        public string TeamMemberAllocationStatusString { get; private set; }
    }
}
