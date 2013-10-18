using System.Collections.Generic;
using ESF.Core.Services.Models;

namespace ESF.Core.Services
{
    public interface ITransportService
    {
        IList<PickupPointItem> FindPickupPoints();
    }
}
