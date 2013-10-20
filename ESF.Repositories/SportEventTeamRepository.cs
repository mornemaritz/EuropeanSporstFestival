using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Repositories;
using ESF.Commons.Repository;
using ESF.Domain;
using ESF.Commons.Utilities;
using NHibernate.Criterion;

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

        public SportEventTeam FindByName(string sportEventTeamName, Guid scheduledSportEventId)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .Add(Restrictions.Eq("Name", sportEventTeamName))
                .Add(Restrictions.Eq("ScheduledSportEvent.Id", scheduledSportEventId));

            return entityRepo.FindOne(criteria);
        }
    }
}
