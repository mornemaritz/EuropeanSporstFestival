using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Core.Repositories;
using ESF.Core.Services;
using ESF.Commons.Repository;
using ESF.Domain;
using ESF.Commons.Utilities;
using NHibernate.SqlCommand;
using NHibernate;
using NHibernate.Criterion;

namespace ESF.Repositories
{
    public class TransportRequestRepository : ITransportRequestRepository
    {
        private readonly IRepository<TransportRequest> entityRepo;

        public TransportRequestRepository(IRepository<TransportRequest> entityRepo)
        {
            Check.IsNotNull(entityRepo, "entityRepo may not be null");

            this.entityRepo = entityRepo;
        }

        public TransportRequest Save(TransportRequest transportRequest)
        {
            Check.IsNotNull(transportRequest, "transportRequest may not be null");

            return entityRepo.Save(transportRequest);
        }

        public IList<TransportRequestItem> FindParticipantTransportRequests(Guid participantId)
        {
            var criteria = entityRepo.CreateDetachedCriteria()
                .CreateAlias("PickupDay", "PickupDay", JoinType.InnerJoin)
                .SetFetchMode("PickupDay", FetchMode.Eager)
                .CreateAlias("PickupPoint", "PickupPoint", JoinType.InnerJoin)
                .SetFetchMode("PickupPoint", FetchMode.Eager)
                .Add(Restrictions.Eq("Participant.Id", participantId));

            return entityRepo.ReportAll<TransportRequestItem>(criteria, GetProjectionList()).ToList();
        }

        private static ProjectionList GetProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property("Id"), "TransportRequestId")
                .Add(Projections.Property("Participant.Id"), "ParticipantId")
                .Add(Projections.Property("PickupDay.Date"), "TransportPickupDay")
                .Add(Projections.Property("PickupPoint.Name"), "TransportPickupPointName");
        }
    }
}
