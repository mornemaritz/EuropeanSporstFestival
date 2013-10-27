using System.Collections.Generic;
using System.Linq;
using ESF.Commons.Repository;
using ESF.Commons.Utilities;
using ESF.Core.Repositories;
using ESF.Core.Services;
using ESF.Domain;
using NHibernate.Criterion;
using System;

namespace ESF.Repositories
{
    public class TransportPickupPointRepository : ITransportPickupPointRepository
    {
        private readonly IRepository<TransportPickupPoint> entityRepo;

        public TransportPickupPointRepository(IRepository<TransportPickupPoint> entityRepo)
        {
            Check.IsNotNull(entityRepo, "entityRepo may not be null");

            this.entityRepo = entityRepo;
        }

        public TransportPickupPoint Load(Guid transportPickupPointId)
        {
            return entityRepo.Load(transportPickupPointId);
        }

        public IList<PickupPointItem> FindAll()
        {
            var criteria = entityRepo.CreateDetachedCriteria();

            return entityRepo.ReportAll<PickupPointItem>(criteria, GetPickupPointItemProjectionList()).ToList();
        }

        private ProjectionList GetPickupPointItemProjectionList()
        {
            return Projections.ProjectionList()
                .Add(Projections.Property("Id"), "TransportPickupPointId")
                .Add(Projections.Property("Name"), "TransportPickupPointName");
        }
    }
}