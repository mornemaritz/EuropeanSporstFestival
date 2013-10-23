using System.Collections.Generic;
using ESF.Core.Services;

namespace ESF.Core.Repositories
{
    public interface ITransportPickupPointRepository
    {
        IList<PickupPointItem> FindAll();
    }
}