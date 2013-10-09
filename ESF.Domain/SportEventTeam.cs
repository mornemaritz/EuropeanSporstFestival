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
        // TO DECIDE: Should the captain be part of the team members collection?
        private IList<SportEventParticipant> teamMembers = new List<SportEventParticipant>();

        protected SportEventTeam() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SportEventTeam"/> class.
        /// </summary>
        /// <param name="sportEvent">The sport event.</param>
        /// <param name="teamMember">The team member.</param>
        /// <param name="isCaptain">if set to <c>true</c> [is captain].</param>
        public SportEventTeam(SportEvent sportEvent, string name, SportEventParticipant teamMember, bool isCaptain)
        {
            this.sportEvent = sportEvent;
            this.name = name;

            AddTeamMember(teamMember);

            if (isCaptain)
                captain = teamMember;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual Guid Id
        {
            get { return id; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name 
        {
            get { return name; }
        }

        /// <summary>
        /// Gets the sport event.
        /// </summary>
        /// <value>
        /// The sport event.
        /// </value>
        public virtual SportEvent SportEvent
        {
            get { return sportEvent; }
        }

        /// <summary>
        /// Gets the captain.
        /// </summary>
        /// <value>
        /// The captain.
        /// </value>
        public virtual SportEventParticipant Captain
        {
            get { return captain; }
        }

        /// <summary>
        /// Gets the team members.
        /// </summary>
        /// <value>
        /// The team members.
        /// </value>
        public virtual IEnumerable<SportEventParticipant> TeamMembers
        {
            get { return teamMembers.Concat(new List<SportEventParticipant> { { captain } }); }
        }

        /// <summary>
        /// Adds the team member.
        /// </summary>
        /// <param name="teamMember">The team member.</param>
        /// <exception cref="System.InvalidOperationException">Team member must be a participant in the same sport as the Team.</exception>
        public virtual void AddTeamMember(SportEventParticipant teamMember)
        {
            if (teamMember.SportEvent.Id != sportEvent.Id)
                throw new InvalidOperationException("Team member must be a participant in the same sport as the Team.");

            teamMembers.Add(teamMember);
        }

        /// <summary>
        /// Adds the team member.
        /// </summary>
        /// <param name="teamMember">The team member.</param>
        /// <param name="isCaptain">if set to <c>true</c> [is captain].</param>
        public virtual void AddTeamMember(SportEventParticipant teamMember, bool isCaptain)
        {
            if (!isCaptain)
                AddTeamMember(teamMember);
            else
                captain = teamMember;
        }

        /// <summary>
        /// Removes the team member.
        /// </summary>
        /// <param name="teamMemberToRemove">The team member to remove.</param>
        /// <exception cref="System.InvalidOperationException">Captain cannot be removed from a team. Assign a new Captain first.</exception>
        public virtual void RemoveTeamMember(SportEventParticipant teamMemberToRemove)
        {
            if (teamMemberToRemove.Id == captain.Id)
                throw new InvalidOperationException("Captain cannot be removed from a team. Assign a new Captain first.");

            teamMembers.Remove(teamMemberToRemove);
        }

        /// <summary>
        /// Changes the captain.
        /// </summary>
        /// <param name="teamMemberIdOfNewCaptain">The team member identifier of new captain.</param>
        /// <exception cref="System.InvalidOperationException">New Captain must be a member of the team.</exception>
        public virtual void ChangeCaptain(Guid teamMemberIdOfNewCaptain)
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
