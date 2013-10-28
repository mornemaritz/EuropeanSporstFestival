using System.Collections.Generic;
using System;
using ESF.Core.Services.Models;

namespace ESF.Core.Services
{
    public interface ITransportService
    {
        IList<PickupPointItem> FindPickupPoints();

        IList<TransportRequestItem> FindParticipantTransportRequests(Guid participantId);

        IList<FestivalDayItem> FindDaysWithNoTransportRequests(Guid participantGuid);

        void CreateTransportRequest(TransportRequestModel transportRequestModel);
        void CancelTransportRequest(Guid transportRequestid);
    }
}
