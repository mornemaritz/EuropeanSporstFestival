using System.Collections.Generic;
using ESF.Core.Services;
using ESF.Domain;
using System;

namespace ESF.Core.Repositories
{
    public interface ITransportPickupPointRepository
    {
        IList<PickupPointItem> FindAll();
        TransportPickupPoint Load(Guid transportPickupPointId);
    }
}