using System;

namespace ESF.Core.Services
{
    public class PickupPointItem
    {
        public PickupPointItem(Guid pickupPointId, string pickupPointName)
        {
            PickupPointId = pickupPointId;
            PickupPointName = pickupPointName;
        }

        public Guid PickupPointId { get; set; }
        public string PickupPointName { get; set; }
    }
}
