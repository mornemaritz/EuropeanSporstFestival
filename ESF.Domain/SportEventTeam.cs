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
        private ScheduledSportEvent scheduledSportEvent;
        private ScheduledSportEventParticipant captain;
        private readonly IList<ScheduledSportEventParticipant> teamMembers = new List<ScheduledSportEventParticipant>();

        protected SportEventTeam() { }

        public static SportEventTeam Create(ScheduledSportEventParticipant captain, string name)
        {
            var team = new SportEventTeam
                           {
                               scheduledSportEvent = captain.ScheduledSportEvent, 
                               name = name
                           };

            team.AddConfirmedTeamMember(captain);

            team.captain = captain;

            return team;
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
        public virtual ScheduledSportEvent ScheduledSportEvent
        {
            get { return scheduledSportEvent; }
        }

        /// <summary>
        /// Gets the captain.
        /// </summary>
        /// <value>
        /// The captain.
        /// </value>
        public virtual ScheduledSportEventParticipant Captain
        {
            get { return captain; }
        }

        /// <summary>
        /// Gets the team members.
        /// </summary>
        /// <value>
        /// The team members.
        /// </value>
        public virtual IEnumerable<ScheduledSportEventParticipant> TeamMembers
        {
            get
            {
                return teamMembers;
            }
        }

        /// <summary>
        /// Adds the confirmed team member.
        /// </summary>
        /// <param name="teamMember">The team member.</param>
        /// <exception cref="System.InvalidOperationException">Team member must be a participant in the same sport as the Team.</exception>
        public virtual void AddConfirmedTeamMember(ScheduledSportEventParticipant teamMember)
        {
            if (teamMember.ScheduledSportEvent.Id != scheduledSportEvent.Id)
                throw new InvalidOperationException("Team member must be a participant in the same sport as the Team.");

            teamMember.AddToTeamAsConfirmedMember(this);

            teamMembers.Add(teamMember);
        }

        /// <summary>
        /// Adds an unconfirmed team member.
        /// </summary>
        /// <param name="teamMember">The team member.</param>
        /// <exception cref="System.InvalidOperationException">Team member must be a participant in the same sport as the Team.</exception>
        public virtual void AddUnconfirmedTeamMember(ScheduledSportEventParticipant teamMember)
        {
            if (teamMember.ScheduledSportEvent.Id != scheduledSportEvent.Id)
                throw new InvalidOperationException("Team member must be a participant in the same sport as the Team.");

            teamMember.AddToTeamAsUnconfirmedMember(this);

            teamMembers.Add(teamMember);
        }
        

        /// <summary>
        /// Adds the team member.
        /// </summary>
        /// <param name="teamMember">The team member.</param>
        /// <param name="isCaptain">if set to <c>true</c> [is captain].</param>
        public virtual void AddConfirmedTeamMember(ScheduledSportEventParticipant teamMember, bool isCaptain)
        {
            AddConfirmedTeamMember(teamMember);

            if (isCaptain) captain = teamMember;
        }

        /// <summary>
        /// Removes the team member.
        /// </summary>
        /// <param name="teamMemberToRemove">The team member to remove.</param>
        /// <exception cref="System.InvalidOperationException">Captain cannot be removed from a team. Assign a new Captain first.</exception>
        public virtual void RemoveTeamMember(ScheduledSportEventParticipant teamMemberToRemove)
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
            var newCaptain = teamMembers.SingleOrDefault(x => x.Id == teamMemberIdOfNewCaptain);

            if (newCaptain != null)
            {
                captain = newCaptain;
            }
            else
                throw new InvalidOperationException("New Captain must be a member of the team.");
        }
    }
}
