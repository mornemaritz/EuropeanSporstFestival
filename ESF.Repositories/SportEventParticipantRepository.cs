using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Repositories;
using ESF.Domain;
using ESF.Commons.Utilities;
using NHibernate.Linq;
using ESF.Commons.Repository;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate;

namespace ESF.Repositories
{
    public class SportEventParticipantRepository : ISportEventParticipantRepository
    {
        private readonly IRepository<ParticipantSportEvent> entityRepo;

        public SportEventParticipantRepository(IRepository<ParticipantSportEvent> entityRepo)
        {
            Check.IsNotNull(entityRepo, "entityRepo may not be null");

            this.entityRepo = entityRepo;
        }

        public ParticipantSportEvent Save(ParticipantSportEvent sportEventParticipant)
        {
            Check.IsNotNull(sportEventParticipant, "participant may not be null");

            return entityRepo.Save(sportEventParticipant);
        }

        public IList<ParticipantSportEvent> FindSignedUpSportsEvents(Guid participantId)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("ScheduledSportEvent", "ScheduledSportEvent", JoinType.InnerJoin)
                .SetFetchMode("ScheduledSportEvent", FetchMode.Eager)
                .CreateAlias("ScheduledSportEvent.SportEvent", "SportEvent", JoinType.InnerJoin)
                .SetFetchMode("ScheduledSportEvent.SportEvent", FetchMode.Eager)
                .Add(Restrictions.Eq("Participant.Id", participantId));

            return entityRepo.FindAll(criteria).ToList();
        }
    }
}
