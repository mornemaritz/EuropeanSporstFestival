using System;

namespace ESF.Core.Services
{
    public class TeamCreateModel
    {
        public Guid CaptainSportEventParticipantId { get; set; }
        public string TeamName { get; set; }
        public bool TeamAlreadyExists { get; set; }
        public Guid SportEventTeamId { get; set; }
    }
}
