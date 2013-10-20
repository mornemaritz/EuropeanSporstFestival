using System.Collections.Generic;

namespace ESF.Core.Services
{
    public interface ITransportService
    {
        IList<PickupPointItem> FindPickupPoints();
    }
}
