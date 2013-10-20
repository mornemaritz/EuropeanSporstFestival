using System;

namespace ESF.Core.Services
{
    public class TeamSelectionModel
    {
        public Guid ScheduledSportEventParticipantId { get; set; }
        public int TeamSelectionOption { get; set; }
        public string SportEventTeamName { get; set; }
    }
}
