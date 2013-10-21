using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Repositories;
using ESF.Commons.Repository;
using ESF.Core.Services;
using ESF.Domain;
using ESF.Commons.Utilities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace ESF.Repositories
{
    public class SportEventTeamRepository : ISportEventTeamRepository
    {
        private readonly IRepository<SportEventTeam> entityRepo;

        public SportEventTeamRepository(IRepository<SportEventTeam> entityRepo)
        {
            Check.IsNotNull(entityRepo, "entityRepo may not be null");

            this.entityRepo = entityRepo;
        }

        public void Update(SportEventTeam sportEventTeam)
        {
            entityRepo.Update(sportEventTeam);
        }

        public SportEventTeam Save(SportEventTeam sportEventTeam)
        {
            Check.IsNotNull(sportEventTeam, "sportEventTeam may not be null");

            return entityRepo.Save(sportEventTeam);
        }

        public IList<TeamMemberDetail> ListTeamMembers(Guid sportEventTeamId)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("TeamMembers", "TeamMembers", JoinType.InnerJoin)
                .SetFetchMode("TeamMembers", FetchMode.Eager)
                .CreateAlias("TeamMembers.Participant", "Participants", JoinType.InnerJoin)
                .SetFetchMode("Participants", FetchMode.Eager)
                .Add(Restrictions.Eq("Id", sportEventTeamId));

            return entityRepo.ReportAll<TeamMemberDetail>(criteria, GetTeamMemberProjectionList()).ToList();
        }

        private ProjectionList GetTeamMemberProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property("Id"), "SportEventTeamId")
                .Add(Projections.Property("TeamMembers.Id"), "TeamMemberSportEventParticipantId")
                .Add(Projections.Property("Participants.FirstName"), "TeamMemberFirstName")
                .Add(Projections.Property("Participants.LastName"), "TeamMemberLastName")
                .Add(Projections.Property("TeamMembers.TeamAllocationStatus"), "TeamMemberAllocationStatus");
        }

        public SportEventTeam FindByName(string sportEventTeamName, Guid scheduledSportEventId)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .Add(Restrictions.Eq("Name", sportEventTeamName))
                .Add(Restrictions.Eq("ScheduledSportEvent.Id", scheduledSportEventId));

            return entityRepo.FindOne(criteria);
        }
    }
}
