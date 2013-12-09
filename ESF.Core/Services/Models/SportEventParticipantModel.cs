using System;
using ESF.Commons.Utilities;

namespace ESF.Core.Services
{
    //TODO: Refactor into 2 seperate models, one for viewing list of signed up sports, the other for use when signing up.
    public class SportEventParticipantModel
    {
        private bool canBeDeleted;

        public SportEventParticipantModel(Guid scheduledSportEventParticipantId, string scheduledSportEventName, TeamAllocationStatus teamAllocationStatus, Guid sportEventTeamId, string teamName, bool isTeamCaptain)
        {
            ScheduledSportEventName = scheduledSportEventName;
            ScheduledSportEventParticipantId = scheduledSportEventParticipantId;
            SportEventTeamId = sportEventTeamId;
            TeamName = teamName;
            TeamAllocationStatus = teamAllocationStatus;
            IsTeamCaptain = isTeamCaptain;

            // TODO: As soon as the concept of "Paid for an Event" has been untroduced, a Captain of a team who's team members have already paid, cannot delete a sport.
            canBeDeleted = true;
        }
        public Guid ScheduledSportEventParticipantId { get; private set; }
        public string ScheduledSportEventName { get; private set; }
        public TeamAllocationStatus TeamAllocationStatus { get; set; }
        public string TeamAllocationStatusString
        {
            get { return TeamAllocationStatus.GetStringValue(); }
        }
        public string TeamName { get; private set; }
        public bool IsTeamCaptain { get; private set; }

        public Guid SportEventTeamId { get; private set; }

        public bool CanBeDeleted
        {
            get { return canBeDeleted; }
            set { canBeDeleted = value; }
        }
    }
}
