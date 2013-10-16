using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Repositories;
using ESF.Core.Services;
using ESF.Commons.Repository;
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
        private readonly IRepository<Participant> participantRepository;
        private readonly IScheduledSportEventParticipantRepository sportEventParticipantRepository;

        public ScheduledSportEventRepository(IRepository<ScheduledSportEvent> entityRepo,
            IRepository<Participant> participantRepository,
            IScheduledSportEventParticipantRepository sportEventParticipantRepository)
        {
            Check.IsNotNull(entityRepo, "entityRepo may not be null");
            Check.IsNotNull(participantRepository, "participantRepository may not be null");
            Check.IsNotNull(sportEventParticipantRepository, "sportEventParticipantRepository may not be null");

            this.entityRepo = entityRepo;
            this.participantRepository = participantRepository;
            this.sportEventParticipantRepository = sportEventParticipantRepository;
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

        public IList<SportsEventItem> FindSportEventsAvailableToParticipant(Guid participantId)
        {
            // Get the Participant and related SportEventParticipant items.
            var participant = participantRepository.Get(participantId);
            var participantAge = participant.GetParticipantCurrentAge();
            Check.IsNotNull(participant, "Participant not recognised.");

            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("Sport", "Sport", JoinType.InnerJoin)
                .SetFetchMode("Sport", FetchMode.Eager)
                .Add(Restrictions.Or(Restrictions.IsNull("AllowedGenders"), Restrictions.Eq("AllowedGenders", participant.Gender)))
                .Add(Restrictions.Or(Restrictions.IsNull("MinAge"), Restrictions.Lt("MinAge", participantAge)))
                .Add(Restrictions.Or(Restrictions.IsNull("MaxAge"), Restrictions.Gt("MaxAge", participantAge)));

            var signedUpSportEvents = sportEventParticipantRepository.RetrieveSignedUpSportsEvents(participantId);

            if (signedUpSportEvents != null && signedUpSportEvents.Any())
            {
                criteria.Add(Restrictions.Not(Restrictions.In("Id", signedUpSportEvents.Select(se => se.ScheduledSportEvent.Id).ToArray())));

                foreach (var signedUpSportEvent in signedUpSportEvents)
                {
                    criteria.Add(Restrictions.Not(
                        Restrictions.And(
                            Restrictions.Eq("Date", signedUpSportEvent.ScheduledSportEvent.Date)
                            , Restrictions.Or(
                                   Restrictions.Lt("StartTime", signedUpSportEvent.ScheduledSportEvent.EndTime)
                                   , Restrictions.Gt("EndTime", signedUpSportEvent.ScheduledSportEvent.StartTime)))));
                }
            }

            return entityRepo.ReportAll<SportsEventItem>(criteria, GetSportsEventItemProjectionList()).ToList();
        }

        private static ProjectionList GetSportsEventItemProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property("Id"), "scheduledSportEventId")
                .Add(Projections.Property("Name"), "scheduledsportsEventName");
        }

    }
}
