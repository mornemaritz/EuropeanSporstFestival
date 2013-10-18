using System;

namespace ESF.Core.Services.Models
{
    public class TeamSelectionModel
    {
        public Guid ScheduledSportEventParticipantId { get; set; }
        public int TeamSelectionOption { get; set; }
        public string SportEventTeamName { get; set; }
    }
}
