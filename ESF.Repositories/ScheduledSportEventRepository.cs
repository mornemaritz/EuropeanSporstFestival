using System;
using System.Collections.Generic;
using System.Linq;
using ESF.Core.Repositories;
using ESF.Commons.Repository;
using ESF.Core.Services;
using ESF.Domain;
using ESF.Commons.Utilities;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate;

namespace ESF.Repositories
{
    public class ScheduledSportEventRepository : IScheduledSportEventRepository
    {
        private readonly IRepository<ScheduledSportEvent> entityRepo;

        public ScheduledSportEventRepository(IRepository<ScheduledSportEvent> entityRepo)
        {
            Check.IsNotNull(entityRepo, "entityRepo may not be null");

            this.entityRepo = entityRepo;
        }

        public ScheduledSportEvent Load(Guid scheduledSportEventId)
        {
            return entityRepo.Load(scheduledSportEventId);
        }

        public ScheduledSportEvent RetrieveScheduledSportEventWithSportDetails(Guid scheduledSportEventId)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("Sport", "Sport", JoinType.InnerJoin)
                .SetFetchMode("Sport", FetchMode.Eager)
                .Add(Restrictions.Eq("Id", scheduledSportEventId));

            return entityRepo.FindOne(criteria);
        }

        public IList<ScheduledSportEvent> RetrieveScheduledSportEventsForAgeAndGender(int age, Gender gender)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("Sport", "Sport", JoinType.InnerJoin)
                .SetFetchMode("Sport", FetchMode.Eager)
                .Add(BitwiseRestrictions.HasFlag("AllowedGenders", gender))
                .Add(Restrictions.Le("MinAge", age))
                .Add(Restrictions.Ge("MaxAge", age));

            return entityRepo.FindAll(criteria).ToList();
        }

        public IList<ScheduleOverLapDetail> FindAllScheduleOverLapDetails()
        {
            var criteria = DetachedCriteria.For<ScheduledSportEventOverLap>();

            return entityRepo.ReportAll<ScheduleOverLapDetail>(criteria, GetScheduleOverLapProjectionList()).ToList();
        }

        private static ProjectionList GetScheduleOverLapProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property("ScheduledSportEvent.Id"))
                .Add(Projections.Property("OverLappingScheduledSportEvent.Id"));
        }

        public IList<ScheduledSportEvent> RetrieveScheduledSportEventsExcluding(Guid[] scheduledSportEventToExcludeIds)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("Sport", "Sport", JoinType.InnerJoin)
                .SetFetchMode("Sport", FetchMode.Eager);

            if(scheduledSportEventToExcludeIds != null)
                criteria.Add(Restrictions.Not(Restrictions.In("Id", scheduledSportEventToExcludeIds)));

            return entityRepo.FindAll(criteria).ToList();
        }

        public IList<DateTime> FindScheduledDays()
        {
            var criteria = entityRepo.CreateDetachedCriteria();

            return entityRepo.ReportAll<DateTime>(criteria, GetScheduleDateProjectionList()).ToList();
        }

        public IList<ScheduledSportEvent> RetrieveSignedUpSportsEvents(Guid participantId)
        {
            var participationCriteria = DetachedCriteria.For<ScheduledSportEventParticipant>()
                .Add(Restrictions.Eq("Participant.Id", participantId))
                .SetProjection(Projections.Property("ScheduledSportEvent.Id"));

            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("Sport", "Sport", JoinType.InnerJoin)
                .SetFetchMode("Sport", FetchMode.Eager)
                .Add(Subqueries.PropertyIn("Id", participationCriteria));

            return entityRepo.FindAll(criteria).ToList();
        }

        private static ProjectionList GetScheduleDateProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Distinct(Projections.Property("Date")), "Date");
        }
    }
}
