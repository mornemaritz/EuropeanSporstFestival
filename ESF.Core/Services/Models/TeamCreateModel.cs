using System;

namespace ESF.Core.Services
{
    public class TeamCreateModel
    {
        public Guid SportEventTeamId { get; set; }
        public Guid CaptainSportEventParticipantId { get; set; }
        public string TeamName { get; set; }
    }
}
