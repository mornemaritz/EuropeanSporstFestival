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
using ESF.Core.Services;

namespace ESF.Repositories
{
    public class ScheduledSportEventParticipantRepository : IScheduledSportEventParticipantRepository
    {
        private readonly IRepository<ScheduledSportEventParticipant> entityRepo;

        public ScheduledSportEventParticipantRepository(IRepository<ScheduledSportEventParticipant> entityRepo)
        {
            Check.IsNotNull(entityRepo, "entityRepo may not be null");

            this.entityRepo = entityRepo;
        }

        public ScheduledSportEventParticipant Get(Guid sportEventParticpantId)
        {
            return entityRepo.Get(sportEventParticpantId);
        }

        public ScheduledSportEventParticipant Save(ScheduledSportEventParticipant sportEventParticipant)
        {
            Check.IsNotNull(sportEventParticipant, "participant may not be null");
            Check.IsTrue(sportEventParticipant.Id == Guid.Empty, "Incorrect persistence operation called for a persistent entity. Call Update.");

            return entityRepo.Save(sportEventParticipant);
        }

        public void Update(ScheduledSportEventParticipant sportEventParticipant)
        {
            Check.IsNotNull(sportEventParticipant, "sportEventParticipant may not be null");
            Check.IsTrue(sportEventParticipant.Id != Guid.Empty, "Incorrect persistence operation called for transient entity. Call Save.");

            entityRepo.Update(sportEventParticipant);
        }

        public IList<SportEventParticipantModel> FindSignedUpSportsEvents(Guid participantId)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("ScheduledSportEvent", "ScheduledSportEvent", JoinType.InnerJoin)
                .SetFetchMode("ScheduledSportEvent", FetchMode.Eager)
                .CreateAlias("ScheduledSportEvent.Sport", "Sport", JoinType.InnerJoin)
                .SetFetchMode("ScheduledSportEvent.Sport", FetchMode.Eager)
                .Add(Restrictions.Eq("Participant.Id", participantId));

            return entityRepo.ReportAll<SportEventParticipantModel>(criteria, GetProjectionList()).ToList();
        }

        public IList<ScheduledSportEventParticipant> RetrieveSignedUpSportsEvents(Guid participantId)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("ScheduledSportEvent", "ScheduledSportEvent", JoinType.InnerJoin)
                .SetFetchMode("ScheduledSportEvent", FetchMode.Eager)
                .CreateAlias("ScheduledSportEvent.Sport", "Sport", JoinType.InnerJoin)
                .SetFetchMode("ScheduledSportEvent.Sport", FetchMode.Eager)
                .Add(Restrictions.Eq("Participant.Id", participantId));

            return entityRepo.FindAll(criteria).ToList();
        }

        private ProjectionList GetProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property("Id"), "ParticipantSportEventId")
                .Add(Projections.Property("ScheduledSportEvent.Name"), "ScheduledSportEventName");
        }
    }
}
