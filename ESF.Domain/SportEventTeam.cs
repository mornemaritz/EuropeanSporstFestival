using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Domain
{
    public class SportEventTeam
    {
        private Guid id;
        private string name;
        private SportEvent sportEvent;
        private SportEventParticipant captain;
        private IList<SportEventParticipant> teamMembers = new List<SportEventParticipant>();

        private SportEventTeam() { }

        public SportEventTeam(SportEvent sportEvent, SportEventParticipant teamMember, bool isCaptain)
        {
            this.sportEvent = sportEvent;

            AddTeamMember(teamMember);

            if (isCaptain)
                captain = teamMember;
        }

        public Guid Id
        {
            get { return id; }
        }

        public string Name 
        {
            get { return name; }
        }

        public SportEvent SportEvent
        {
            get { return sportEvent; }
        }

        public SportEventParticipant Captain
        {
            get { return captain; }
        }

        public IEnumerable<SportEventParticipant> TeamMembers
        {
            get { return teamMembers.Concat(new List<SportEventParticipant> { { captain } }); }
        }

        public void AddTeamMember(SportEventParticipant teamMember)
        {
            if (teamMember.SportEvent.Id != sportEvent.Id)
                throw new InvalidOperationException("Team member must be a participant in the same sport as the Team.");

            teamMembers.Add(teamMember);
        }

        public void AddTeamMember(SportEventParticipant teamMember, bool isCaptain)
        {
            if (!isCaptain)
                AddTeamMember(teamMember);
            else
                captain = teamMember;
        }

        public void RemoveTeamMember(SportEventParticipant teamMemberToRemove)
        {
            if (teamMemberToRemove.Id == captain.Id)
                throw new InvalidOperationException("Captain cannot be removed from a team. Assign a new Captain first.");

            teamMembers.Remove(teamMemberToRemove);
        }

        public void ChangeCaptain(Guid teamMemberIdOfNewCaptain)
        {
            var newCaptain = teamMembers.Where(x => x.Id == teamMemberIdOfNewCaptain).SingleOrDefault();

            if (newCaptain != null)
            {
                var oldCaptain = captain;
                // Add the current Captain as a member;
                AddTeamMember(oldCaptain);
                // Set the new Captain
                captain = newCaptain;
            }
            else
                throw new InvalidOperationException("New Captain must be a member of the team.");
        }
    }
}
