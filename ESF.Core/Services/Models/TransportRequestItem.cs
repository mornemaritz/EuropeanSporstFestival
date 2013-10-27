using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Utilities;

namespace ESF.Core.Services
{
    public class TransportRequestItem
    {
        public TransportRequestItem(Guid transportRequestId, Guid participantId, DateTime transportPickupDay, string transportPickupPointName)
        {
            TransportRequestId = transportRequestId;
            ParticipantId = participantId;
            TransportPickupDay = transportPickupDay.GetUserFriendlyDate();
            TransportPickupPointName = transportPickupPointName;
        }
        public Guid TransportRequestId { get; private set; }
        public Guid ParticipantId { get; private set; }
        public string TransportPickupDay { get; private set; }
        public string TransportPickupPointName { get; private set; }
    }
}
