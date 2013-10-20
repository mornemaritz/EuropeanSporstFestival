using System.Collections.Generic;
using ESF.Commons.Repository;
using ESF.Core.Services;
using ESF.Domain;

namespace ESF.Services
{
    public class TransportService : ITransportService
    {
        private IRepository<TransportPickupPoint> transportPickupPointRepository;

        public IList<PickupPointItem> FindPickupPoints()
        {
            return new List<PickupPointItem>();
        }
    }
}
