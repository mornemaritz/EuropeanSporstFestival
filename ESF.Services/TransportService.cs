using System.Collections.Generic;
using ESF.Commons.Repository;
using ESF.Core.Repositories;
using ESF.Core.Services;
using ESF.Domain;

namespace ESF.Services
{
    public class TransportService : ITransportService
    {
        private ITransportPickupPointRepository transportPickupPointRepository;

        public IList<PickupPointItem> FindPickupPoints()
        {
            return transportPickupPointRepository.FindAll();
        }
    }
}
