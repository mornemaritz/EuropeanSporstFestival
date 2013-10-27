using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Repositories;
using ESF.Core.Services.Models;
using ESF.Domain;
using ESF.Commons.Repository;
using ESF.Commons.Utilities;
using NHibernate.Criterion;

namespace ESF.Repositories
{
    public class FestivalDayRepository : IFestivalDayRepository
    {
        private readonly IRepository<FestivalDay> entityRepo;

        public FestivalDayRepository(IRepository<FestivalDay> entityRepo)
        {
            Check.IsNotNull(entityRepo, "entityRepo may not be null");

            this.entityRepo = entityRepo;
        }

        public FestivalDay Load(Guid festivalDayId)
        {
            return entityRepo.Load(festivalDayId);
        }

        public IList<FestivalDayItem> FindDaysWithNoTransportRequests(Guid participantId)
        {
            var transportRequestSubQuery = DetachedCriteria.For<TransportRequest>()
                .Add(Restrictions.Eq("Participant.Id", participantId))
                .SetProjection(Projections.Property("PickupDay.Id"));

            var criteria = entityRepo.CreateDetachedCriteria()
                .Add(Subqueries.PropertyNotIn("Id", transportRequestSubQuery));

            return entityRepo.ReportAll<FestivalDayItem>(criteria, GetProjectionList()).ToList();
        }

        private static ProjectionList GetProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property("Id"), "FestivalDayId")
                .Add(Projections.Property("Date"), "Date");
        }

    }
}
